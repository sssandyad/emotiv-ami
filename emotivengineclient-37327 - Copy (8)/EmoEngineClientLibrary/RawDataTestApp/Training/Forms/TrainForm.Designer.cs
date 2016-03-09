namespace RawDataTestApp
{
    partial class TrainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRecordAction = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.comboBoxSelectedClass = new System.Windows.Forms.ComboBox();
            this.textBoxModelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.comboBoxRecordTime = new System.Windows.Forms.ComboBox();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.progressBarModelCalculation = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxLogger = new System.Windows.Forms.ListBox();
            this.buttonClearRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmotivFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMethods = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxNeutral = new System.Windows.Forms.CheckBox();
            this.checkBoxTurnRight = new System.Windows.Forms.CheckBox();
            this.checkBoxTurnLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxForward = new System.Windows.Forms.CheckBox();
            this.checkBoxBackward = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRecordAction
            // 
            this.buttonRecordAction.Location = new System.Drawing.Point(392, 122);
            this.buttonRecordAction.Name = "buttonRecordAction";
            this.buttonRecordAction.Size = new System.Drawing.Size(102, 23);
            this.buttonRecordAction.TabIndex = 1;
            this.buttonRecordAction.Text = "Record action";
            this.buttonRecordAction.UseVisualStyleBackColor = true;
            this.buttonRecordAction.Click += new System.EventHandler(this.buttonRecordAction_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.Location = new System.Drawing.Point(13, 56);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(481, 47);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Compute";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // comboBoxSelectedClass
            // 
            this.comboBoxSelectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedClass.FormattingEnabled = true;
            this.comboBoxSelectedClass.Items.AddRange(new object[] {
            "Neutral",
            "Turn Left",
            "Turn Right",
            "Forward",
            "Backward"});
            this.comboBoxSelectedClass.Location = new System.Drawing.Point(342, 62);
            this.comboBoxSelectedClass.Name = "comboBoxSelectedClass";
            this.comboBoxSelectedClass.Size = new System.Drawing.Size(153, 21);
            this.comboBoxSelectedClass.TabIndex = 3;
            // 
            // textBoxModelName
            // 
            this.textBoxModelName.Location = new System.Drawing.Point(81, 162);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new System.Drawing.Size(215, 20);
            this.textBoxModelName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Model name:";
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.Location = new System.Drawing.Point(408, 549);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(96, 27);
            this.buttonCloseForm.TabIndex = 10;
            this.buttonCloseForm.Text = "Close";
            this.buttonCloseForm.UseVisualStyleBackColor = true;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // comboBoxRecordTime
            // 
            this.comboBoxRecordTime.FormattingEnabled = true;
            this.comboBoxRecordTime.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.comboBoxRecordTime.Location = new System.Drawing.Point(213, 62);
            this.comboBoxRecordTime.Name = "comboBoxRecordTime";
            this.comboBoxRecordTime.Size = new System.Drawing.Size(45, 21);
            this.comboBoxRecordTime.TabIndex = 11;
            // 
            // buttonSaveModel
            // 
            this.buttonSaveModel.Location = new System.Drawing.Point(313, 160);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(80, 23);
            this.buttonSaveModel.TabIndex = 13;
            this.buttonSaveModel.Text = "Save";
            this.buttonSaveModel.UseVisualStyleBackColor = true;
            this.buttonSaveModel.Click += new System.EventHandler(this.buttonSaveModel_Click);
            // 
            // progressBarModelCalculation
            // 
            this.progressBarModelCalculation.Location = new System.Drawing.Point(13, 121);
            this.progressBarModelCalculation.Name = "progressBarModelCalculation";
            this.progressBarModelCalculation.Size = new System.Drawing.Size(481, 23);
            this.progressBarModelCalculation.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Action:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Record time (s):";
            // 
            // listBoxLogger
            // 
            this.listBoxLogger.FormattingEnabled = true;
            this.listBoxLogger.Location = new System.Drawing.Point(6, 14);
            this.listBoxLogger.Name = "listBoxLogger";
            this.listBoxLogger.Size = new System.Drawing.Size(489, 134);
            this.listBoxLogger.TabIndex = 21;
            // 
            // buttonClearRecord
            // 
            this.buttonClearRecord.Location = new System.Drawing.Point(299, 122);
            this.buttonClearRecord.Name = "buttonClearRecord";
            this.buttonClearRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonClearRecord.TabIndex = 23;
            this.buttonClearRecord.Text = "Clear";
            this.buttonClearRecord.UseVisualStyleBackColor = true;
            this.buttonClearRecord.Click += new System.EventHandler(this.buttonClearRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxBackward);
            this.groupBox1.Controls.Add(this.checkBoxForward);
            this.groupBox1.Controls.Add(this.checkBoxTurnLeft);
            this.groupBox1.Controls.Add(this.checkBoxTurnRight);
            this.groupBox1.Controls.Add(this.checkBoxNeutral);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxEmotivFile);
            this.groupBox1.Controls.Add(this.comboBoxSelectedClass);
            this.groupBox1.Controls.Add(this.buttonClearRecord);
            this.groupBox1.Controls.Add(this.buttonRecordAction);
            this.groupBox1.Controls.Add(this.comboBoxRecordTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 158);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(419, 21);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 27;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "File path:";
            // 
            // textBoxEmotivFile
            // 
            this.textBoxEmotivFile.Location = new System.Drawing.Point(180, 23);
            this.textBoxEmotivFile.Name = "textBoxEmotivFile";
            this.textBoxEmotivFile.Size = new System.Drawing.Size(226, 20);
            this.textBoxEmotivFile.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTest);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbMethods);
            this.groupBox2.Controls.Add(this.buttonCalculate);
            this.groupBox2.Controls.Add(this.progressBarModelCalculation);
            this.groupBox2.Controls.Add(this.buttonSaveModel);
            this.groupBox2.Controls.Add(this.textBoxModelName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 202);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model (training)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Algorithm:";
            // 
            // cbMethods
            // 
            this.cbMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethods.FormattingEnabled = true;
            this.cbMethods.Items.AddRange(new object[] {
            "Support vector machines",
            "Multi-layer perceptron with backpropagation as learning method",
            "Radial basis function with resilient propagation as learning method"});
            this.cbMethods.Location = new System.Drawing.Point(69, 20);
            this.cbMethods.Name = "cbMethods";
            this.cbMethods.Size = new System.Drawing.Size(425, 21);
            this.cbMethods.TabIndex = 19;
            this.cbMethods.SelectedIndexChanged += new System.EventHandler(this.cbMethods_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxLogger);
            this.groupBox3.Location = new System.Drawing.Point(9, 384);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 159);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // checkBoxNeutral
            // 
            this.checkBoxNeutral.AutoSize = true;
            this.checkBoxNeutral.Location = new System.Drawing.Point(13, 23);
            this.checkBoxNeutral.Name = "checkBoxNeutral";
            this.checkBoxNeutral.Size = new System.Drawing.Size(60, 17);
            this.checkBoxNeutral.TabIndex = 28;
            this.checkBoxNeutral.Text = "Neutral";
            this.checkBoxNeutral.UseVisualStyleBackColor = true;
            // 
            // checkBoxTurnRight
            // 
            this.checkBoxTurnRight.AutoSize = true;
            this.checkBoxTurnRight.Location = new System.Drawing.Point(13, 46);
            this.checkBoxTurnRight.Name = "checkBoxTurnRight";
            this.checkBoxTurnRight.Size = new System.Drawing.Size(76, 17);
            this.checkBoxTurnRight.TabIndex = 29;
            this.checkBoxTurnRight.Text = "Turn Right";
            this.checkBoxTurnRight.UseVisualStyleBackColor = true;
            // 
            // checkBoxTurnLeft
            // 
            this.checkBoxTurnLeft.AutoSize = true;
            this.checkBoxTurnLeft.Location = new System.Drawing.Point(13, 69);
            this.checkBoxTurnLeft.Name = "checkBoxTurnLeft";
            this.checkBoxTurnLeft.Size = new System.Drawing.Size(69, 17);
            this.checkBoxTurnLeft.TabIndex = 30;
            this.checkBoxTurnLeft.Text = "Turn Left";
            this.checkBoxTurnLeft.UseVisualStyleBackColor = true;
            // 
            // checkBoxForward
            // 
            this.checkBoxForward.AutoSize = true;
            this.checkBoxForward.Location = new System.Drawing.Point(13, 92);
            this.checkBoxForward.Name = "checkBoxForward";
            this.checkBoxForward.Size = new System.Drawing.Size(64, 17);
            this.checkBoxForward.TabIndex = 31;
            this.checkBoxForward.Text = "Forward";
            this.checkBoxForward.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackward
            // 
            this.checkBoxBackward.AutoSize = true;
            this.checkBoxBackward.Location = new System.Drawing.Point(13, 115);
            this.checkBoxBackward.Name = "checkBoxBackward";
            this.checkBoxBackward.Size = new System.Drawing.Size(74, 17);
            this.checkBoxBackward.TabIndex = 32;
            this.checkBoxBackward.Text = "Backward";
            this.checkBoxBackward.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(414, 159);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(80, 23);
            this.btnTest.TabIndex = 21;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // TrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(531, 588);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCloseForm);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "TrainForm";
            this.Text = "Train";
            this.Load += new System.EventHandler(this.TrainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRecordAction;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ComboBox comboBoxSelectedClass;
        private System.Windows.Forms.TextBox textBoxModelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCloseForm;
        private System.Windows.Forms.ComboBox comboBoxRecordTime;
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.ProgressBar progressBarModelCalculation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxLogger;
        private System.Windows.Forms.Button buttonClearRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMethods;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmotivFile;
        private System.Windows.Forms.CheckBox checkBoxBackward;
        private System.Windows.Forms.CheckBox checkBoxForward;
        private System.Windows.Forms.CheckBox checkBoxTurnLeft;
        private System.Windows.Forms.CheckBox checkBoxTurnRight;
        private System.Windows.Forms.CheckBox checkBoxNeutral;
        private System.Windows.Forms.Button btnTest;

    }
}