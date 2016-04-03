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
    public partial class form1 : Form
    {
        List<Neuron> layerInput;
        List<Neuron> layerPertama;
        List<Neuron> layerKedua;
        List<Neuron> layerOutput;

        Bitmap jaring;
        Graphics gambarJaring;

        Bitmap grafik;
        Graphics flagGraphics;
        List<Brush> warna;

        double mse;
        int counter;
        bool isStop;
        double plusMinus;
        double alpha;

        double[] dataX;
        double[] dataY;
        double[] kelas;

        double learningRate;

        double[] nilaiAcuanX;
        double[] nilaiAcuanY;

        int jumlahVariableHiddenLayer1;
        int jumlahVariableHiddenLayer2;

        double bobot1;
        double bobot2;
        double bobot3;

        double[] outputYangDiinginkan;

        public form1()
        {
            InitializeComponent();

            warna = new List<Brush>();
            warna.Add(Brushes.Red);
            warna.Add(Brushes.Green);
            warna.Add(Brushes.Blue);
            warna.Add(Brushes.Yellow);

            alpha = 1;

            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            buttonFast.Enabled = false;
            buttonNetwork.Enabled = false;

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

            chart1.Series.Add("error");
            chart1.Series["error"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            GenerateBobot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            buttonPlay.Enabled = false;
            buttonFast.Enabled = true;
            buttonPause.Enabled = true;
            buttonStop.Enabled = true;
            buttonGenerateBobot.Enabled = false;
            buttonGenerateData.Enabled = false;
            buttonNetwork.Enabled = true;

            if (isStop)
            {
                BuildData();

                ConstructNetwork();

                isStop = false;
            }

            pictureBox4.Invalidate();

            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        void RunBackpropagation()
        {
            mse = 0;
            for (int i = 0; i < 40; i++)
            {
                /*feed forward*/

                //layer layerInput
                //masukkan data random ke neuron layerInput (layer layerInput)
                layerInput[0].outputNeuron = dataX[i];
                layerInput[1].outputNeuron = dataY[i];  

                //layer 1
                for (int j = 0; j < layerPertama.Count; j++)
                {
                    //potensialAktivasi = (total semua bobot * layerInput yg masuk ke neuron tersebut) - threshold(bias error)
                    layerPertama[j].potensialAktivasi = 0;
                    for (int k = 0; k < layerPertama[j].backwardPointer.Count; k++)
                    {
                        layerPertama[j].potensialAktivasi += layerPertama[j].backwardPointer[k].weight * layerPertama[j].backwardPointer[k].back.outputNeuron;
                    }
                    layerPertama[j].potensialAktivasi -= layerPertama[j].threshold;

                    //output neuron dihitung dengan fungsi aktivasi Binary Sigmoid
                    layerPertama[j].outputNeuron = 1 / (1 + Math.Exp(alpha * -layerPertama[j].potensialAktivasi));

                    //menghitung nilai derivative dari fungsi aktivasi Binary Sigmoid:
                    layerPertama[j].derivativeBinarySigmoid = alpha * layerPertama[j].outputNeuron * (1 - layerPertama[j].outputNeuron);
                }

                //layer2
                for (int j = 0; j < layerKedua.Count; j++)
                {
                    //potensialAktivasi = (total semua bobot * layerInput yg masuk ke neuron tersebut) - threshold(bias error)
                    layerKedua[j].potensialAktivasi = 0;
                    for (int k = 0; k < layerKedua[j].backwardPointer.Count; k++)
                    {
                        layerKedua[j].potensialAktivasi += layerKedua[j].backwardPointer[k].weight * layerKedua[j].backwardPointer[k].back.outputNeuron;
                    }
                    layerKedua[j].potensialAktivasi -= layerKedua[j].threshold;

                    //output neuron dihitung dengan fungsi aktivasi Binary Sigmoid
                    layerKedua[j].outputNeuron = 1 / (1 + Math.Exp(alpha * -layerKedua[j].potensialAktivasi));

                    //menghitung nilai derivative dari fungsi aktivasi Binary Sigmoid:
                    layerKedua[j].derivativeBinarySigmoid = alpha * layerKedua[j].outputNeuron * (1 - layerKedua[j].outputNeuron);
                }

                //layerOutput
                for (int j = 0; j < layerOutput.Count; j++)
                {
                    //potensialAktivasi = (total semua bobot * layerInput yg masuk ke neuron tersebut) - threshold(bias error)
                    layerOutput[j].potensialAktivasi = 0;
                    for (int k = 0; k < layerOutput[j].backwardPointer.Count; k++)
                    {
                        layerOutput[j].potensialAktivasi += layerOutput[j].backwardPointer[k].weight * layerOutput[j].backwardPointer[k].back.outputNeuron;
                    }
                    layerOutput[j].potensialAktivasi -= layerOutput[j].threshold;

                    //output neuron dihitung dengan fungsi aktivasi Binary Sigmoid
                    layerOutput[j].outputNeuron = 1 / (1 + Math.Exp(alpha * -layerOutput[j].potensialAktivasi));

                    //menghitung nilai derivative dari fungsi aktivasi Binary Sigmoid:
                    layerOutput[j].derivativeBinarySigmoid = alpha * layerOutput[j].outputNeuron * (1 - layerOutput[j].outputNeuron);
                }


                //mendapatkan layerOutput yang diinginkan (Yd)
                if (kelas[i] == 1)
                {
                    outputYangDiinginkan[0] = 0;
                    outputYangDiinginkan[1] = 0;
                }
                else if (kelas[i] == 2)
                {
                    outputYangDiinginkan[0] = 0;
                    outputYangDiinginkan[1] = 1;
                }
                else if (kelas[i] == 3)
                {
                    outputYangDiinginkan[0] = 1;
                    outputYangDiinginkan[1] = 0;
                }
                else
                {
                    outputYangDiinginkan[0] = 1;
                    outputYangDiinginkan[1] = 1;
                }

                //back propagation
                for(int j=0;j<layerOutput.Count;j++)
                {
                    mse += Math.Pow(outputYangDiinginkan[j] - layerOutput[j].outputNeuron, 2);
                    layerOutput[j].delta = (outputYangDiinginkan[j] - layerOutput[j].outputNeuron) * layerOutput[j].derivativeBinarySigmoid;
                }

                for (int j=0;j<layerKedua.Count;j++)
                {
                    layerKedua[j].delta = 0;
                    for (int k=0;k<layerKedua[j].forwardPointer.Count;k++)
                    {
                        layerKedua[j].delta += layerKedua[j].forwardPointer[k].front.delta * layerKedua[j].forwardPointer[k].weight;
                    }
                    layerKedua[j].delta *= layerKedua[j].derivativeBinarySigmoid;
                }

                for (int j = 0; j < layerPertama.Count; j++)
                {
                    layerPertama[j].delta = 0;
                    for (int k = 0; k < layerPertama[j].forwardPointer.Count; k++)
                    {
                        layerPertama[j].delta = layerPertama[j].forwardPointer[k].front.delta * layerPertama[j].forwardPointer[k].weight;
                    }
                    layerPertama[j].delta *= layerPertama[j].derivativeBinarySigmoid;
                }



                //update weight
                for (int j = 0; j < layerOutput.Count; j++)
                {
                    for (int k = 0; k < layerOutput[j].backwardPointer.Count; k++)
                    {
                        layerOutput[j].backwardPointer[k].weight += learningRate * layerOutput[j].delta * layerOutput[j].backwardPointer[k].back.outputNeuron;
                        layerOutput[j].threshold -= learningRate * layerOutput[j].delta;
                    }
                }

                for (int j = 0; j < layerKedua.Count; j++)
                {
                    for (int k = 0; k < layerKedua[j].backwardPointer.Count; k++)
                    {
                        layerKedua[j].backwardPointer[k].weight += learningRate * layerKedua[j].delta * layerKedua[j].backwardPointer[k].back.outputNeuron;
                        layerKedua[j].threshold -= learningRate * layerKedua[j].delta;
                    }
                }

                for (int j = 0; j < layerPertama.Count; j++)
                {
                    for (int k = 0; k < layerPertama[j].backwardPointer.Count; k++)
                    {
                        layerPertama[j].backwardPointer[k].weight += learningRate * layerPertama[j].delta * layerPertama[j].backwardPointer[k].back.outputNeuron;
                        layerPertama[j].threshold -= learningRate * layerPertama[j].delta;
                    }
                }
            }

            mse /= 80;
            textBoxError.Text = mse.ToString();
            chart1.Series["error"].Points.AddY(mse);

        }

        void GenerateBobot()
        {
            Random rand = new Random();
            tb_wa.Text = (rand.Next(1, 10) * 0.1).ToString();
            tb_wb.Text = (rand.Next(1, 10) * 0.1).ToString();
            tb_wc.Text = (rand.Next(1, 10) * 0.1).ToString();
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

            outputYangDiinginkan = new double[2];

            plusMinus = double.Parse(textBoxRandom.Text);
            double maxRandom = plusMinus * 100 - 1;

            counter = 0;

            learningRate = double.Parse(textBoxRate.Text);

            dataX = new double[40];
            dataY = new double[40];
            kelas = new double[40];

            nilaiAcuanX = new double[4];
            nilaiAcuanY = new double[4];

            bobot1 = double.Parse(tb_wa.Text);
            bobot2 = double.Parse(tb_wb.Text);
            bobot3 = double.Parse(tb_wc.Text);

            nilaiAcuanX[0] = double.Parse(tb_x1.Text);
            nilaiAcuanX[1] = double.Parse(tb_x2.Text);
            nilaiAcuanX[2] = double.Parse(tb_x3.Text);
            nilaiAcuanX[3] = double.Parse(tb_x4.Text);

            nilaiAcuanY[0] = double.Parse(tb_y1.Text);
            nilaiAcuanY[1] = double.Parse(tb_y2.Text);
            nilaiAcuanY[2] = double.Parse(tb_y3.Text);
            nilaiAcuanY[3] = double.Parse(tb_y4.Text);

            jumlahVariableHiddenLayer1 = int.Parse(tb_hiddenLayer1.Text);
            jumlahVariableHiddenLayer2 = int.Parse(tb_hiddenLayer2.Text);

            Random rand = new Random();
            double nilaiRandom = 0;
            for (int i = 0; i < 40; i++)
            {
                nilaiRandom = rand.Next(0, (int)maxRandom) * 0.01;
                dataX[i] = nilaiAcuanX[i / 10] - plusMinus / 2 + nilaiRandom;

                nilaiRandom = rand.Next(0, (int)maxRandom) * 0.01;
                dataY[i] = nilaiAcuanY[i / 10] - plusMinus / 2 + nilaiRandom;

                kelas[i] = i / 10 + 1;

                flagGraphics.FillPie(warna[i/10], (int)(dataX[i]*100/10-2+100), (int)(-1*dataY[i]*100/10-2+100), 5, 5, 0, 360);
                //MessageBox.Show((dataX[i] * 100 / 10 - 2 + 100).ToString() + " " + (dataY[i] * 100 / 10 - 2 + 100).ToString());

                Console.WriteLine("(" + dataX[i] + "," + dataY[i] + ") = " + kelas[i]);
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

            /*merangkai neuron dan memberinya bobot. bobot berdasarkan inputan Wa, Wb, Wc*/

            //memberi bobot1 (Wa) untuk edge yang menghubungkan dari layerInput layer menuju hidden layer pertama
            for (int i = 0; i < layerInput.Count; i++)
            {
                for (int j = 0; j < layerPertama.Count; j++)
                {
                    Edge p = new Edge(bobot1);
                    p.back = layerInput[i];
                    p.front = layerPertama[j];
                    layerInput[i].forwardPointer.Add(p);
                    layerPertama[j].backwardPointer.Add(p);
                }
            }

            //memberi bobot2 (Wb) untuk edge yang menghubungkan dari hidden layer pertama menuju hidden layer kedua
            for (int i = 0; i < layerPertama.Count; i++)
            {
                for (int j = 0; j < layerKedua.Count; j++)
                {
                    Edge p = new Edge(bobot2);
                    p.back = layerPertama[i];
                    p.front = layerKedua[j];
                    layerPertama[i].forwardPointer.Add(p);
                    layerKedua[j].backwardPointer.Add(p);
                }
            }

            //memberi bobot3 (Wc) untuk edge yang menghubungkan dari hidden layer kedua menuju layer layerOutput
            for (int i = 0; i < layerKedua.Count; i++)
            {
                for (int j = 0; j < layerOutput.Count; j++)
                {
                    Edge p = new Edge(bobot2);
                    p.back = layerKedua[i];
                    p.front = layerOutput[j];
                    layerKedua[i].forwardPointer.Add(p);
                    layerOutput[j].backwardPointer.Add(p);
                }
            }

            DrawNeuralNetwork();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonFast.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
            buttonPause.Enabled = true;
            //RunBackpropagation();
            timer1.Interval = 10;
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
            RunBackpropagation();
            textBoxIterasi.Text = (++counter).ToString();
            if(int.Parse(textBoxMax.Text) <= int.Parse(textBoxIterasi.Text) || double.Parse(textBoxLimitError.Text) >= mse)
            {
                timer1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonFast.Enabled = true;
            buttonStop.Enabled = true;

            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonPlay.Enabled = true;
            buttonPause.Enabled = false;
            buttonFast.Enabled = false;
            buttonGenerateData.Enabled = true;
            buttonGenerateBobot.Enabled = true;
            buttonNetwork.Enabled = false;

            textBoxError.Clear();
            textBoxIterasi.Clear();
            chart1.Series["error"].Points.Clear();

            timer1.Enabled = false;
            isStop = true;
        }

        private void buttonGenerateData_Click(object sender, EventArgs e)
        {
            isStop = false;

            buttonNetwork.Enabled = true;

            BuildData();

            ConstructNetwork();

            pictureBox4.Invalidate();
        }

        private void buttonGenerateBobot_Click(object sender, EventArgs e)
        {
            GenerateBobot();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form hiddenLayer2 = new Form2(jaring);
            hiddenLayer2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form hiddenLayer2 = new Form2(jaring);
            hiddenLayer2.Show();
        }
    }
}
