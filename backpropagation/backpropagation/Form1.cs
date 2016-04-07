using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace backpropagation
{
    public partial class form1 : Form
    {

        List<Neuron> layerInput;
        List<Neuron> layerPertama;
        List<Neuron> layerKedua;
        List<Neuron> layerOutput;
        List<String> status;

        Form2 form2;

        int index;
        int totalTrial;

        List<Color> colors;
        List<double[]> dataTable;

        Bitmap jaring;
        Graphics gambarJaring;

        Bitmap grafik;
        Graphics flagGraphics;
        List<Brush> warna;

        int counter;
        bool isStop;
        double offset;
        double alpha;

        double learningRate;

        double[] nilaiAcuanX;
        double[] nilaiAcuanY;

        int jumlahVariableHiddenLayer1;
        int jumlahVariableHiddenLayer2;

        int m, p, tau;
        double miu,batas_error, z_in, err;
        double[,] dataClass, wa, wb, wc, Yd;
        double[] tha, thb, thc, oa, ob, goa, gob, y, gy, deltaA, deltaB, deltaC;

        void BuildInput()
        {
            m = int.Parse(tb_hiddenLayer1.Text);
            p = int.Parse(tb_hiddenLayer2.Text);
            learningRate = double.Parse(textBoxRate.Text);

            alpha = double.Parse(textBoxAlpha.Text);
            miu = double.Parse(textBoxRate.Text);
            tau = 10000000;
            batas_error = double.Parse(textBoxLimitError.Text);

            wa = new double[m, 2];
            wb = new double[p, m];
            wc = new double[2, p];

            Random rand = new Random();

            for(int i=0;i< m;i++)
            {
                for(int j=0;j<2;j++)
                {
                    wa[i, j] = rand.NextDouble() * 0.5;
                }
            }

            for(int i=0;i< p;i++)
            {
                for(int j=0;j< m;j++)
                {
                    wb[i, j] = rand.NextDouble() * 0.5;
                }
            }

            for(int i=0;i<2;i++)
            {
                for (int j=0;j< p;j++)
                {
                    wc[i, j] = rand.NextDouble() * 0.5;
                }
            }

            tha = new double[m];
            thb = new double[p];
            thc = new double[2];

            for(int i=0;i< m;i++)
            {
                tha[i] = rand.NextDouble() * 0.5;
            }

            for (int i = 0; i < p; i++)
            {
                thb[i] = rand.NextDouble() * 0.5;
            }

            for (int i = 0; i < 2; i++)
            {
                thc[i] = rand.NextDouble() * 0.5;
            }

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

            offset = double.Parse(textBoxOffset.Text);

            dataClass = new double[2, 40];
            Yd = new double[2, 40];
            for (int j=0;j<10;j++)
            {
                int plusOrMinus;

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[0, j] = nilaiAcuanX[0] + rand.NextDouble() * offset * plusOrMinus;
                Yd[0, j] = 0;
                dataTable[j][0] = dataClass[0, j];
                dataTable[j][2] = Yd[0, j];

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[1, j] = nilaiAcuanY[0] + rand.NextDouble() * offset * plusOrMinus;
                Yd[1, j] = 0;
                dataTable[j][1] = dataClass[1, j];
                dataTable[j][3] = Yd[1, j];
            }

            for (int j = 10; j < 20; j++)
            {
                int plusOrMinus;

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[0, j] = nilaiAcuanX[1] + rand.NextDouble() * offset * plusOrMinus;
                Yd[0, j] = 0;
                dataTable[j][0] = dataClass[0, j];
                dataTable[j][2] = Yd[0, j];

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[1, j] = nilaiAcuanY[1] + rand.NextDouble() * offset * plusOrMinus;
                Yd[1, j] = 1;
                dataTable[j][1] = dataClass[1, j];
                dataTable[j][3] = Yd[1, j];
            }

            for (int j = 20; j < 30; j++)
            {
                int plusOrMinus;

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[0, j] = nilaiAcuanX[2] + rand.NextDouble() * offset * plusOrMinus;
                Yd[0, j] = 1;
                dataTable[j][0] = dataClass[0, j];
                dataTable[j][2] = Yd[0, j];


                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[1, j] = nilaiAcuanY[2] + rand.NextDouble() * offset * plusOrMinus;
                Yd[1, j] = 0;
                dataTable[j][1] = dataClass[1, j];
                dataTable[j][3] = Yd[1, j];
            }

            for (int j = 30; j < 40; j++)
            {
                int plusOrMinus;

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[0, j] = nilaiAcuanX[3] + rand.NextDouble() * offset * plusOrMinus;
                Yd[0, j] = 1;
                dataTable[j][0] = dataClass[0, j];
                dataTable[j][2] = Yd[0, j];

                if (rand.Next(0, 1) == 0) plusOrMinus = 1;
                else plusOrMinus = -1;
                dataClass[1, j] = nilaiAcuanY[3] + rand.NextDouble() * offset * plusOrMinus;
                Yd[1, j] = 1;
                dataTable[j][1] = dataClass[1, j];
                dataTable[j][3] = Yd[1, j];
            }
        }

        void BackPropagation()
        {
            err = 0;
            miu = learningRate / (1 + (index / tau));
            oa = new double[m];
            goa = new double[m];
            ob = new double[p];
            gob = new double[p];
            y = new double[2];
            gy = new double[2];

            for (int k = 0; k < 40; k++)
            {
                for (int j = 0; j < m; j++)
                {
                    z_in = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        z_in += wa[j, i] * dataClass[i, k];
                    }
                    z_in -= tha[j];
                    oa[j] = 1 / (1 + Math.Exp(-alpha * z_in));
                    goa[j] = alpha * oa[j] * (1 - oa[j]);
                }

                for (int j = 0; j < p; j++)
                {
                    z_in = 0;
                    for (int i = 0; i < m; i++)
                    {
                        z_in += wb[j, i] * oa[i];
                    }
                    z_in -= thb[j];
                    ob[j] = 1 / (1 + Math.Exp(-alpha * z_in));
                    gob[j] = alpha * ob[j] * (1 - ob[j]);
                }

                for (int j = 0; j < 2; j++)
                {
                    z_in = 0;
                    for (int i = 0; i < p; i++)
                    {
                        z_in += wc[j, i] * ob[i];
                    }
                    z_in -= thc[j];
                    y[j] = 1 / (1 + Math.Exp(-alpha * z_in));
                    gy[j] = alpha * y[j] * (1 - y[j]);
                }

                err += 0.5 * Math.Pow((Yd[0, k] - y[0]), 2) * Math.Pow((Yd[1, k] - y[1]), 2);
                dataTable[k][4] = y[0];
                dataTable[k][5] = y[1];

                deltaA = new double[40];
                deltaB = new double[40];
                deltaC = new double[40];
                for (int i = 0; i < 2; i++)
                {
                    deltaC[i] = (Yd[i, k] - y[i]) * gy[i];
                }

                for(int i=0;i<2;i++)
                {
                    for(int j=0;j< p;j++)
                    {
                        deltaB[i] = deltaC[j] * wc[i, j] * gob[i];
                    }
                }

                for (int i = 0; i < p; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        deltaA[i] = deltaB[j] * wb[i, j] * goa[i];
                    }
                }

                //update
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j< p;j++)
                    {
                        wc[i, j] += miu * deltaC[i] * ob[j];
                    }
                    thc[i] -= miu * deltaC[i];
                }

                for(int i=0;i< p;i++)
                {
                    for(int j=0;j< m;j++)
                    {
                        wb[i, j] += miu * deltaB[i] * oa[j];
                    }
                    thb[i] -= miu * deltaB[i];
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        wa[i, j] += miu * deltaA[i] * dataClass[j,k];
                    }
                    tha[i] -= miu * deltaA[i];
                }
            }

            //err /= 40;
            textBoxError.Text = err.ToString();
            if (checkBox1.Checked)
                form2.UpdateError(err);
            //chart1.Series[index].Points.AddY(err);
            chart2.Series[index].Points.AddY(err);

            if(checkBox1.Checked)
                form2.AddValueChart(err);
        }

        public void StopFromOther()
        {
            buttonStop.PerformClick();
        }

        public form1()
        {
            InitializeComponent();

            index = 0;
            totalTrial = 0;

            warna = new List<Brush>();
            warna.Add(Brushes.Red);
            warna.Add(Brushes.Green);
            warna.Add(Brushes.Blue);
            warna.Add(Brushes.Yellow);

            colors = new List<Color>();
            colors.Add(Color.Red);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Yellow);
            colors.Add(Color.Black);
            colors.Add(Color.Purple);
            colors.Add(Color.Orange);
            colors.Add(Color.Magenta);
            var rainbow = Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in rainbow)
            {
                colors.Add(Color.FromKnownColor(knowColor));
            }

            status = new List<string>();

            alpha = 1;

            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            buttonFast.Enabled = false;

            timer1.Enabled = false;
            isStop = true;

            grafik = new Bitmap(200, 200);
            flagGraphics = Graphics.FromImage(grafik);

            flagGraphics.FillRectangle(Brushes.White, 0, 0, 200, 200);
            flagGraphics.FillRectangle(Brushes.Black, 99, 0, 2, 200);
            flagGraphics.FillRectangle(Brushes.Black, 0, 99, 200, 2);

            pictureBox4.Image = grafik;

            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;

            jaring = new Bitmap(1000, 600);
            gambarJaring = Graphics.FromImage(jaring);
            gambarJaring.FillRectangle(Brushes.White, 0, 0, 1000, 600);
            gambarJaring.FillRectangle(Brushes.LightSalmon, 250, 0, 250, 600);
            gambarJaring.FillRectangle(Brushes.LightBlue, 500, 0, 250, 600);

            Pen blackPen = new Pen(Color.Black, 3);
            gambarJaring.DrawLine(blackPen,250,0,250,600);
            gambarJaring.DrawLine(blackPen, 500, 0, 500, 600);
            gambarJaring.DrawLine(blackPen, 750, 0, 750, 600);

            form2 = new Form2(this);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 10;
            series.Color = Color.Blue;
            series.IsVisibleInLegend = false;
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            dataTable = new List<double[]>();
            for(int i=0;i<40;i++)
            {
                dataTable.Add(new double[6]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.ResetChart();
            textBoxError.Clear();
            textBoxIterasi.Clear();

            buttonFirstVariableDown.Enabled = false;
            buttonFirstVariableUp.Enabled = false;
            buttonSecondVariableDown.Enabled = false;
            buttonSecondVariableUp.Enabled = false;

            buttonPlay.Enabled = false;
            checkBox1.Enabled = false;
            buttonFast.Enabled = true;
            buttonPause.Enabled = true;
            buttonStop.Enabled = true;
            buttonGenerateData.Enabled = false;

            totalTrial++;
            index = totalTrial - 1;

            if (isStop)
            {
                BuildInput();
                BuildData();

                ConstructNetwork();

                isStop = false;
            }

            var warnaGrafik = colors[totalTrial-1];

            Series global = new Series();
            global.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            global.Color = warnaGrafik;
            global.LegendText = "percobaan " + (index + 1).ToString();
            chart2.Series.Add(global);

            pictureBox4.Invalidate();

            if(checkBox1.Checked)
                form2.Show();

            timer1.Interval = 1;
            timer1.Enabled = true;
        }

        void BuildData()
        {
            grafik = new Bitmap(200, 200);
            flagGraphics = Graphics.FromImage(grafik);

            flagGraphics.FillRectangle(Brushes.White, 0, 0, 200, 200);
            flagGraphics.FillRectangle(Brushes.Black, 99, 0, 2, 200);
            flagGraphics.FillRectangle(Brushes.Black, 0, 99, 200, 2);
            pictureBox4.Image = grafik;

            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;

            offset = double.Parse(textBoxOffset.Text);

            counter = 0;

            learningRate = double.Parse(textBoxRate.Text);

            jumlahVariableHiddenLayer1 = int.Parse(tb_hiddenLayer1.Text);
            jumlahVariableHiddenLayer2 = int.Parse(tb_hiddenLayer2.Text);

            string stringJumlahVariable = "Percobaan ke: " + totalTrial.ToString() + "  |  hidden layer #1: " + tb_hiddenLayer1.Text + "  |  hidden layer #2: " + tb_hiddenLayer2.Text;
            status.Add(stringJumlahVariable);

            alpha = double.Parse(textBoxAlpha.Text);

            for (int i = 0; i < 40; i++)
            {
                flagGraphics.FillPie(warna[i/10], (int)(dataClass[0,i]*100/10-2+100), (int)(-1*dataClass[1,i]*100/10-2+100), 5, 5, 0, 360);
            }
        }

        void ConstructNetwork()
        {
            //construct layer layerInput. ada 2 layerInput
            layerInput = new List<Neuron>();
            layerInput.Add(new Neuron(125,200));
            layerInput.Add(new Neuron(125,400));

            //construct hidden layer pertama
            layerPertama = new List<Neuron>();
            int jumpValue = 600 / (jumlahVariableHiddenLayer1+1);
            int pivot = jumpValue;
            for (int i = 0; i < jumlahVariableHiddenLayer1; i++)
            {
                layerPertama.Add(new Neuron(375, pivot));
                pivot += jumpValue;
            }

            //construct hidden layer kedua
            jumpValue = 600 / (jumlahVariableHiddenLayer2+1);
            pivot = jumpValue;
            layerKedua = new List<Neuron>();
            for (int i = 0; i < jumlahVariableHiddenLayer2; i++)
            {
                layerKedua.Add(new Neuron(625,pivot));
                pivot += jumpValue;
            }

            //construct layer layerOutput. ada 2 layerOutput.
            layerOutput = new List<Neuron>();
            layerOutput.Add(new Neuron(875,200));
            layerOutput.Add(new Neuron(875,400));


            //menghubungkan dari layerInput layer menuju hidden layer pertama
            for (int i = 0; i < layerInput.Count; i++)
            {
                for (int j = 0; j < layerPertama.Count; j++)
                {
                    Edge p = new Edge();
                    p.back = layerInput[i];
                    p.front = layerPertama[j];
                    layerInput[i].forwardPointer.Add(p);
                    layerPertama[j].backwardPointer.Add(p);
                }
            }

            //menghubungkan dari hidden layer pertama menuju hidden layer kedua
            for (int i = 0; i < layerPertama.Count; i++)
            {
                for (int j = 0; j < layerKedua.Count; j++)
                {
                    Edge p = new Edge();
                    p.back = layerPertama[i];
                    p.front = layerKedua[j];
                    layerPertama[i].forwardPointer.Add(p);
                    layerKedua[j].backwardPointer.Add(p);
                }
            }

            //menghubungkan dari hidden layer kedua menuju layer layerOutput
            for (int i = 0; i < layerKedua.Count; i++)
            {
                for (int j = 0; j < layerOutput.Count; j++)
                {
                    Edge p = new Edge();
                    p.back = layerKedua[i];
                    p.front = layerOutput[j];
                    layerKedua[i].forwardPointer.Add(p);
                    layerOutput[j].backwardPointer.Add(p);
                }
            }

            DrawNeuralNetwork();

            if(checkBox1.Checked)
                form2.SetGambar(jaring);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonFast.Enabled = true;
            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
            buttonPause.Enabled = true;
            //RunBackpropagation();
            if (timer1.Interval == 500)
            {
                timer1.Interval = 1;
                buttonFast.Text = "slow";
            }
            else
            {
                timer1.Interval = 500;
                buttonFast.Text = "fast";
            }
            timer1.Enabled = true;
            
        }

        void DrawNeuralNetwork()
        {
            for (int i = 0; i < layerInput.Count; i++)
            {
                gambarJaring.FillRectangle(Brushes.Yellow, layerInput[i].location.X - 10, layerInput[i].location.Y - 10, 20, 20);
            }

            for (int i = 0; i < layerOutput.Count; i++)
            {
                gambarJaring.FillRectangle(Brushes.Green, layerOutput[i].location.X - 10, layerOutput[i].location.Y - 10, 20, 20);
            }

            for (int i=0;i<layerPertama.Count;i++)
            {
                gambarJaring.FillEllipse(Brushes.Red, layerPertama[i].location.X - 5, layerPertama[i].location.Y - 5, 10, 10);
            }

            for (int i = 0; i < layerKedua.Count; i++)
            {
                gambarJaring.FillEllipse(Brushes.Red, layerKedua[i].location.X - 5, layerKedua[i].location.Y - 5, 10, 10);
            }

            Pen pen = new Pen(Color.Black, 1);

            for (int i = 0;i<layerInput.Count;i++)
            {
                for (int j=0;j<layerInput[i].forwardPointer.Count;j++)
                {
                    gambarJaring.DrawLine(pen, layerInput[i].location, layerInput[i].forwardPointer[j].front.location);
                }
            }

            for (int i = 0; i < layerPertama.Count; i++)
            {
                for (int j = 0; j < layerPertama[i].forwardPointer.Count; j++)
                {
                    gambarJaring.DrawLine(pen, layerPertama[i].location, layerPertama[i].forwardPointer[j].front.location);
                }
            }

            for (int i = 0; i < layerKedua.Count; i++)
            {
                for (int j = 0; j < layerKedua[i].forwardPointer.Count; j++)
                {
                    gambarJaring.DrawLine(pen, layerKedua[i].location, layerKedua[i].forwardPointer[j].front.location);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackPropagation();
            textBoxIterasi.Text = (++counter).ToString();
            if (checkBox1.Checked)
                form2.UpdateIterasi(counter);


            if(checkBox1.Checked)
                form2.UpdateTable(dataTable);
            if(double.Parse(textBoxLimitError.Text) >= err)
            {
                StopIteration();
                form2.Hide();
                MessageBox.Show("Iterasi berhenti di " + counter.ToString());
            }
        }

        void StopIteration()
        {
            buttonFirstVariableDown.Enabled = true;
            buttonFirstVariableUp.Enabled = true;
            buttonSecondVariableDown.Enabled = true;
            buttonSecondVariableUp.Enabled = true;
            buttonStop.Enabled = false;
            checkBox1.Enabled = true;
            buttonPlay.Enabled = true;
            buttonPause.Enabled = false;
            buttonFast.Enabled = false;
            buttonGenerateData.Enabled = true;
            buttonPause.Text = "pause";
            buttonFast.Text = "slow";

            timer1.Enabled = false;
            isStop = true;

            chart1.Series[0].Points.AddXY(counter, err);
            chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = colors[totalTrial - 1];
            chart1.Series[0].Points[chart1.Series[0].Points.Count-1].Label = totalTrial.ToString() +"#("+jumlahVariableHiddenLayer1.ToString()+","+jumlahVariableHiddenLayer2.ToString()+")";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonPause.Enabled = true;
            buttonFast.Enabled = true;
            buttonStop.Enabled = true;

            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                buttonPause.Text = "play";
            }
            else
            {
                timer1.Enabled = true;
                buttonPause.Text = "pause";
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StopIteration();
        }

        private void buttonGenerateData_Click(object sender, EventArgs e)
        {
            isStop = false;

            BuildInput();

            BuildData();

            ConstructNetwork();

            pictureBox4.Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void buttonFirstVariableDown_Click(object sender, EventArgs e)
        {


            int value = int.Parse(tb_hiddenLayer1.Text);
            tb_hiddenLayer1.Text = ((value < 2) ? 0 : --value).ToString();
        }

        private void buttonFirstVariableUp_Click(object sender, EventArgs e)
        {


            int value = int.Parse(tb_hiddenLayer1.Text);
            tb_hiddenLayer1.Text = (++value).ToString();
        }

        private void buttonSecondVariableDown_Click(object sender, EventArgs e)
        {


            int value = int.Parse(tb_hiddenLayer2.Text);
            tb_hiddenLayer2.Text = ((value < 2) ? 0 : --value).ToString();
        }

        private void buttonSecondVariableUp_Click(object sender, EventArgs e)
        {


            int value = int.Parse(tb_hiddenLayer2.Text);
            tb_hiddenLayer2.Text = (++value).ToString();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            chart1.Series[index].Enabled = false;
            if (index > 0)
                --index;
            chart1.Series[index].Enabled = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            totalTrial++;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            chart1.Series[index].Enabled = false;
            if (index < totalTrial-1)
                ++index;

            chart1.Series[index].Enabled = true;
        }
    }
}
