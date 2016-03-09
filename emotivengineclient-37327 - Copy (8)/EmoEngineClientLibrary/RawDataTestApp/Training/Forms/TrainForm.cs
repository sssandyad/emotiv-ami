using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Accord.Statistics.Analysis;
using AForge.Neuro;
using AForge.Neuro.Learning;
using Eloquera.Client;
using RawDataTestApp.Algorithms;
using NLog;
using EmoEngineClientLibrary;
namespace RawDataTestApp
{
    public partial class TrainForm : Form
    {
        #region declarations 
        IFeatureGenerator fg;

        AMLearning model;

        EEGRecord currentRecord = new EEGRecord();

        private BackgroundWorker AsyncWorkerCalculate;

        private BackgroundWorker AsyncWorkerRecord;

        private BackgroundWorker AsyncWorkerSaveModel;

        private int LastRecodredFeatureVectorsCount;

        DateTime startCalculateModel;

        ModelStorage ms;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Increases after each recording. It is different from comboBoxSelectedClass.SelectedIndex
        /// </summary>
        /// 
        ClassifyForm classifyForm;

        System.IO.StreamReader file;
        int SelectedClassNumeric = 0;

        int recordTime;
        DateTime startRecord;
        System.Timers.Timer recordTimer;

        public TrainForm(ClassifyForm cf)
        {
            InitializeComponent();

            this.classifyForm = cf;

            ResetCheckBoxAction();

            comboBoxSelectedClass.SelectedIndex = 0;
            comboBoxRecordTime.SelectedIndex = 0;
			comboBoxRecordTime.SelectedIndexChanged += new EventHandler(comboBoxRecordTime_SelectedIndexChanged);

            recordTime = Convert.ToInt32(comboBoxRecordTime.Text);
            recordTimer = new System.Timers.Timer();
            recordTimer.Enabled = true;
            recordTimer.Interval = 1000;
            //progressBarRecord.Maximum = 100;
            //recordTimer.Elapsed += new System.Timers.ElapsedEventHandler(recordTimer_Elapsed);

            AsyncWorkerCalculate = new BackgroundWorker();
            AsyncWorkerCalculate.WorkerReportsProgress = true;
            AsyncWorkerCalculate.WorkerSupportsCancellation = true;
            AsyncWorkerCalculate.ProgressChanged += new ProgressChangedEventHandler(AsyncWorkerCalculate_ProgressChanged);
            AsyncWorkerCalculate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsyncWorkerCalculate_RunWorkerCompleted);
            AsyncWorkerCalculate.DoWork += new DoWorkEventHandler(AsyncWorkerCalculate_DoWork);

            AsyncWorkerRecord = new BackgroundWorker();
            AsyncWorkerRecord.WorkerReportsProgress = true;
            AsyncWorkerRecord.WorkerSupportsCancellation = true;
            AsyncWorkerRecord.ProgressChanged += new ProgressChangedEventHandler(AsyncWorkerRecord_ProgressChanged);
            AsyncWorkerRecord.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsyncWorkerRecord_RunWorkerCompleted);
            AsyncWorkerRecord.DoWork += new DoWorkEventHandler(AsyncWorkerRecord_DoWork);

