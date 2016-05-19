﻿namespace EEG_EMOTIV_CONTROLLER
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.labelMovement = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.chartEeg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonCreateModel = new System.Windows.Forms.Button();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.groupBoxModel = new System.Windows.Forms.GroupBox();
            this.labelDetailModel = new System.Windows.Forms.Label();
            this.buttonMaju = new System.Windows.Forms.Button();
            this.buttonKiri = new System.Windows.Forms.Button();
            this.buttonKanan = new System.Windows.Forms.Button();
            this.buttonNetral = new System.Windows.Forms.Button();
            this.buttonMundur = new System.Windows.Forms.Button();
            this.chartGamma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBeta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAlpha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDeltaTheta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxChannels = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartEeg)).BeginInit();
            this.groupBoxModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeltaTheta)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMovement
            // 
            this.labelMovement.AutoSize = true;
            this.labelMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovement.ForeColor = System.Drawing.Color.Crimson;
            this.labelMovement.Location = new System.Drawing.Point(103, 443);
            this.labelMovement.Name = "labelMovement";
            this.labelMovement.Size = new System.Drawing.Size(122, 42);
            this.labelMovement.TabIndex = 0;
            this.labelMovement.Text = "Lucky";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 17);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "open file";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // chartEeg
            // 
            this.chartEeg.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chartEeg.Legends.Add(legend1);
            this.chartEeg.Location = new System.Drawing.Point(371, 26);
            this.chartEeg.Name = "chartEeg";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEeg.Series.Add(series1);
            this.chartEeg.Size = new System.Drawing.Size(690, 120);
            this.chartEeg.TabIndex = 2;
            this.chartEeg.Text = "Gelombang EEG";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 46);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonCreateModel
            // 
            this.buttonCreateModel.Location = new System.Drawing.Point(226, 17);
            this.buttonCreateModel.Name = "buttonCreateModel";
            this.buttonCreateModel.Size = new System.Drawing.Size(121, 23);
            this.buttonCreateModel.TabIndex = 4;
            this.buttonCreateModel.Text = "create model";
            this.buttonCreateModel.UseVisualStyleBackColor = true;
            this.buttonCreateModel.Click += new System.EventHandler(this.buttonCreateModel_Click);
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(226, 46);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModel.TabIndex = 5;
            this.comboBoxModel.Text = "        <pilih model>";
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            // 
            // groupBoxModel
            // 
            this.groupBoxModel.Controls.Add(this.labelDetailModel);
            this.groupBoxModel.Location = new System.Drawing.Point(12, 85);
            this.groupBoxModel.Name = "groupBoxModel";
            this.groupBoxModel.Size = new System.Drawing.Size(335, 159);
            this.groupBoxModel.TabIndex = 21;
            this.groupBoxModel.TabStop = false;
            this.groupBoxModel.Text = "model";
            // 
            // labelDetailModel
            // 
            this.labelDetailModel.AutoSize = true;
            this.labelDetailModel.Location = new System.Drawing.Point(22, 32);
            this.labelDetailModel.Name = "labelDetailModel";
            this.labelDetailModel.Size = new System.Drawing.Size(63, 13);
            this.labelDetailModel.TabIndex = 2;
            this.labelDetailModel.Text = "detail model";
            // 
            // buttonMaju
            // 
            this.buttonMaju.Location = new System.Drawing.Point(122, 275);
            this.buttonMaju.Name = "buttonMaju";
            this.buttonMaju.Size = new System.Drawing.Size(75, 23);
            this.buttonMaju.TabIndex = 22;
            this.buttonMaju.Text = "maju";
            this.buttonMaju.UseVisualStyleBackColor = true;
            // 
            // buttonKiri
            // 
            this.buttonKiri.Location = new System.Drawing.Point(22, 312);
            this.buttonKiri.Name = "buttonKiri";
            this.buttonKiri.Size = new System.Drawing.Size(75, 23);
            this.buttonKiri.TabIndex = 23;
            this.buttonKiri.Text = "kiri";
            this.buttonKiri.UseVisualStyleBackColor = true;
            // 
            // buttonKanan
            // 
            this.buttonKanan.Location = new System.Drawing.Point(219, 312);
            this.buttonKanan.Name = "buttonKanan";
            this.buttonKanan.Size = new System.Drawing.Size(75, 23);
            this.buttonKanan.TabIndex = 24;
            this.buttonKanan.Text = "kanan";
            this.buttonKanan.UseVisualStyleBackColor = true;
            // 
            // buttonNetral
            // 
            this.buttonNetral.Location = new System.Drawing.Point(122, 312);
            this.buttonNetral.Name = "buttonNetral";
            this.buttonNetral.Size = new System.Drawing.Size(75, 23);
            this.buttonNetral.TabIndex = 25;
            this.buttonNetral.Text = "netral";
            this.buttonNetral.UseVisualStyleBackColor = true;
            // 
            // buttonMundur
            // 
            this.buttonMundur.Location = new System.Drawing.Point(122, 353);
            this.buttonMundur.Name = "buttonMundur";
            this.buttonMundur.Size = new System.Drawing.Size(75, 23);
            this.buttonMundur.TabIndex = 26;
            this.buttonMundur.Text = "mundur";
            this.buttonMundur.UseVisualStyleBackColor = true;
            // 
            // chartGamma
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGamma.ChartAreas.Add(chartArea1);
            legend2.Name = "Legend1";
            this.chartGamma.Legends.Add(legend2);
            this.chartGamma.Location = new System.Drawing.Point(371, 588);
            this.chartGamma.Name = "chartGamma";
            this.chartGamma.Size = new System.Drawing.Size(690, 120);
            this.chartGamma.TabIndex = 27;
            this.chartGamma.Text = "chart1";
            // 
            // chartBeta
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBeta.ChartAreas.Add(chartArea2);
            legend3.Name = "Legend1";
            this.chartBeta.Legends.Add(legend3);
            this.chartBeta.Location = new System.Drawing.Point(371, 462);
            this.chartBeta.Name = "chartBeta";
            this.chartBeta.Size = new System.Drawing.Size(690, 120);
            this.chartBeta.TabIndex = 28;
            this.chartBeta.Text = "chart2";
            // 
            // chartAlpha
            // 
            chartArea3.Name = "ChartArea1";
            this.chartAlpha.ChartAreas.Add(chartArea3);
            legend4.Name = "Legend1";
            this.chartAlpha.Legends.Add(legend4);
            this.chartAlpha.Location = new System.Drawing.Point(371, 336);
            this.chartAlpha.Name = "chartAlpha";
            this.chartAlpha.Size = new System.Drawing.Size(690, 120);
            this.chartAlpha.TabIndex = 29;
            this.chartAlpha.Text = "chart3";
            // 
            // chartDeltaTheta
            // 
            chartArea4.Name = "ChartArea1";
            this.chartDeltaTheta.ChartAreas.Add(chartArea4);
            legend5.Name = "Legend1";
            this.chartDeltaTheta.Legends.Add(legend5);
            this.chartDeltaTheta.Location = new System.Drawing.Point(371, 210);
            this.chartDeltaTheta.Name = "chartDeltaTheta";
            this.chartDeltaTheta.Size = new System.Drawing.Size(690, 120);
            this.chartDeltaTheta.TabIndex = 30;
            this.chartDeltaTheta.Text = "chart4";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(940, 183);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChannels.TabIndex = 31;
            this.comboBoxChannels.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannels_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(1084, 728);
            this.Controls.Add(this.comboBoxChannels);
            this.Controls.Add(this.chartDeltaTheta);
            this.Controls.Add(this.chartAlpha);
            this.Controls.Add(this.chartBeta);
            this.Controls.Add(this.chartGamma);
            this.Controls.Add(this.buttonMundur);
            this.Controls.Add(this.buttonNetral);
            this.Controls.Add(this.buttonKanan);
            this.Controls.Add(this.buttonKiri);
            this.Controls.Add(this.buttonMaju);
            this.Controls.Add(this.groupBoxModel);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.buttonCreateModel);
            this.Controls.Add(this.chartEeg);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.labelMovement);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEeg)).EndInit();
            this.groupBoxModel.ResumeLayout(false);
            this.groupBoxModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeltaTheta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMovement;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEeg;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonCreateModel;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.GroupBox groupBoxModel;
        private System.Windows.Forms.Label labelDetailModel;
        private System.Windows.Forms.Button buttonMaju;
        private System.Windows.Forms.Button buttonKiri;
        private System.Windows.Forms.Button buttonKanan;
        private System.Windows.Forms.Button buttonNetral;
        private System.Windows.Forms.Button buttonMundur;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGamma;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBeta;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAlpha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDeltaTheta;
        private System.Windows.Forms.ComboBox comboBoxChannels;
    }
}

