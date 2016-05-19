﻿using System;
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
        string[] classesCommand = { "netral", "maju", "mundur", "kanan", "kiri" };
        Dictionary<string, int> channelStringToInt;
        int totalChannels;
        int totalRecordsData;
        Dictionary<string, double[]> eegData;
        List<double> fitur;

        const int IIR_TC = 256;
        const int LIMIT_WINDOW_CHART = 64;
        int bufferDecision = 64;
        int buffer;

        int counter;
        int tickSecond;

        double[] dataTesting;

        List<Model> models;
        ModelStorage ms;
        NearestNeighbour knn;

        FFTSignalTransform fft;
        BasicSignalProcessor dsp;

        bool hasLoadFile = false;
        bool hasPickModel = false;
        bool canStart = false;

        public Form1()
        {
            InitializeComponent();

            buttonStart.Enabled = false;

            labelMovement.Text = "netral";

            channelStringToInt = new Dictionary<string, int>();
            for (int i=0; i<channelsEeg.Length;i++)
            {
                channelStringToInt.Add(channelsEeg[i], i);
            }

            fft = new FFTSignalTransform();
            dsp = new BasicSignalProcessor();

            ms = new ModelStorage();
            LoadModelData();

            timer.Enabled = false;
            counter = 1;

            chartEeg.Series.Clear();
            chartEeg.ChartAreas.Add("all");
            totalChannels = channelsEeg.Count();

            chartEeg.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartDeltaTheta.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartAlpha.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartBeta.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartGamma.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            chartEeg.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartDeltaTheta.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartAlpha.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartBeta.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartGamma.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            //chartEeg.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartDeltaTheta.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartAlpha.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartBeta.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartGamma.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            for (int i = 0; i < totalChannels; i++)
            {

                //chartEeg.ChartAreas[0].AxisY.Maximum = 200;
                //chartEeg.ChartAreas[0].AxisY.Minimum = -200;

                chartEeg.Series.Add(channelsEeg[i]);
                chartEeg.Series[channelsEeg[i]].ChartType = SeriesChartType.FastLine;
                chartEeg.Series[channelsEeg[i]].IsVisibleInLegend = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void LoadModelData()
        {
            models = ms.LoadModels();
            comboBoxModel.Items.Clear();
            for (int i=0;i<models.Count;i++)
            {
                comboBoxModel.Items.Add(models[i].name);
            }
            
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string[] eegDataFromFile;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EEG File (*.csv)|*.csv";
            DialogResult result = ofd.ShowDialog();

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

            hasLoadFile = true;

            if (hasLoadFile && hasPickModel)
                buttonStart.Enabled = true;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 8;
            fitur = new List<double>();
            buffer = 0;
            tickSecond = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int totalSensor = models[comboBoxModel.SelectedIndex].GetTotalSelectedChannels();
            dataTesting = new double[totalSensor];

            if (checkShowChart.Checked)
            {
                for (int i = 0; i < totalChannels; i++)
                {
                    DataPoint dp = new DataPoint();
                    dp.SetValueY(eegData[channelsEeg[i]][counter]);
                    chartEeg.Series[i].Points.Add(dp);
                    chartEeg.Update();

                    if (counter > LIMIT_WINDOW_CHART)
                    {
                        chartEeg.Series[i].Points.RemoveAt(0);
                    }
                }
            }

            for (int i = 0; i < totalSensor; i++)
            {
                string id = models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i];
                double value = eegData[id][counter];
                dataTesting[i] = value;

            }

            fft.Init(totalSensor);
            double[] dataEegFreq = fft.DoWork(dataTesting);
            List<double[]> result = dsp.Decomposes(dataEegFreq);

            for (int i = 0; i < totalSensor; i++)
            {
                if (checkShowChart.Checked)
                {
                    chartDeltaTheta.Series[i].Points.AddY(result[0][i]);
                    chartAlpha.Series[i].Points.AddY(result[1][i]);
                    chartBeta.Series[i].Points.AddY(result[2][i]);
                    chartGamma.Series[i].Points.AddY(result[3][i]);

                    if (counter > LIMIT_WINDOW_CHART)
                    {
                        chartDeltaTheta.Series[i].Points.RemoveAt(0);
                        chartAlpha.Series[i].Points.RemoveAt(0);
                        chartBeta.Series[i].Points.RemoveAt(0);
                        chartGamma.Series[i].Points.RemoveAt(0);
                    }
                }

                fitur.Add(result[0][i]);
                fitur.Add(result[1][i]);
                fitur.Add(result[2][i]);
                fitur.Add(result[3][i]);
            }

            if (checkShowChart.Checked)
            {
                chartEeg.ChartAreas[0].RecalculateAxesScale();
                chartDeltaTheta.ChartAreas[0].RecalculateAxesScale();
                chartAlpha.ChartAreas[0].RecalculateAxesScale();
                chartBeta.ChartAreas[0].RecalculateAxesScale();
                chartGamma.ChartAreas[0].RecalculateAxesScale();
            }

            if (totalSensor > 1)
            {
                for (int i = 0; i < totalSensor; i++)
                {
                    for (int j = i + 1; j < totalSensor; j++)
                    {
                        double val1 = result[0][i];
                        double val2 = result[0][j];
                        double powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                        fitur.Add(powerDiff);

                        val1 = result[1][i];
                        val2 = result[1][j];
                        powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                        fitur.Add(powerDiff);

                        val1 = result[2][i];
                        val2 = result[2][j];
                        powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                        fitur.Add(powerDiff);

                        val1 = result[3][i];
                        val2 = result[3][j];
                        powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                        fitur.Add(powerDiff);
                    }
                }
            }

            if ((buffer+1) == bufferDecision)
            {
                int classifyResult = knn.Classify(fitur, 1);
                labelMovement.Text = classesCommand[classifyResult];

                fitur = new List<double>();
                buffer = -1;
                tickSecond++;
                labelTickSecond.Text = tickSecond.ToString();
            }

            ++buffer;
            ++counter;
        }

        private void buttonCreateModel_Click(object sender, EventArgs e)
        {
            FormCreateModel formModel = new FormCreateModel(this);
            formModel.Show();
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDetailModel.Text = models[comboBoxModel.SelectedIndex].ToString();
            comboBoxChannels.Items.Clear();
            int totalChannels = models[comboBoxModel.SelectedIndex].GetTotalSelectedChannels();
            for (int i=0;i<totalChannels;i++)
            {
                comboBoxChannels.Items.Add(models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]);
            }
            
            comboBoxChannels.Invalidate();

            int total = models[comboBoxModel.SelectedIndex].GetTotalSelectedChannels();

            chartDeltaTheta.Series.Clear();
            chartAlpha.Series.Clear();
            chartBeta.Series.Clear();
            chartGamma.Series.Clear();
            for (int i = 0; i < total; i++)
            {
                chartDeltaTheta.Series.Add(models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]);
                chartDeltaTheta.Series[models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]].ChartType = SeriesChartType.FastLine;

                chartAlpha.Series.Add(models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]);
                chartAlpha.Series[models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]].ChartType = SeriesChartType.FastLine;

                chartBeta.Series.Add(models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]);
                chartBeta.Series[models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]].ChartType = SeriesChartType.FastLine;

                chartGamma.Series.Add(models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]);
                chartGamma.Series[models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i]].ChartType = SeriesChartType.FastLine;

            }

            comboBoxChannels.Items.Add("all");
            comboBoxChannels.SelectedIndex = comboBoxChannels.Items.Count - 1;

            knn = new NearestNeighbour(models[comboBoxModel.SelectedIndex]);

            hasPickModel = true;
            if(hasPickModel && hasLoadFile)
            {
                buttonStart.Enabled = true;
            }
        }

        private void comboBoxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideChartSeries(comboBoxChannels.SelectedIndex);
        }

        private void HideChartSeries(int index)
        {
            if(index == comboBoxChannels.Items.Count - 1)
            {
                for (int i = 0; i < comboBoxChannels.Items.Count - 1; i++)
                {
                    //MessageBox.Show(i.ToString());
                    chartDeltaTheta.Series[i].Enabled = true;
                    chartAlpha.Series[i].Enabled = true;
                    chartBeta.Series[i].Enabled = true;
                    chartGamma.Series[i].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < comboBoxChannels.Items.Count - 1; i++)
                {
                    if (index == i)
                    {
                        chartDeltaTheta.Series[i].Enabled = true;
                        chartAlpha.Series[i].Enabled = true;
                        chartBeta.Series[i].Enabled = true;
                        chartGamma.Series[i].Enabled = true;
                    }
                    else
                    {
                        chartDeltaTheta.Series[i].Enabled = false;
                        chartAlpha.Series[i].Enabled = false;
                        chartBeta.Series[i].Enabled = false;
                        chartGamma.Series[i].Enabled = false;
                    }
                }
            }
        }

        private void checkShowChart_CheckedChanged(object sender, EventArgs e)
        {
            if(checkShowChart.Checked)
            {
                chartEeg.Enabled = true;
                chartDeltaTheta.Enabled = true;
                chartAlpha.Enabled = true;
                chartBeta.Enabled = true;
                chartGamma.Enabled = true;
                comboBoxChannels.Enabled = true;
            }
            else
            {
                chartEeg.Enabled = false;
                chartDeltaTheta.Enabled = false;
                chartAlpha.Enabled = false;
                chartBeta.Enabled = false;
                chartGamma.Enabled = false;
                comboBoxChannels.Enabled = false;
            }
        }
    }
}
