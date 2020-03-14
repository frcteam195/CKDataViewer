using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SharperOSC;
using System.Diagnostics;
using CKDataToolbox.Utilities;
using System.Windows.Forms.DataVisualization.Charting;

namespace CKPIDTuner
{
    public partial class frmMain : Form
    {
        private readonly int PORT; 
        private readonly string ROBOT_IP;

        private bool runThread = true;
        private MovingAverage averageError = new MovingAverage(20);
        private UDPSender oscSender;
        private BackgroundWorker oscReceiver = new BackgroundWorker();
        private bool initCompleted = false;

        private readonly DateTime programLaunchTime;
        private static readonly int DATA_CONTAINER_SIZE = 200;
        private static readonly int CONSTRAINED_CHART_SIZE = DATA_CONTAINER_SIZE / 2;

        private void frmMain_Load(object sender, EventArgs e)
        {
            numkP.LostFocus += sendPIDUpdate;
            numkI.LostFocus += sendPIDUpdate;
            numkD.LostFocus += sendPIDUpdate;
            numkF.LostFocus += sendPIDUpdate;
            numAccel.LostFocus += sendPIDUpdate;
            numVel.LostFocus += sendPIDUpdate;
            numRamp.LostFocus += sendPIDUpdate;
            numIZone.LostFocus += sendPIDUpdate;
            numSetpoint.LostFocus += sendPIDUpdate;
            numMaxIAccum.LostFocus += sendPIDUpdate;

            numkP.KeyDown += checkEnter_Pressed;
            numkI.KeyDown += checkEnter_Pressed;
            numkD.KeyDown += checkEnter_Pressed;
            numkF.KeyDown += checkEnter_Pressed;
            numAccel.KeyDown += checkEnter_Pressed;
            numVel.KeyDown += checkEnter_Pressed;
            numRamp.KeyDown += checkEnter_Pressed;
            numIZone.KeyDown += checkEnter_Pressed;
            numSetpoint.KeyDown += checkEnter_Pressed;
            numMaxIAccum.KeyDown += checkEnter_Pressed;

            oscReceiver.RunWorkerAsync();
        }



        public frmMain()
        {
            InitializeComponent();

            frmSettings settingsLoader = new frmSettings();
            if (settingsLoader.ShowDialog() != DialogResult.OK)
                Environment.Exit(0);

            PORT = settingsLoader.selectedPort;
            ROBOT_IP = settingsLoader.ipAddress;
            oscReceiver.DoWork += oscReceiverWorker_DoWork;
            oscReceiver.RunWorkerCompleted += oscReceiverWorker_RunWorkerCompleted;

            dataChart.Series.Clear();
            dataChart.Titles.Clear();
            dataChart.ChartAreas.Clear();
            dataChart.Legends.Clear();

            dataChart.Titles.Add("Robot Data");
            dataChart.ChartAreas.Add(new ChartArea("Robot Data"));
            dataChart.ChartAreas[0].AxisX.Title = "Time";
            dataChart.Legends.Add(new Legend("Legend"));
            dataChart.Legends[0].Title = "Legend";
            dataChart.Series.Add(new Series("Actual Value"));
            dataChart.Series.Add(new Series("Requested Value"));
            dataChart.Series[0].Label = "Actual Value";
            dataChart.Series[0].Name = "Actual Value";
            dataChart.Series[0].ChartType = SeriesChartType.FastLine;
            dataChart.Series[1].Label = "Requested Value";
            dataChart.Series[1].Name = "Requested Value";
            dataChart.Series[1].ChartType = SeriesChartType.FastLine;


            try
            {
                oscSender = new UDPSender(ROBOT_IP, PORT);
            } catch (Exception)
            {
                MessageBox.Show("Error creating UDP Sender. Make sure your IP Address and port settings are correct!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            programLaunchTime = DateTime.Now;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            runThread = false;
            int waitCounter = 0;
            while ((oscReceiver.IsBusy) && waitCounter++ < 3)
                Thread.Sleep(500);
        }

        private void checkEnter_Pressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendPIDUpdate(sender, e);
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            sendPIDUpdate(sender, e);
        }

        private void cmdClearIAccum_Click(object sender, EventArgs e)
        {
            sendIAccumReset();
        }

        private void sendPIDUpdate(object sender, EventArgs e)
        {
            var message = new OscMessage("/PIDUpdate",
                (double)numkP.Value,
                (double)numkI.Value,
                (double)numkD.Value,
                (double)numkF.Value,
                (double)numAccel.Value,
                (double)numVel.Value,
                (double)numRamp.Value,
                (double)numIZone.Value,
                (double)numSetpoint.Value,
                (double)numMaxIAccum.Value);
            oscSender.Send(message);
        }

        private void sendIAccumReset()
        {
            sendIAccumReset(0);
        }

        private void sendIAccumReset(double sendVal)
        {
            var message = new OscMessage("/IReset", sendVal);
            oscSender.Send(message);
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            sendIAccumReset();
        }

        private void numSetpoint_ValueChanged(object sender, EventArgs e)
        {
            cmdApply_Click(sender, e);
        }

        private void oscReceiverWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exitTriggered(1);
        }

