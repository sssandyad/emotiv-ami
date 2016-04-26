using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace EEG_EMOTIV_CONTROLLER
{
    public partial class Form1 : Form
    {
        string eegDataFileName;
        string[] channelsEeg = {"AF3","F7","F3","FC5","T7","P7","O1","O2","P8","T8","FC6","F4","F8","AF4"};
        int totalChannels;
        int totalRecordsData;
        Dictionary<string, double[]> eegData;

        const int IIR_TC = 256;
        const int LIMIT_WINDOW_CHART = 64;

        int counter;

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = false;
            counter = 1;

            chartEeg.Series.Clear();
            totalChannels = channelsEeg.Count();
            for(int i=0;i<totalChannels;i++)
            {
                chartEeg.Series.Add(channelsEeg[i]);
                chartEeg.Series[channelsEeg[i]].ChartType = SeriesChartType.FastLine;
            }
            chartEeg.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartEeg.ChartAreas[0].AxisY.Maximum = 400;
            chartEeg.ChartAreas[0].AxisY.Minimum = -400;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void initializeChart()
        {
            for (int j=0; j<LIMIT_WINDOW_CHART; j++)
            {
                for (int i = 0; i < totalChannels; i++)
                {
                    DataPoint dp = new DataPoint();
                    dp.SetValueY(0);
                    chartEeg.Series[i].Points.Add(dp);
                }
            }
            //counter = LIMIT_WINDOW_CHART;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string[] eegDataFromFile;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EEG File (*.csv)|*.csv";
            DialogResult result= ofd.ShowDialog();

            if(result == DialogResult.OK)
            {
                try
                {
                    eegDataFileName = ofd.FileName;
                    eegDataFromFile = File.ReadAllLines(eegDataFileName);

                    totalRecordsData = eegDataFromFile.Count() - 1;
                    //MessageBox.Show(totalRecordsData.ToString());

                    eegData = new Dictionary<string, double[]>();

                    for (int i = 0; i < totalChannels; i++)
                    {
                        eegData.Add(channelsEeg[i], new double[totalRecordsData]);
                    }

                    /*
                    The data returned is the voltage (in microvolts) for each channel, at each time sample.
                    You get 128 samples per sec, and you need to remove the DC offset from the data
                    (about 4200uV but it drifts around a little, so you need a filter or running average subtraction)
                    */
                    double[] back = new double[14];
                    string[] firstRecord = eegDataFromFile[1].Split(',');
                    for (int i = 0; i < 14; i++)
                    {
                        back[i] = double.Parse(firstRecord[i+2]);
                    }

                    double value;
                    for (int i = 1; i < totalRecordsData; i++)
                    {
                        string[] record = eegDataFromFile[i+1].Split(',');
                        for (int j = 0; j < totalChannels; j++)
                        {
                            value = double.Parse(record[j+2]);
                            back[j] = (back[j] * (IIR_TC - 1) + value) / IIR_TC; // IIR filter
                            eegData[channelsEeg[j]][i] = value - back[j]; // remove DC offset 
                        }
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("Error! File is already open by another program.");
                }
            }
            initializeChart();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < totalChannels; i++)
            {
                chartEeg.Series[i].Points.RemoveAt(0);

                DataPoint dp = new DataPoint();
                dp.SetValueY(eegData[channelsEeg[i]][counter]);                    
                chartEeg.Series[i].Points.Add(dp);
                chartEeg.Update();
            }
            ++counter;
        }
    }
}
