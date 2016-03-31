namespace backpropagation
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
            this.buttonStart = new System.Windows.Forms.Button();
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
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(17, 172);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 439);
            this.Controls.Add(this.buttonStart);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button buttonStart;
    }
}