            AsyncWorkerSaveModel = new BackgroundWorker();
            AsyncWorkerSaveModel.WorkerReportsProgress = true;
            AsyncWorkerSaveModel.WorkerSupportsCancellation = true;
            AsyncWorkerSaveModel.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsyncWorkerSaveModel_RunWorkerCompleted);
            AsyncWorkerSaveModel.DoWork += new DoWorkEventHandler(AsyncWorkerSaveModel_DoWork);

            ms = new ModelStorage();
            cbMethods.SelectedIndex = 0;

            //if (fg is OpenVibeFeatureGenerator)
                //listBoxLogger.Items.Insert(0, "You are required to wait until you see: \"Initialization took xxxxx ms\" in OpenVibe.");
        }

        void ResetCheckBoxAction()
        {
            checkBoxNeutral.Checked = false;
            checkBoxTurnRight.Checked = false;
            checkBoxTurnLeft.Checked = false;
            checkBoxForward.Checked = false;
            checkBoxBackward.Checked = false;
        }

		void comboBoxRecordTime_SelectedIndexChanged(object sender, EventArgs e)
		{
			recordTime = Convert.ToInt32(comboBoxRecordTime.Text);
		}

        void AsyncWorkerCalculate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarModelCalculation.Value = e.ProgressPercentage;
        }

        void AsyncWorkerSaveModel_DoWork(object sender, DoWorkEventArgs e)
        {
            ms.SaveModel(model);
        }

        void AsyncWorkerSaveModel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message + " " + e.Error.StackTrace);
                logger.Error(e.Error);
                listBoxLogger.Items.Insert(0, "Error saving model!");
            }
            else
            {
                listBoxLogger.Items.Insert(0, "Model '" + textBoxModelName.Text + "' saved.");
            }
            buttonSaveModel.Enabled = true;
            
        }

        void recordTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void AsyncWorkerRecord_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int i = 0; i < recordTime; i++)
            {
                int percentCompleted = (i * 100)/recordTime;
                //progressBarRecord.Value = percentCompleted;
            }
        }

        void SetCheckBoxAction(int index)
        {
            if(index==0)
            {
                checkBoxNeutral.Checked = true;
            }
            else if(index==1)
            {
                checkBoxTurnRight.Checked = true;
            }
            else if (index == 2)
            {
                checkBoxTurnLeft.Checked = true;
            }
            else if (index == 3)
            {
                checkBoxForward.Checked = true;
            }
            else if (index == 4)
            {
                checkBoxBackward.Checked = true;
            }
        }

        void AsyncWorkerRecord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message + " " + e.Error.StackTrace);
                logger.Error(e.Error);
                listBoxLogger.Items.Insert(0, "Error recording data!");
            }
            else
            {
                listBoxLogger.Items.Insert(0, "Recording completed. " + LastRecodredFeatureVectorsCount.ToString() + " additional vectors acquired.");
                SetCheckBoxAction(comboBoxSelectedClass.SelectedIndex);
            }
            buttonRecordAction.Enabled = true;
        }

        void AsyncWorkerRecord_DoWork(object sender, DoWorkEventArgs e)
        {

            LastRecodredFeatureVectorsCount = 0;

            startRecord = DateTime.Now;
            recordTimer.Start();

            double[] result = new double[15];
            for (int k = 0; k < this.recordTime * 128; k++)
            {
                string[] columns = this.file.ReadLine().Split(',');
                result[0] = SelectedClassNumeric;
                for (int i = 1; i < 15; i++)
                    result[i] = double.Parse(columns[i + 2], System.Globalization.CultureInfo.InvariantCulture);
                currentRecord.FeatureVectorsOutputInput.Add(result);
                LastRecodredFeatureVectorsCount++;
                //progressBarRecord.Value = LastRecodredFeatureVectorsCount * 100 / (this.recordTime * 128);
                //Console.WriteLine("count: " + LastRecodredFeatureVectorsCount);
            }
        }

        void recordTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeSpan elapsedTime = e.SignalTime - startRecord;

            if (elapsedTime.TotalMilliseconds >= (recordTime * 1000))
            {
                recordTimer.Stop();
                AsyncWorkerRecord.CancelAsync();
            }
            else
            {
                int percentCompleted = Convert.ToInt32((elapsedTime.TotalMilliseconds / (recordTime * 1000)) * 100);
                //ReportProgress(percentCompleted);
            }
        }

        void AsyncWorkerCalculate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startCalculateModel;
            string elapsedTime = elapsed.Hours + " hour(s), " + elapsed.Minutes + " minute(s), " + elapsed.Seconds + " second(s), " + elapsed.Milliseconds + " millisecond(s).";

            if (e.Error != null)
            {
                if (e.Error is InvalidRecordException)
                    MessageBox.Show(e.Error.Message,"Error");
                else MessageBox.Show(e.Error.Message + " " + e.Error.StackTrace, "Error");
                logger.Error(e.Error);
                listBoxLogger.Items.Insert(0, "Calculating model has been aborted! Time elapsed: " + elapsedTime);
            }
            else
            {
                listBoxLogger.Items.Insert(0, "Calculating model has completed successfully. Time elapsed: " + elapsedTime);
            }
            buttonCalculate.Enabled = true;
        }

        void AsyncWorkerCalculate_DoWork(object sender, DoWorkEventArgs e)
        {
			model.Train(currentRecord);
        }

        void model_Progress(int progress)
        {
            AsyncWorkerCalculate.ReportProgress(progress); 
        }

        private void buttonRecordAction_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxSelectedClass.SelectedIndex.ToString());

            if (file == null) return;

            if (AsyncWorkerRecord.IsBusy)
            {
                buttonRecordAction.Enabled = false;

                AsyncWorkerRecord.CancelAsync();
            }
            else
            {

                string ClassName = comboBoxSelectedClass.Items[comboBoxSelectedClass.SelectedIndex].ToString();

                if (!currentRecord.actions.Keys.Contains(ClassName))
                {
                    if (currentRecord.actions.Count == 0) SelectedClassNumeric = 1;
                    else SelectedClassNumeric = currentRecord.actions.Values.Max() + 1; //choose a new class (not yet used)

                    currentRecord.actions.Add(ClassName, SelectedClassNumeric);
                }
                else
                {   //user already recorded for this class
                    SelectedClassNumeric = currentRecord.actions[ClassName];
                }

                listBoxLogger.Items.Insert(0, "Recoding data for action \"" + comboBoxSelectedClass.Text + "\" (class " + SelectedClassNumeric + ").");

                AsyncWorkerRecord.RunWorkerAsync();

                
            }


            //else
            //{
            //    buttonRecordAction.Enabled = false;

            //    string ClassName = comboBoxSelectedClass.Items[comboBoxSelectedClass.SelectedIndex].ToString();

            //    if (!currentRecord.actions.Keys.Contains(ClassName))
            //    {
            //        if (currentRecord.actions.Count == 0) SelectedClassNumeric = 1;
            //        else SelectedClassNumeric = currentRecord.actions.Values.Max() + 1; //choose a new class (not yet used)

            //        currentRecord.actions.Add(ClassName, SelectedClassNumeric);
            //    }
            //    else
            //    {   //user already recorded for this class
            //        SelectedClassNumeric = currentRecord.actions[ClassName];
            //    }

            //    listBoxLogger.Items.Insert(0, "Recoding data for action \"" + comboBoxSelectedClass.Text + "\" (class " + SelectedClassNumeric + ").");

            //    AsyncWorkerRecord.RunWorkerAsync();
            //}
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //if (AsyncWorkerCalculate.IsBusy)
            //{
            //    buttonCalculate.Enabled = false;

            //    AsyncWorkerCalculate.CancelAsync();
            //}
            //else //start new process
            {
                listBoxLogger.Items.Insert(0,"Creating machine learning model to be used for classification...");
                if (currentRecord.FeatureVectorsOutputInput.Count == 0) { MessageBox.Show("First you need to record/load some data for specific action!"); return; }

                //MessageBox.Show(this.)

                //buttonCalculate.Enabled = false;
                //buttonCalculate.Text = "Cancel";
                //startCalculateModel = DateTime.Now;

                switch (cbMethods.SelectedIndex)
                {
                        


                    case 0: model = new LdaSVM("Support vector machines"); break;
                    case 1: model = new LdaMLP("Multi-layer perceptron with backpropagation as learning method"); break;
                    case 2: model = new LdaRBF("Radial basis function with resilient propagation as learning method"); break;
                    //case 3: model = new OctaveMulticlassLogisticRegression("omlr"); break;
                }
                model.ActionList = currentRecord.actions;
                model.Progress += new ChangedValuesEventHandler(model_Progress);

                AsyncWorkerCalculate.RunWorkerAsync();

            }
        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            if (AsyncWorkerCalculate.IsBusy)
            {
                buttonSaveModel.Enabled = false;

                AsyncWorkerSaveModel.CancelAsync();
            }
            else
            {
                listBoxLogger.Items.Insert(0, "Saving model ... please wait!");

                if (textBoxModelName.Text.Length == 0)
                { MessageBox.Show("Please enter model name!"); return; }

                if (model == null)
                { MessageBox.Show("You need to calculate model first!"); return; }

                buttonSaveModel.Enabled = false;

                model.Name = textBoxModelName.Text;
                model.ActionList = currentRecord.actions;

                AsyncWorkerSaveModel.RunWorkerAsync();
            }
        }

        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            this.classifyForm.RefreshData();
            this.Close();
        }

        private void buttonManageRecordings_Click(object sender, EventArgs e)
        {
        }

        void rd_ReocordSelected(EEGRecord selectedRecord)
        {
            currentRecord = new EEGRecord(selectedRecord);//create a copy
            listBoxLogger.Items.Insert(0, "Pre-recorded data '" + selectedRecord.Name + "' has been loaded containing: "+currentRecord.FeatureVectorsOutputInput.Count+" feature vectors. You can now record additional data or start 'Computing'.");
        }

        private void buttonClearRecord_Click(object sender, EventArgs e)
        {
            currentRecord = new EEGRecord();
            ResetCheckBoxAction();
			listBoxLogger.Items.Insert(0, "Recorded data cleared. Now you can record or load data.");

        }

        private void TrainForm_Load(object sender, EventArgs e)
        {

        }

        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult result = fo.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    textBoxEmotivFile.Text = fo.FileName;
                    this.file = new System.IO.StreamReader(textBoxEmotivFile.Text);
                    file.ReadLine();//skip one line


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            } 

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            foreach (double[] vector in currentRecord.FeatureVectorsOutputInput)
            {
                double[] input = new double[vector.Length - 1];
                Array.Copy(vector, 1, input, 0, vector.Length - 1);

                int result = model.Classify(input);
                if (result == vector[0])
                    listBoxLogger.Items.Insert(0, result + " " + vector[0] + " OK");
                else
                    listBoxLogger.Items.Insert(0, result + " " + vector[0] + " Wrong");
            }
        }

        
    }
}
