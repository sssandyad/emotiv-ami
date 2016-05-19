using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEG_EMOTIV_CONTROLLER
{
    public partial class FormCreateModel : Form
    {
        Form1 mainForm;

        int phase;

        int bufferDecision = 64;

        FFTSignalTransform fft;
        BasicSignalProcessor dsp;

        Model model;
        ModelStorage ms;
        public string modelName = "";

        string[] channelsEeg = { "AF3", "F7", "F3", "FC5", "T7", "P7", "O1", "O2", "P8", "T8", "FC6", "F4", "F8", "AF4" };
        string[] classesCommand = { "netral", "maju", "mundur", "kanan", "kiri" };

        Dictionary<string, int> channelsIndex;
        Dictionary<string, int> classesIndex;
        Dictionary<string, bool> classesDataLoaded;
        Dictionary<string, TextBox> textBoxClasses;

        public List<List<double[]>> allData;

        public FormCreateModel(Form1 f)
        {
            InitializeComponent();

            mainForm = f;

            ms = new ModelStorage();

            timerProgress.Enabled = false;

            model = new Model();
            fft = new FFTSignalTransform();
            dsp = new BasicSignalProcessor();

            phase = 1;

            groupBoxClass.Enabled = false;
            buttonPhase2.Enabled = false;
            groupBoxLoadDataSet.Enabled = false;
            buttonTrain.Enabled = false;

            channelsIndex = new Dictionary<string, int>();
            for (int i = 0; i < channelsEeg.Count(); i++)
            {
                channelsIndex.Add(channelsEeg[i], i);
            }

            allData = new List<List<double[]>>();
            classesIndex = new Dictionary<string, int>();
            classesDataLoaded = new Dictionary<string, bool>();
            for (int i = 0; i < classesCommand.Count(); i++)
            {
                classesIndex.Add(classesCommand[i], i);
                classesDataLoaded.Add(classesCommand[i], false);
                allData.Add(null);
            }

            textBoxClasses = new Dictionary<string, TextBox>();
            textBoxClasses.Add("netral", textBoxNetral);
            textBoxClasses.Add("maju", textBoxMaju);
            textBoxClasses.Add("mundur", textBoxMundur);
            textBoxClasses.Add("kanan", textBoxKanan);
            textBoxClasses.Add("kiri", textBoxKiri);

        }

        private void buttonPhase1_Click(object sender, EventArgs e)
        {
            if(phase == 1)
            {
                phase++;
                buttonPhase1.Text = "<== back";
                buttonCancel.Enabled = false;
                groupBoxChannels.Enabled = false;
                groupBoxClass.Enabled = true;
                buttonPhase2.Enabled = true;
            }
            else if (phase == 2)
            {
                phase--;
                buttonPhase1.Text = "next ==>";
                buttonCancel.Enabled = true;
                groupBoxChannels.Enabled = true;
                groupBoxClass.Enabled = false;
                buttonPhase2.Enabled = false;
            }
        }

        private void buttonPhase2_Click(object sender, EventArgs e)
        {
            if (phase == 2)
            {
                phase++;
                buttonPhase2.Text = "<== back";
                buttonPhase1.Enabled = false;
                groupBoxClass.Enabled = false;
                groupBoxLoadDataSet.Enabled = true;
                buttonTrain.Enabled = true;

                EnableLoadDataSet();
            }
            else if (phase == 3)
            {
                phase--;
                buttonPhase2.Text = "next ==>";
                buttonPhase1.Enabled = true;
                groupBoxClass.Enabled = true;
                groupBoxLoadDataSet.Enabled = false;
                buttonTrain.Enabled = false;
            }
        }

        private void EnableLoadDataSet()
        {
            if (checkBoxNetral.Checked)
            {
                labelNetral.Enabled = true;
                buttonLoadNetral.Enabled = true;
                textBoxNetral.Enabled = true;
            }
            else
            {
                labelNetral.Enabled = false;
                buttonLoadNetral.Enabled = false;
                textBoxNetral.Enabled = false;
            }

            if (checkBoxMaju.Checked)
            {
                labelMaju.Enabled = true;
                buttonLoadMaju.Enabled = true;
                textBoxMaju.Enabled = true;
            }
            else
            {
                labelMaju.Enabled = false;
                buttonLoadMaju.Enabled = false;
                textBoxMaju.Enabled = false;
            }

            if (checkBoxMundur.Checked)
            {
                labelMundur.Enabled = true;
                buttonLoadMundur.Enabled = true;
                textBoxMundur.Enabled = true;
            }
            else
            {
                labelMundur.Enabled = false;
                buttonLoadMundur.Enabled = false;
                textBoxMundur.Enabled = false;
            }

            if (checkBoxKanan.Checked)
            {
                labelKanan.Enabled = true;
                buttonLoadKanan.Enabled = true;
                textBoxKanan.Enabled = true;
            }
            else
            {
                labelKanan.Enabled = false;
                buttonLoadKanan.Enabled = false;
                textBoxKanan.Enabled = false;
            }

            if (checkBoxKiri.Checked)
            {
                labelKiri.Enabled = true;
                buttonLoadKiri.Enabled = true;
                textBoxKiri.Enabled = true;
            }
            else
            {
                labelKiri.Enabled = false;
                buttonLoadKiri.Enabled = false;
                textBoxKiri.Enabled = false;
            }
        }

        public void CalculateFeature()
        {
            for (int i = 0; i < model.dataTraining.Count; i++)
            {
                model.dataTrainingFreq.Add(fft.DoWork(model.dataTraining[i]));
            }

            List<double[]> deltaTheta = new List<double[]>();
            List<double[]> alpha = new List<double[]>();
            List<double[]> beta = new List<double[]>();
            List<double[]> gamma = new List<double[]>();
            List<double[]> result;

            for (int i = 0; i < model.dataTrainingFreq.Count; i++)
            {
                result = dsp.Decomposes(model.dataTrainingFreq[i]);
                deltaTheta.Add(result[0]);
                alpha.Add(result[1]);
                beta.Add(result[2]);
                gamma.Add(result[3]);
            }

            model.spectral.Add("deltaTheta", deltaTheta);
            model.spectral.Add("alpha", alpha);
            model.spectral.Add("beta", beta);
            model.spectral.Add("gamma", gamma);

            int jumlahSensor = model.GetTotalSelectedChannels();
            int jumlahData = model.GetTotalData();

            //MessageBox.Show(jumlahData.ToString() + " " + jumlahSensor.ToString());

            List<double> fitur = new List<double>(); ;

            for (int k = 0; k < jumlahData; k++)
            {
                for (int i = 0; i < jumlahSensor; i++)
                {
                    fitur.Add(model.spectral["deltaTheta"][k][i]);
                    fitur.Add(model.spectral["alpha"][k][i]);
                    fitur.Add(model.spectral["beta"][k][i]);
                    fitur.Add(model.spectral["gamma"][k][i]);
                }

                if (jumlahSensor > 1)
                {
                    for (int i = 0; i < jumlahSensor; i++)
                    {
                        for (int j = i + 1; j < jumlahSensor; j++)
                        {
                            double val1 = model.spectral["deltaTheta"][k][i];
                            double val2 = model.spectral["deltaTheta"][k][j];
                            double powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                            fitur.Add(powerDiff);

                            val1 = model.spectral["alpha"][k][i];
                            val2 = model.spectral["alpha"][k][j];
                            powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                            fitur.Add(powerDiff);

                            val1 = model.spectral["beta"][k][i];
                            val2 = model.spectral["beta"][k][j];
                            powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                            fitur.Add(powerDiff);

                            val1 = model.spectral["gamma"][k][i];
                            val2 = model.spectral["gamma"][k][j];
                            powerDiff = Math.Abs((val1 - val2) / (val1 + val2));
                            fitur.Add(powerDiff);
                        }
                    }
                }

                if ((k + 1) % bufferDecision == 0)
                {
                    //MessageBox.Show(fitur.Count.ToString());
                    model.features.Add(fitur);
                    fitur = new List<double>();
                }
            }

            model.SetFeatureClass();

            //MessageBox.Show(model.features.Count.ToString());
        }

        private List<double[]> BrowseData(string className)
        {
            List<double[]> dataEeg = new List<double[]>();
            int IIR_TC = 256;
            string[] eegDataFromFile;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EEG File (*.csv)|*.csv";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    textBoxClasses[className].Text = ofd.FileName;
                    eegDataFromFile = File.ReadAllLines(ofd.FileName);
                    int totalRecordsData = 128 * 5;
                    
                    double[] back = new double[14];
                    string[] firstRecord = eegDataFromFile[1].Split(',');
                    for (int i = 0; i < 14; i++)
                    {
                        back[i] = double.Parse(firstRecord[i + 2]);
                    }

                    double value;
                    for (int i = 0; i < totalRecordsData; i++)
                    {
                        string[] record = eegDataFromFile[i + 2].Split(',');
                        double[] data = new double[14];
                        for (int j = 0; j < 14; j++)
                        {
                            value = double.Parse(record[j + 2]);
                            back[j] = (back[j] * (IIR_TC - 1) + value) / IIR_TC; // IIR filter
                            data[j] = value - back[j]; // remove DC offset 
                        }
                        dataEeg.Add(data);
                    }

                }
                catch (IOException)
                {
                    MessageBox.Show("Error! File is already open by another program.");
                }
            }

            return ConstructSelectedChannels(dataEeg, className);
        }

        private List<double[]> ConstructSelectedChannels(List<double[]> input, string className)
        {
            List<double[]> selectedChannelData = new List<double[]>();
            int totalChannels = model.GetTotalSelectedChannels();
            double[] data;
            int index;
            for (int i=0;i<input.Count;i++)
            {
                data = new double[totalChannels];
                model.correctClass.Add(classesIndex[className]);
                index = 0;
                for (int j=0;j<14;j++)
                {
                    if(model.channels[channelsEeg[j]])
                    {
                        data[index] = input[i][j];
                        index++;
                    }
                }
                selectedChannelData.Add(data);
            }

            
            return selectedChannelData;
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            bool canTrain = true;
            for (int i = 0; i < model.classes.Count; i++)
            {
                if (model.classes[classesCommand[i]] && !classesDataLoaded[classesCommand[i]])
                    canTrain = false;
            }

            if (!canTrain)
                MessageBox.Show("Masih ada data set kelas yang belum dicari");
            else
            {
                buttonPhase2.Enabled = false;
                groupBoxLoadDataSet.Enabled = false;
                buttonTrain.Enabled = false;
                 
                model.SetChanelsIndex();
                for (int i = 0; i < allData.Count; i++)
                {
                    if (model.classes[classesCommand[i]])
                        model.dataTraining.AddRange(allData[i]);
                }

                labelDetailModel.Text = model.ToString();
                CalculateFeature();
                //MessageBox.Show(model.dataTraining[0].Count().ToString());
                progressBarModel.Value = 0;
                timerProgress.Enabled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.channels["AF3"].ToString());
        }

        private void checkBoxAF3_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["AF3"] = checkBoxAF3.Checked;
        }

        private void checkBoxF7_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["F7"] = checkBoxF7.Checked;
        }

        private void checkBoxF3_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["F3"] = checkBoxF3.Checked;
        }

        private void checkBoxFC5_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["FC5"] = checkBoxFC5.Checked;
        }

        private void checkBoxT7_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["T7"] = checkBoxT7.Checked;
        }

        private void checkBoxP7_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["P7"] = checkBoxP7.Checked;
        }

        private void checkBoxO1_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["O1"] = checkBoxO1.Checked;
        }

        private void checkBoxO2_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["O2"] = checkBoxO2.Checked;
        }

        private void checkBoxP8_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["P8"] = checkBoxP8.Checked;
        }

        private void checkBoxT8_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["T8"] = checkBoxT8.Checked;
        }

        private void checkBoxFC6_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["FC6"] = checkBoxFC6.Checked;
        }

        private void checkBoxF4_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["F4"] = checkBoxF4.Checked;
        }

        private void checkBoxF8_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["F8"] = checkBoxF8.Checked;
        }

        private void checkBoxAF4_CheckedChanged(object sender, EventArgs e)
        {
            model.channels["AF4"] = checkBoxAF4.Checked;
        }

        private void checkBoxNetral_CheckedChanged(object sender, EventArgs e)
        {
            model.classes["netral"] = checkBoxNetral.Checked;
        }

        private void checkBoxMaju_CheckedChanged(object sender, EventArgs e)
        {
            model.classes["maju"] = checkBoxMaju.Checked;
        }

        private void checkBoxMundur_CheckedChanged(object sender, EventArgs e)
        {
            model.classes["mundur"] = checkBoxMundur.Checked;
        }

        private void checkBoxKanan_CheckedChanged(object sender, EventArgs e)
        {
            model.classes["kanan"] = checkBoxKanan.Checked;
        }

        private void checkBoxKiri_CheckedChanged(object sender, EventArgs e)
        {
            model.classes["kiri"] = checkBoxKiri.Checked;
        }

        private void buttonLoadNetral_Click(object sender, EventArgs e)
        {
            allData[0] = BrowseData("netral");
            classesDataLoaded["netral"] = true;
        }

        private void buttonLoadMaju_Click(object sender, EventArgs e)
        {
            allData[1] = BrowseData("maju");
            classesDataLoaded["maju"] = true;
        }

        private void buttonLoadMundur_Click(object sender, EventArgs e)
        {
            allData[2] = BrowseData("mundur");
            classesDataLoaded["mundur"] = true;
        }

        private void buttonLoadKanan_Click(object sender, EventArgs e)
        {
            allData[3] = BrowseData("kanan");
            classesDataLoaded["kanan"] = true;
        }

        private void buttonLoadKiri_Click(object sender, EventArgs e)
        {
            allData[4] = BrowseData("kiri");
            classesDataLoaded["kiri"] = true;
        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            mainForm.LoadModelData();
            this.Close();
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if(progressBarModel.Value < progressBarModel.Maximum)
                progressBarModel.Value += 1;
            if (progressBarModel.Value == progressBarModel.Maximum)
            {
                
                timerProgress.Enabled = false;
                FormSaveModel f = new FormSaveModel(this);
                f.Show();
            }
        }

        public void SavingModel()
        {
            model.name = modelName;
            ms.SaveModel(model);
        }
    }
}
