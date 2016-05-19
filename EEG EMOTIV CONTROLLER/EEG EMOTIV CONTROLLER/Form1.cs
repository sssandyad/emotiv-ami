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

        double[] dataTesting;

        List<Model> models;
        ModelStorage ms;

        FFTSignalTransform fft;
        BasicSignalProcessor dsp;

        public Form1()
        {
            InitializeComponent();

            channelStringToInt = new Dictionary<string, int>();
            for (int i=0; i<channelsEeg.Length;i++)
            {
                channelStringToInt.Add(channelsEeg[i], i);
            }

            fft = new FFTSignalTransform();
            dsp = new BasicSignalProcessor();

            ms = new ModelStorage();
            LoadModelData();

            //ScrollBar vScrollBar1 = new VScrollBar();
            //vScrollBar1.Dock = DockStyle.Right;
            //vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            //panel1.Controls.Add(vScrollBar1);

            timer.Enabled = false;
            counter = 1;

            chartEeg.Series.Clear();
            chartEeg.ChartAreas.Add("all");
            totalChannels = channelsEeg.Count();
            int y = 1;
            for(int i=0;i<totalChannels;i++)
            {
                //chartEeg.ChartAreas.Add(channelsEeg[i]);
                //chartEeg.ChartAreas[channelsEeg[i]].AxisX.LabelStyle.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisY.LabelStyle.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisX.MajorGrid.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisY.MajorGrid.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisY.MajorTickMark.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisY.MinorTickMark.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisX.MajorTickMark.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisX.MinorTickMark.Enabled = false;
                //chartEeg.ChartAreas[channelsEeg[i]].BorderWidth = 0;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisX.MajorGrid.LineWidth = 0;
                //chartEeg.ChartAreas[channelsEeg[i]].AxisY.MajorGrid.LineWidth = 0;
                chartEeg.ChartAreas[0].AxisY.Maximum = 200;
                chartEeg.ChartAreas[0].AxisY.Minimum = -200;

                //chartEeg.ChartAreas[channelsEeg[i]].Position.Width = 85;
                //chartEeg.ChartAreas[channelsEeg[i]].Position.Height = 6;
                //chartEeg.ChartAreas[channelsEeg[i]].Position.X = 1;
                //chartEeg.ChartAreas[channelsEeg[i]].Position.Y = y; y += 6;

                chartEeg.Series.Add(channelsEeg[i]);
                chartEeg.Series[channelsEeg[i]].ChartType = SeriesChartType.FastLine;
                chartEeg.Series[channelsEeg[i]].IsVisibleInLegend = true;
            }
            //chartEeg.ChartAreas[0].Visible = false;
            //chartEeg.ChartAreas[2].Visible = false;
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
            initializeChart();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 1;
            fitur = new List<double>();
            buffer = 0;
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

            int totalSensor = models[comboBoxModel.SelectedIndex].GetTotalSelectedChannels();
            dataTesting = new double[totalSensor];

            for (int i = 0; i < totalSensor; i++)
            {
                string id = models[comboBoxModel.SelectedIndex].selectedChannelsIndex[i];
                double value = eegData[id][counter];
                dataTesting[i] = value;

            }

            double[] dataEegFreq = fft.DoWork(dataTesting);
            List<double[]> result = dsp.Decomposes(dataEegFreq);
            for (int i = 0; i < totalSensor; i++)
            {
                chartDeltaTheta.Series[i].Points.AddY(result[0][i]);
                chartAlpha.Series[i].Points.AddY(result[1][i]);
                chartBeta.Series[i].Points.AddY(result[2][i]);
                chartGamma.Series[i].Points.AddY(result[3][i]);

                fitur.Add(result[0][i]);
                fitur.Add(result[1][i]);
                fitur.Add(result[2][i]);
                fitur.Add(result[3][i]);
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

            

            if ((buffer+1) % bufferDecision == 0)
            { 
                //Console.WriteLine("hei: " + fitur.Count.ToString());
                //timer.Enabled = false;
                fitur = new List<double>();
                buffer = 0;
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

            chartDeltaTheta.Series.Clear();
            chartAlpha.Series.Clear();
            chartBeta.Series.Clear();
            chartGamma.Series.Clear();
            int total = models[comboBoxModel.SelectedIndex].GetTotalSelectedChannels();
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
    }
}
