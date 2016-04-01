﻿using System;
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
        List<Neuron> input;
        List<Neuron> layerPertama;
        List<Neuron> layerKedua;
        List<Neuron> output;

        Bitmap grafik;
        Graphics flagGraphics;
        List<Brush> warna;


        double mse;
        int counter;
        bool isStop= false;
        double plusMinus;

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

                //masukkan data random ke neuron input
                input[0].value = dataX[i];
                input[1].value = dataY[i];  

                //layer 1
                for (int j = 0; j < layerPertama.Count; j++)
                {
                    layerPertama[j].value = 0;
                    for (int k = 0; k < layerPertama[j].backwardPointer.Count; k++)
                    {
                        layerPertama[j].value += layerPertama[j].backwardPointer[k].weight * layerPertama[j].backwardPointer[k].back.value;
                    }
                    layerPertama[j].sigmoid = 1 / (1 + Math.Exp(-1 * layerPertama[j].value));
                }

                //layer2
                for (int j = 0; j < layerKedua.Count; j++)
                {
                    layerKedua[j].value = 0;
                    for (int k = 0; k < layerKedua[j].backwardPointer.Count; k++)
                    {
                        layerKedua[j].value += layerKedua[j].backwardPointer[k].weight * layerKedua[j].backwardPointer[k].back.sigmoid;
                    }
                    layerKedua[j].sigmoid = 1 / (1 + Math.Exp(-1 * layerKedua[j].value));
                }

                //layerOutput
                for (int j = 0; j < output.Count; j++)
                {
                    output[j].value = 0;
                    for (int k = 0; k < output[j].backwardPointer.Count; k++)
                    {
                        output[j].value += output[j].backwardPointer[k].weight * output[j].backwardPointer[k].back.sigmoid;
                    }
                    output[j].sigmoid = 1 / (1 + Math.Exp(-1 * output[j].value));
                }


                //mendapatkan output yang diinginkan
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
                for (int j = 0; j < output.Count; j++)
                {
                    for (int k = 0; k < output[j].backwardPointer.Count; k++)
                    {
                        output[j].backwardPointer[k].portionError = (outputYangDiinginkan[j] - output[j].sigmoid) * output[j].sigmoid * (1 - output[j].sigmoid);
                        output[j].backwardPointer[k].deltaWeight = learningRate * output[j].backwardPointer[k].portionError * output[j].backwardPointer[k].back.sigmoid;

                        output[j].backwardPointer[k].weight += output[j].backwardPointer[k].deltaWeight;

                        mse += Math.Pow(outputYangDiinginkan[j] - output[j].sigmoid, 2);
                    }
                }

                for (int j = 0; j < layerKedua.Count; j++)
                {
                    for (int k = 0; k < layerKedua[j].backwardPointer.Count; k++)
                    {
                        layerKedua[j].backwardPointer[k].portionError = 0;
                        for (int l = 0; l < layerKedua[j].forwardPointer.Count; l++)
                        {
                            layerKedua[j].backwardPointer[k].portionError += layerKedua[j].forwardPointer[l].portionError;
                        }
                        layerKedua[j].backwardPointer[k].deltaWeight = learningRate * layerKedua[j].backwardPointer[k].portionError * layerKedua[j].backwardPointer[k].back.sigmoid;
                        layerKedua[j].backwardPointer[k].weight += layerKedua[j].backwardPointer[k].deltaWeight;
                    }
                }

                for (int j = 0; j < layerPertama.Count; j++)
                {
                    for (int k = 0; k < layerPertama[j].backwardPointer.Count; k++)
                    {
                        layerPertama[j].backwardPointer[k].portionError = 0;
                        for (int l = 0; l < layerPertama[j].forwardPointer.Count; l++)
                        {
                            layerPertama[j].backwardPointer[k].portionError += layerPertama[j].forwardPointer[l].portionError;
                        }
                        layerPertama[j].backwardPointer[k].deltaWeight = learningRate * layerPertama[j].backwardPointer[k].portionError * layerPertama[j].backwardPointer[k].back.value;
                        layerPertama[j].backwardPointer[k].weight += layerPertama[j].backwardPointer[k].deltaWeight;
                    }
                }
            }

            textBoxError.Text = (mse / 80).ToString();
        }

        void BuildData()
        {
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
            //construct input
            input = new List<Neuron>();
            input.Add(new Neuron());
            input.Add(new Neuron());

            //construct layer pertama
            layerPertama = new List<Neuron>();
            for (int i = 0; i < jumlahVariableHiddenLayer1; i++)
            {
                layerPertama.Add(new Neuron());
            }

            //construct layer kedua
            layerKedua = new List<Neuron>();
            for (int i = 0; i < jumlahVariableHiddenLayer2; i++)
            {
                layerKedua.Add(new Neuron());
            }

            //construct output
            output = new List<Neuron>();
            output.Add(new Neuron());
            output.Add(new Neuron());

            //merangkai neuron dan memberinya bobot
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < layerPertama.Count; j++)
                {
                    Pointer p = new Pointer(bobot1);
                    p.back = input[i];
                    p.front = layerPertama[j];
                    input[i].forwardPointer.Add(p);
                    layerPertama[j].backwardPointer.Add(p);
                }
            }

            for (int i = 0; i < layerPertama.Count; i++)
            {
                for (int j = 0; j < layerKedua.Count; j++)
                {
                    Pointer p = new Pointer(bobot2);
                    p.back = layerPertama[i];
                    p.front = layerKedua[j];
                    layerPertama[i].forwardPointer.Add(p);
                    layerKedua[j].backwardPointer.Add(p);
                }
            }

            for (int i = 0; i < layerKedua.Count; i++)
            {
                for (int j = 0; j < output.Count; j++)
                {
                    Pointer p = new Pointer(bobot2);
                    p.back = layerKedua[i];
                    p.front = output[j];
                    layerKedua[i].forwardPointer.Add(p);
                    output[j].backwardPointer.Add(p);
                }
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunBackpropagation();
            textBoxIterasi.Text = (++counter).ToString();
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

            textBoxError.Clear();
            textBoxIterasi.Clear();

            timer1.Enabled = false;
            isStop = true;
        }
    }
}
