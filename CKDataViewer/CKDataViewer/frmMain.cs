using CKDataViewer.Utilities;
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
        private bool runThread = true;

        private object dictionarySyncLock = new object();
        private DataContainerDictionary dataContainerDictionary;

        private DispatcherTimer refreshTimer = new DispatcherTimer();

        public frmMain()
        {
            InitializeComponent();

            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width / 1.2);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height / 1.2);

            frmSettings settingsLoader = new frmSettings();
            if (settingsLoader.ShowDialog() != DialogResult.OK)
                Environment.Exit(0);

            PORT = settingsLoader.selectedPort;
            ROBOT_IP = settingsLoader.ipAddress;

            oscReceiver.DoWork += oscReceiverWorker_DoWork;
            oscReceiver.RunWorkerCompleted += oscReceiverWorker_RunWorkerCompleted;

            dataContainerDictionary = new DataContainerDictionary(100);
            dataContainerDictionary.ItemAdded += DataContainerDictionary_ItemAdded;
            dataContainerDictionary.ItemRemoved += DataContainerDictionary_ItemRemoved;

            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            dataChart.Series.Clear();
            dataChart.Titles.Clear();
            dataChart.ChartAreas.Clear();
            dataChart.Legends.Clear();

            dataChart.Titles.Add("Realtime Data");
            dataChart.ChartAreas.Add(new ChartArea("Realtime Data"));
            dataChart.Legends.Add(new Legend("Legend"));
            dataChart.Legends[0].Title = "Legend";
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

        private ElapsedTimer eTimer = new ElapsedTimer();

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            eTimer.start();

            double timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

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
                                    while (dataChart.Series[currIdx].Points.Count > dataContainerDictionary.MaxNumValues / 2)
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

            Console.WriteLine("ElapsedTime:" + eTimer.hasElapsed());
        }

        private string FormatValue(string value)
        {
            double tryDouble;
            if (Double.TryParse(value, out tryDouble))
            {
                return tryDouble.ToString("0.#####");
            }

            value = value.ToLower();
            return value;
        }

        private double ParseValue(string value)
        {
            double tryDouble;
            if (Double.TryParse(value, out tryDouble))
                return tryDouble;
            else
                return 0;
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
                                    Parallel.ForEach(messageReceived.Arguments, (a) =>
                                    {
                                        dataList.Add(a.ToString(), true);
                                    });

                                    lock(dictionarySyncLock)
                                    {
                                        dataContainerDictionary.Add(dataList);
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
            refreshTimer.Start();
        }

        private void CmdClearChartItems_Click(object sender, EventArgs e)
        {
            foreach (LogItemLabel l in itemSelectionPanel.Controls)
            {
                l.DisableChart();
            }
        }
    }
}
