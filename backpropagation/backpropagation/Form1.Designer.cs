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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxOutputY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxOutputX = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxInputY = new System.Windows.Forms.TextBox();
            this.textBoxInputX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonFast = new System.Windows.Forms.Button();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxIterasi = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxRandom = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_x1
            // 
            this.tb_x1.Location = new System.Drawing.Point(50, 33);
            this.tb_x1.Name = "tb_x1";
            this.tb_x1.Size = new System.Drawing.Size(20, 20);
            this.tb_x1.TabIndex = 0;
            this.tb_x1.Text = "5";
            // 
            // tb_y1
            // 
            this.tb_y1.Location = new System.Drawing.Point(75, 33);
            this.tb_y1.Name = "tb_y1";
            this.tb_y1.Size = new System.Drawing.Size(20, 20);
            this.tb_y1.TabIndex = 1;
            this.tb_y1.Text = "5";
            // 
            // tb_y2
            // 
            this.tb_y2.Location = new System.Drawing.Point(75, 59);
            this.tb_y2.Name = "tb_y2";
            this.tb_y2.Size = new System.Drawing.Size(20, 20);
            this.tb_y2.TabIndex = 3;
            this.tb_y2.Text = "0";
            // 
            // tb_x2
            // 
            this.tb_x2.Location = new System.Drawing.Point(50, 59);
            this.tb_x2.Name = "tb_x2";
            this.tb_x2.Size = new System.Drawing.Size(20, 20);
            this.tb_x2.TabIndex = 2;
            this.tb_x2.Text = "0";
            // 
            // tb_y3
            // 
            this.tb_y3.Location = new System.Drawing.Point(75, 85);
            this.tb_y3.Name = "tb_y3";
            this.tb_y3.Size = new System.Drawing.Size(20, 20);
            this.tb_y3.TabIndex = 5;
            this.tb_y3.Text = "-5";
            // 
            // tb_x3
            // 
            this.tb_x3.Location = new System.Drawing.Point(50, 85);
            this.tb_x3.Name = "tb_x3";
            this.tb_x3.Size = new System.Drawing.Size(20, 20);
            this.tb_x3.TabIndex = 4;
            this.tb_x3.Text = "-3";
            // 
            // tb_y4
            // 
            this.tb_y4.Location = new System.Drawing.Point(75, 111);
            this.tb_y4.Name = "tb_y4";
            this.tb_y4.Size = new System.Drawing.Size(20, 20);
            this.tb_y4.TabIndex = 7;
            this.tb_y4.Text = "4";
            // 
            // tb_x4
            // 
            this.tb_x4.Location = new System.Drawing.Point(50, 111);
            this.tb_x4.Name = "tb_x4";
            this.tb_x4.Size = new System.Drawing.Size(20, 20);
            this.tb_x4.TabIndex = 6;
            this.tb_x4.Text = "-5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "#1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "#2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "#3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "#4";
            // 
            // tb_wa
            // 
            this.tb_wa.Location = new System.Drawing.Point(268, 302);
            this.tb_wa.Name = "tb_wa";
            this.tb_wa.Size = new System.Drawing.Size(49, 20);
            this.tb_wa.TabIndex = 13;
            this.tb_wa.Text = "0.1";
            // 
            // tb_wc
            // 
            this.tb_wc.Location = new System.Drawing.Point(718, 297);
            this.tb_wc.Name = "tb_wc";
            this.tb_wc.Size = new System.Drawing.Size(49, 20);
            this.tb_wc.TabIndex = 14;
            this.tb_wc.Text = "0.1";
            // 
            // tb_wb
            // 
            this.tb_wb.Location = new System.Drawing.Point(494, 297);
            this.tb_wb.Name = "tb_wb";
            this.tb_wb.Size = new System.Drawing.Size(49, 20);
            this.tb_wb.TabIndex = 15;
            this.tb_wb.Text = "0.1";
            // 
            // tb_hiddenLayer2
            // 
            this.tb_hiddenLayer2.Location = new System.Drawing.Point(595, 255);
            this.tb_hiddenLayer2.Name = "tb_hiddenLayer2";
            this.tb_hiddenLayer2.Size = new System.Drawing.Size(47, 20);
            this.tb_hiddenLayer2.TabIndex = 16;
            this.tb_hiddenLayer2.Text = "3";
            // 
            // tb_hiddenLayer1
            // 
            this.tb_hiddenLayer1.Location = new System.Drawing.Point(362, 255);
            this.tb_hiddenLayer1.Name = "tb_hiddenLayer1";
            this.tb_hiddenLayer1.Size = new System.Drawing.Size(47, 20);
            this.tb_hiddenLayer1.TabIndex = 17;
            this.tb_hiddenLayer1.Text = "3";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(51, 299);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 18;
            this.buttonPlay.Text = "play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(351, 281);
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
            this.panel2.Location = new System.Drawing.Point(579, 281);
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
            this.label7.Location = new System.Drawing.Point(280, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Wa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Wb";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(732, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Wc";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSalmon;
            this.panel3.Controls.Add(this.textBoxOutputY);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.textBoxOutputX);
            this.panel3.Location = new System.Drawing.Point(787, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 159);
            this.panel3.TabIndex = 21;
            // 
            // textBoxOutputY
            // 
            this.textBoxOutputY.Location = new System.Drawing.Point(16, 56);
            this.textBoxOutputY.Name = "textBoxOutputY";
            this.textBoxOutputY.Size = new System.Drawing.Size(50, 20);
            this.textBoxOutputY.TabIndex = 40;
            this.textBoxOutputY.Text = "outX2";
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
            // textBoxOutputX
            // 
            this.textBoxOutputX.Location = new System.Drawing.Point(16, 18);
            this.textBoxOutputX.Name = "textBoxOutputX";
            this.textBoxOutputX.Size = new System.Drawing.Size(50, 20);
            this.textBoxOutputX.TabIndex = 39;
            this.textBoxOutputX.Text = "outX1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSalmon;
            this.panel4.Controls.Add(this.textBoxInputY);
            this.panel4.Controls.Add(this.textBoxInputX);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(147, 281);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(84, 159);
            this.panel4.TabIndex = 21;
            // 
            // textBoxInputY
            // 
            this.textBoxInputY.Location = new System.Drawing.Point(18, 59);
            this.textBoxInputY.Name = "textBoxInputY";
            this.textBoxInputY.Size = new System.Drawing.Size(50, 20);
            this.textBoxInputY.TabIndex = 38;
            this.textBoxInputY.Text = "inX2";
            // 
            // textBoxInputX
            // 
            this.textBoxInputX.Location = new System.Drawing.Point(18, 21);
            this.textBoxInputX.Name = "textBoxInputX";
            this.textBoxInputX.Size = new System.Drawing.Size(50, 20);
            this.textBoxInputX.TabIndex = 37;
            this.textBoxInputX.Text = "inX1";
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
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonFast
            // 
            this.buttonFast.Location = new System.Drawing.Point(51, 328);
            this.buttonFast.Name = "buttonFast";
            this.buttonFast.Size = new System.Drawing.Size(75, 23);
            this.buttonFast.TabIndex = 26;
            this.buttonFast.Text = "fast";
            this.buttonFast.UseVisualStyleBackColor = true;
            this.buttonFast.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxRate
            // 
            this.textBoxRate.Location = new System.Drawing.Point(808, 89);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(40, 20);
            this.textBoxRate.TabIndex = 27;
            this.textBoxRate.Text = "0.01";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(737, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "learning rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(348, 239);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "jumlah variabel";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(576, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "jumlah variabel";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(717, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "iterasi ke";
            // 
            // textBoxIterasi
            // 
            this.textBoxIterasi.Location = new System.Drawing.Point(772, 56);
            this.textBoxIterasi.Name = "textBoxIterasi";
            this.textBoxIterasi.Size = new System.Drawing.Size(49, 20);
            this.textBoxIterasi.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::backpropagation.Properties.Resources.arrows_right_icon;
            this.pictureBox1.Location = new System.Drawing.Point(245, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::backpropagation.Properties.Resources.arrows_right_icon;
            this.pictureBox2.Location = new System.Drawing.Point(462, 328);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::backpropagation.Properties.Resources.arrows_right_icon;
            this.pictureBox3.Location = new System.Drawing.Point(681, 328);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "generate input training";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(51, 357);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 37;
            this.buttonPause.Text = "pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(51, 386);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 38;
            this.buttonStop.Text = "stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(201, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 200);
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Green;
            this.panel5.Location = new System.Drawing.Point(120, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 20);
            this.panel5.TabIndex = 40;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Blue;
            this.panel6.Location = new System.Drawing.Point(120, 85);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 20);
            this.panel6.TabIndex = 41;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Yellow;
            this.panel8.Location = new System.Drawing.Point(120, 111);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(20, 20);
            this.panel8.TabIndex = 41;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Red;
            this.panel9.Location = new System.Drawing.Point(120, 33);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(20, 20);
            this.panel9.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "random +/-";
            // 
            // textBoxRandom
            // 
            this.textBoxRandom.Location = new System.Drawing.Point(91, 159);
            this.textBoxRandom.Name = "textBoxRandom";
            this.textBoxRandom.Size = new System.Drawing.Size(35, 20);
            this.textBoxRandom.TabIndex = 43;
            this.textBoxRandom.Text = "1";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 470);
            this.Controls.Add(this.textBoxRandom);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxIterasi);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.buttonFast);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonPlay);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
        private System.Windows.Forms.Button buttonPlay;
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
        private System.Windows.Forms.Button buttonFast;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxIterasi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxOutputY;
        private System.Windows.Forms.TextBox textBoxOutputX;
        private System.Windows.Forms.TextBox textBoxInputY;
        private System.Windows.Forms.TextBox textBoxInputX;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxRandom;
    }
}

