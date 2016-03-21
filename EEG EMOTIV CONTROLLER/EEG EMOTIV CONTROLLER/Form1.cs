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
        Dictionary<string, double[]> eegData;

        int counter;

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = false;
            counter = 0;

            chartEeg.Series.Clear();
            totalChannels = channelsEeg.Count();
            for(int i=0;i<totalChannels;i++)
            {
                chartEeg.Series.Add(channelsEeg[i]);
                chartEeg.Series[channelsEeg[i]].ChartType = SeriesChartType.Line;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

                    int totalRecordsData = eegDataFileName.Count() - 1;

                    eegData = new Dictionary<string, double[]>();

                    for (int i = 0; i < totalChannels; i++)
                    {
                        eegData.Add(channelsEeg[i], new double[totalRecordsData]);
                    }

                    for (int i = 0; i < totalRecordsData; i++)
                    {
                        string[] record = eegDataFromFile[i+1].Split(',');
                        for (int j = 0; j < totalChannels; j++)
                        {
                            eegData[channelsEeg[j]][i] = double.Parse(record[j + 2]);
                        }
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("Error! File is already open by another program.");
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 8;


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for(int i=0;i<totalChannels;i++)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueY(eegData[channelsEeg[i]][counter]);
                chartEeg.Series[i].Points.Add(dp);
            }
        }
    }
}