        private void exitTriggered(int exitCode)
        {
            try
            {

            }
            catch (Exception)
            {

            }

            Environment.Exit(exitCode);
        }

        private void oscReceiverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UDPListener udpListener = null;
            bool reinit = true;
            OscMessage messageReceived = null;

            int nameUpdateCounter = 0;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (runThread)
            {
                try
                {
                    if (udpListener == null || reinit)
                    {
                        try
                        {
                            udpListener = new UDPListener(PORT);
                            reinit = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Couldn't create udp listener");
                        }
                    }

                    /**
                    * Tuning Packet Descriptor
                    * Actual Value, Requested Value, IAccum, System Name
                    */
                    if (!initCompleted)
                    {
                        //Initialize the connection
                        sendIAccumReset();
                        initCompleted = true;
                    }

                    messageReceived = (OscMessage)udpListener.Receive();
                    if (messageReceived != null)
                    {
                        switch (messageReceived.Address)
                        {
                            case "/PIDData":
                                double timestamp = (DateTime.Now - programLaunchTime).TotalSeconds;
                                double actualVal = (double)messageReceived.Arguments[0];
                                double requestedVal = (double)messageReceived.Arguments[1];
                                dataChart.Invoke((MethodInvoker)delegate ()
                                {
                                    dataChart.Series[0].Points.AddXY(timestamp, actualVal);
                                    dataChart.Series[1].Points.AddXY(timestamp, requestedVal);
                                    for (int i = 0; i < dataChart.Series.Count; i++)
                                    {
                                        while (dataChart.Series[i].Points.Count > CONSTRAINED_CHART_SIZE)
                                        {
                                            dataChart.Series[i].Points.RemoveAt(0);
                                        }
                                    }
                                    dataChart.ResetAutoValues();
                                });
                                if (stopWatch.ElapsedMilliseconds > 200)
                                {
                                    //Update TextBox UI Every 200ms to avoid slowing down the app
                                    double iAccum = (double)messageReceived.Arguments[2];
                                    double err = requestedVal - actualVal;
                                    averageError.AddEntry(err);
                                    txtActualVal.Invoke((MethodInvoker)delegate { txtActualVal.Text = actualVal.ToString("0.####"); });
                                    txtDesiredVal.Invoke((MethodInvoker)delegate { txtDesiredVal.Text = requestedVal.ToString("0.####"); });
                                    txtDeviation.Invoke((MethodInvoker)delegate { txtDeviation.Text = err.ToString("0.####"); });
                                    txtAverageDev.Invoke((MethodInvoker)delegate { txtAverageDev.Text = averageError.Average.ToString("0.####"); });
                                    txtIAccum.Invoke((MethodInvoker)delegate { txtIAccum.Text = iAccum.ToString("0.####"); });

                                    if (nameUpdateCounter++ % 5 == 0)
                                        txtSysName.Invoke((MethodInvoker)delegate { txtSysName.Text = (string)messageReceived.Arguments[3]; });

                                    stopWatch.Restart();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    try
                    {
                        udpListener.Close();
                    }
                    catch (Exception)
                    {

                    }
                    reinit = true;
                }
            }

            udpListener.Close();
        }


    }
}
