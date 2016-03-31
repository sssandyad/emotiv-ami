using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backpropagation
{
    public partial class Form1 : Form
    {
        double[] dataX;
        double[] dataY;
        double[] output;

        double[] nilaiAcuanX;
        double[] nilaiAcuanY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            dataX = new double[40];
            dataY = new double[40];
            output = new double[40];

            nilaiAcuanX = new double[4];
            nilaiAcuanY = new double[4];

            nilaiAcuanX[0] = double.Parse(tb_x1.Text);
            nilaiAcuanX[1] = double.Parse(tb_x2.Text);
            nilaiAcuanX[2] = double.Parse(tb_x3.Text);
            nilaiAcuanX[3] = double.Parse(tb_x4.Text);

            nilaiAcuanY[0] = double.Parse(tb_y1.Text);
            nilaiAcuanY[1] = double.Parse(tb_y2.Text);
            nilaiAcuanY[2] = double.Parse(tb_y3.Text);
            nilaiAcuanY[3] = double.Parse(tb_y4.Text);

            Random rand = new Random();
            double nilaiRandom = 0;
            for (int i=0;i<40;i++)
            {
                nilaiRandom = rand.Next(0, 9)*0.1 + rand.Next(0, 9) * 0.01;
                dataX[i] = nilaiAcuanX[i / 10] - 0.5 + nilaiRandom;

                nilaiRandom = rand.Next(0, 9) * 0.1 + rand.Next(0, 9) * 0.01;
                dataY[i] = nilaiAcuanY[i / 10] - 0.5 + nilaiRandom;

                output[i] = i / 10 + 1;

                //Console.WriteLine("(" + dataX[i] + "," + dataY[i] + ") = " + output[i]);
            }
        }
    }
}
