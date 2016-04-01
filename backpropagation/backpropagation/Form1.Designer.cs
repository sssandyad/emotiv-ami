namespace backpropagation
{
    partial class form1
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
            this.tb_x1 = new System.Windows.Forms.TextBox();
            this.tb_y1 = new System.Windows.Forms.TextBox();
            this.tb_y2 = new System.Windows.Forms.TextBox();
            this.tb_x2 = new System.Windows.Forms.TextBox();
            this.tb_y3 = new System.Windows.Forms.TextBox();
            this.tb_x3 = new System.Windows.Forms.TextBox();
            this.tb_y4 = new System.Windows.Forms.TextBox();
            this.tb_x4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_wa = new System.Windows.Forms.TextBox();
            this.tb_wc = new System.Windows.Forms.TextBox();
            this.tb_wb = new System.Windows.Forms.TextBox();
            this.tb_hiddenLayer2 = new System.Windows.Forms.TextBox();
            this.tb_hiddenLayer1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxIterasi = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_x1
            // 
            this.tb_x1.Location = new System.Drawing.Point(40, 22);
            this.tb_x1.Name = "tb_x1";
            this.tb_x1.Size = new System.Drawing.Size(20, 20);
            this.tb_x1.TabIndex = 0;
            this.tb_x1.Text = "5";
            // 
            // tb_y1
            // 
            this.tb_y1.Location = new System.Drawing.Point(65, 22);
            this.tb_y1.Name = "tb_y1";
            this.tb_y1.Size = new System.Drawing.Size(20, 20);
            this.tb_y1.TabIndex = 1;
            this.tb_y1.Text = "5";
            // 
            // tb_y2
            // 
            this.tb_y2.Location = new System.Drawing.Point(65, 48);
            this.tb_y2.Name = "tb_y2";
            this.tb_y2.Size = new System.Drawing.Size(20, 20);
            this.tb_y2.TabIndex = 3;
            this.tb_y2.Text = "0";
            // 
            // tb_x2
            // 
            this.tb_x2.Location = new System.Drawing.Point(40, 48);
            this.tb_x2.Name = "tb_x2";
            this.tb_x2.Size = new System.Drawing.Size(20, 20);
            this.tb_x2.TabIndex = 2;
            this.tb_x2.Text = "0";
            // 
            // tb_y3
            // 
            this.tb_y3.Location = new System.Drawing.Point(65, 74);
            this.tb_y3.Name = "tb_y3";
            this.tb_y3.Size = new System.Drawing.Size(20, 20);
            this.tb_y3.TabIndex = 5;
            this.tb_y3.Text = "-5";
            // 
            // tb_x3
            // 
            this.tb_x3.Location = new System.Drawing.Point(40, 74);
            this.tb_x3.Name = "tb_x3";
            this.tb_x3.Size = new System.Drawing.Size(20, 20);
            this.tb_x3.TabIndex = 4;
            this.tb_x3.Text = "-3";
            // 
            // tb_y4
            // 
            this.tb_y4.Location = new System.Drawing.Point(65, 100);
            this.tb_y4.Name = "tb_y4";
            this.tb_y4.Size = new System.Drawing.Size(20, 20);
            this.tb_y4.TabIndex = 7;
            this.tb_y4.Text = "4";
            // 
            // tb_x4
            // 
            this.tb_x4.Location = new System.Drawing.Point(40, 100);
            this.tb_x4.Name = "tb_x4";
            this.tb_x4.Size = new System.Drawing.Size(20, 20);
            this.tb_x4.TabIndex = 6;
            this.tb_x4.Text = "-5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "#1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "#2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "#3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "#4";
            // 
            // tb_wa
            // 
            this.tb_wa.Location = new System.Drawing.Point(217, 124);
            this.tb_wa.Name = "tb_wa";
            this.tb_wa.Size = new System.Drawing.Size(49, 20);
            this.tb_wa.TabIndex = 13;
            this.tb_wa.Text = "0.1";
            // 
            // tb_wc
            // 
            this.tb_wc.Location = new System.Drawing.Point(685, 124);
            this.tb_wc.Name = "tb_wc";
            this.tb_wc.Size = new System.Drawing.Size(49, 20);
            this.tb_wc.TabIndex = 14;
            this.tb_wc.Text = "0.1";
            // 
            // tb_wb
            // 
            this.tb_wb.Location = new System.Drawing.Point(447, 124);
            this.tb_wb.Name = "tb_wb";
            this.tb_wb.Size = new System.Drawing.Size(49, 20);
            this.tb_wb.TabIndex = 15;
            this.tb_wb.Text = "0.1";
            // 
            // tb_hiddenLayer2
            // 
            this.tb_hiddenLayer2.Location = new System.Drawing.Point(561, 157);
            this.tb_hiddenLayer2.Name = "tb_hiddenLayer2";
            this.tb_hiddenLayer2.Size = new System.Drawing.Size(47, 20);
            this.tb_hiddenLayer2.TabIndex = 16;
            this.tb_hiddenLayer2.Text = "3";
            // 
            // tb_hiddenLayer1
            // 
            this.tb_hiddenLayer1.Location = new System.Drawing.Point(328, 157);
            this.tb_hiddenLayer1.Name = "tb_hiddenLayer1";
            this.tb_hiddenLayer1.Size = new System.Drawing.Size(47, 20);
            this.tb_hiddenLayer1.TabIndex = 17;
            this.tb_hiddenLayer1.Text = "3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(317, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 159);
            this.panel1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "hidden layer 1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSalmon;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(545, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(84, 159);
            this.panel2.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "hidden layer 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Wa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(456, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Wb";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(699, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Wc";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSalmon;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(753, 183);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 159);
            this.panel3.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "output";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSalmon;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(113, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(84, 159);
            this.panel4.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "input";
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(753, 22);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(100, 20);
            this.textBoxError.TabIndex = 24;
            this.textBoxError.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(717, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "MSE";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "iterasi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxRate
            // 
            this.textBoxRate.Location = new System.Drawing.Point(317, 22);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(40, 20);
            this.textBoxRate.TabIndex = 27;
            this.textBoxRate.Text = "0.01";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(246, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "learning rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(314, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "jumlah variabel";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(542, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "jumlah variabel";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(444, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "iterasi ke";
            // 
            // textBoxIterasi
            // 
            this.textBoxIterasi.Location = new System.Drawing.Point(499, 19);
            this.textBoxIterasi.Name = "textBoxIterasi";
            this.textBoxIterasi.Size = new System.Drawing.Size(49, 20);
            this.textBoxIterasi.TabIndex = 32;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 439);
            this.Controls.Add(this.textBoxIterasi);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_hiddenLayer1);
            this.Controls.Add(this.tb_hiddenLayer2);
            this.Controls.Add(this.tb_wb);
            this.Controls.Add(this.tb_wc);
            this.Controls.Add(this.tb_wa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_y4);
            this.Controls.Add(this.tb_x4);
            this.Controls.Add(this.tb_y3);
            this.Controls.Add(this.tb_x3);
            this.Controls.Add(this.tb_y2);
            this.Controls.Add(this.tb_x2);
            this.Controls.Add(this.tb_y1);
            this.Controls.Add(this.tb_x1);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_x1;
        private System.Windows.Forms.TextBox tb_y1;
        private System.Windows.Forms.TextBox tb_y2;
        private System.Windows.Forms.TextBox tb_x2;
        private System.Windows.Forms.TextBox tb_y3;
        private System.Windows.Forms.TextBox tb_x3;
        private System.Windows.Forms.TextBox tb_y4;
        private System.Windows.Forms.TextBox tb_x4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_wa;
        private System.Windows.Forms.TextBox tb_wc;
        private System.Windows.Forms.TextBox tb_wb;
        private System.Windows.Forms.TextBox tb_hiddenLayer2;
        private System.Windows.Forms.TextBox tb_hiddenLayer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxIterasi;
    }
}

