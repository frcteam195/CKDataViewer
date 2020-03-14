using CKDataToolbox.Utilities;
using SharperOSC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Threading;

namespace CKDataViewer
{
    public partial class frmMain : Form
    {
        private readonly int PORT;
        private readonly string ROBOT_IP;

        private BackgroundWorker oscReceiver = new BackgroundWorker();
        private BackgroundWorker oscSender = new BackgroundWorker();
        private bool runThread = true;

        private object dictionarySyncLock = new object();
        private DataContainerDictionary dataContainerDictionary;

        private DispatcherTimer refreshTimer = new DispatcherTimer();

        private readonly DateTime programLaunchTime;
        private static readonly int DATA_CONTAINER_SIZE = 200;
        private static readonly int CONSTRAINED_CHART_SIZE = DATA_CONTAINER_SIZE / 2;

        private TimeoutTimer resyncTimer = new TimeoutTimer(5);

        public frmMain()
        {
            InitializeComponent();

            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width / 1.2);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height / 1.2);
            itemSelectionPanel.MinimumSize = new Size(this.Width / 6, itemSelectionPanel.MinimumSize.Height);

            frmSettings settingsLoader = new frmSettings();
            if (settingsLoader.ShowDialog() != DialogResult.OK)
                Environment.Exit(0);

            PORT = settingsLoader.selectedPort;
            ROBOT_IP = settingsLoader.ipAddress;

            oscReceiver.DoWork += oscReceiverWorker_DoWork;
            oscReceiver.RunWorkerCompleted += oscReceiverWorker_RunWorkerCompleted;

            oscSender.DoWork += oscSenderWorker_DoWork;
            oscSender.RunWorkerCompleted += oscSenderWorker_RunWorkerCompleted;

            dataContainerDictionary = new DataContainerDictionary(DATA_CONTAINER_SIZE);
            dataContainerDictionary.ItemAdded += DataContainerDictionary_ItemAdded;
            dataContainerDictionary.ItemRemoved += DataContainerDictionary_ItemRemoved;

            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            dataChart.Series.Clear();
            dataChart.Titles.Clear();
            dataChart.ChartAreas.Clear();
            dataChart.Legends.Clear();

            dataChart.Titles.Add("Robot Data");
            dataChart.ChartAreas.Add(new ChartArea("Robot Data"));
            dataChart.ChartAreas[0].AxisX.Title = "Time";
            dataChart.Legends.Add(new Legend("Legend"));
            dataChart.Legends[0].Title = "Legend";

            programLaunchTime = DateTime.Now;
        }

        private void DataContainerDictionary_ItemRemoved(object sender, EventArgs e)
        {
            var evtArgs = e as DataItemEventArgs;
            itemSelectionPanel.BeginInvoke((MethodInvoker) delegate () {
                itemSelectionPanel.Controls.RemoveAt(itemSelectionPanel.Controls.Count - 1);
            });
        }

        private void DataContainerDictionary_ItemAdded(object sender, EventArgs e)
        {
            var evtArgs = e as DataItemEventArgs;
            itemSelectionPanel.BeginInvoke((MethodInvoker)delegate () {
                itemSelectionPanel.Controls.Add(new LogItemLabel(itemSelectionPanel.Controls.Count, chartSeriesAdd_Handler, chartSeriesRemove_Handler));
            });
        }

        private void chartSeriesAdd_Handler(object sender, EventArgs e)
        {
            dataChart.BeginInvoke((MethodInvoker)delegate ()
            {
                dataChart.Series.Add(new Series());
            });
        }

        private void chartSeriesRemove_Handler(object sender, EventArgs e)
        {
            dataChart.BeginInvoke((MethodInvoker)delegate ()
            {
                dataChart.Series.RemoveAt(dataChart.Series.Count - 1);
            });
        }

#if DEBUG
        private ElapsedTimer refreshETimer = new ElapsedTimer();
#endif

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
#if DEBUG
            refreshETimer.start();
#endif

            double timestamp = (DateTime.Now - programLaunchTime).TotalSeconds;

            itemSelectionPanel.Invoke((MethodInvoker)delegate () {
                lock (dictionarySyncLock)
                {
                    int currNumControls = itemSelectionPanel.Controls.Count;

                    if (currNumControls < dataContainerDictionary.Count)
                    {
                        itemSelectionPanel.Controls.Add(new LogItemLabel(itemSelectionPanel.Controls.Count, chartSeriesAdd_Handler, chartSeriesRemove_Handler));
                        currNumControls = itemSelectionPanel.Controls.Count;
                    }
                    else if (currNumControls > dataContainerDictionary.Count)
                    {
                        itemSelectionPanel.Controls.RemoveAt(itemSelectionPanel.Controls.Count - 1);
                        currNumControls = itemSelectionPanel.Controls.Count;
                    }

                    int seriesIndex = 0;
                    for (int i = 0; i < currNumControls; i++)
                    {
                        var x = dataContainerDictionary.ElementAt(i);
                        itemSelectionPanel.Controls[i].Text = x.Key + ":" + FormatValue(x.Value.LatestValue);

                        if (((LogItemLabel)itemSelectionPanel.Controls[i]).ChartEnabled)
                        {
                            int currIdx = seriesIndex;
                            dataChart.Invoke((MethodInvoker)delegate ()
                            {
                                if (dataChart.Series.Count > currIdx)
                                {
                                    dataChart.Series[currIdx].Label = x.Key;
                                    dataChart.Series[currIdx].Name = x.Key;
                                    dataChart.Series[currIdx].ChartType = SeriesChartType.FastLine;
                                    dataChart.Series[currIdx].Points.AddXY(timestamp, ParseValue(x.Value.LatestValue));
                                    while (dataChart.Series[currIdx].Points.Count > CONSTRAINED_CHART_SIZE)
                                    {
                                        dataChart.Series[currIdx].Points.RemoveAt(0);
                                    }
                                }
                            });
                            seriesIndex++;
                        }
                    }
                    dataChart.Invoke((MethodInvoker)delegate ()
                    {
                        dataChart.ResetAutoValues();
                    });
                }
            });

#if DEBUG
            Console.WriteLine("ElapsedRefreshTime:" + refreshETimer.hasElapsed());
#endif
        }

        private static string FormatValue(string value)
        {
            double tryDouble;
            if (Double.TryParse(value, out tryDouble))
            {
                return tryDouble.ToString("0.#####");
            }

            value = value.ToLower();
            return value;
        }

        private static double ParseValue(string value)
        {
            double tryDouble;
            if (Double.TryParse(value, out tryDouble))
                return tryDouble;
            else
                return 0;
        }

        private void oscSenderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //exitTriggered(1);
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

        private void oscSenderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UDPSender udpSender = null;
            bool reinit = true;
            var heartbeatMsg = new OscMessage("/RegisterRequestor");

            while (runThread)
            {
                try
                {
                    if (udpSender == null || reinit)
                    {
                        try
                        {
                            udpSender = new UDPSender(ROBOT_IP, PORT);
                            reinit = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Couldn't create udp listener");
                        }
                    }

                    udpSender.Send(heartbeatMsg);

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    try
                    {
                        udpSender.Close();
                    }
                    catch (Exception)
                    {

                    }
                    reinit = true;
                }
            }

            udpSender.Close();
        }

        private void oscReceiverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UDPListener udpListener = null;
            bool reinit = true;
            OscMessage messageReceived = null;

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

                    messageReceived = (OscMessage)udpListener.Receive();
                    if (messageReceived != null)
                    {
                        switch (messageReceived.Address)
                        {
                            case "/LogData":
                                try
                                {
                                    CyberDictionary dataList = new CyberDictionary();

                                    for (int i = 0; i < messageReceived.Arguments.Count; i += 2)
                                    {
                                        object key = messageReceived.Arguments[i];
                                        object value = messageReceived.Arguments[i + 1];
                                        dataList.Add(key.ToString(), value.ToString());
                                    }

                                    lock (dictionarySyncLock)
                                    {
                                        if (resyncTimer.isTimedOut()) {
                                            dataContainerDictionary.Add(dataList, true);
                                            resyncTimer.reset();
                                        } else {
                                            dataContainerDictionary.Add(dataList);
                                        }
                                    }
                                }
                                catch (Exception) { }
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            runThread = false;
            int waitCounter = 0;
            while ((oscReceiver.IsBusy) && waitCounter++ < 3)
                Thread.Sleep(500);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            oscReceiver.RunWorkerAsync();
            oscSender.RunWorkerAsync();
            refreshTimer.Start();
        }

        private void CmdClearChartItems_Click(object sender, EventArgs e)
        {
            foreach (LogItemLabel l in itemSelectionPanel.Controls)
            {
                l.DisableChart();
            }
        }

        private void CmdSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JPEG File (*.jpg) | *.jpg | PNG File (*.png) | *.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };

            refreshTimer.Stop();

            if (sfd.ShowDialog() == DialogResult.OK)
                dataChart.SaveImage(sfd.FileName, (ChartImageFormat) sfd.FilterIndex);

            refreshTimer.Start();
        }
    }
}
