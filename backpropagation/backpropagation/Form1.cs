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
        List<Neuron> input;
        List<Neuron> layerPertama;
        List<Neuron> layerKedua;
        List<Neuron> output;

        double[] dataX;
        double[] dataY;
        double[] kelas;

        double learningRate = 0.01;

        double[] nilaiAcuanX;
        double[] nilaiAcuanY;

        int jumlahVariableHiddenLayer1;
        int jumlahVariableHiddenLayer2;

        double bobot1;
        double bobot2;
        double bobot3;

        double[] koreksiBobot1;
        double[] koreksiBobot2;
        double[] koreksiBobot3;

        double[] portion1;
        double[] portion2;
        double[] portion3;

        double[] layer1;
        double[] layer2;
        double[] layerOut;

        double[] sigmoid1;
        double[] sigmoid2;
        double[] sigmoidOut;

        double[] outputYangDiinginkan;

        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //outputYangDiinginkan = new double[2];

            //dataX = new double[40];
            //dataY = new double[40];
            //output = new double[40];

            //nilaiAcuanX = new double[4];
            //nilaiAcuanY = new double[4];

            //nilaiAcuanX[0] = double.Parse(tb_x1.Text);
            //nilaiAcuanX[1] = double.Parse(tb_x2.Text);
            //nilaiAcuanX[2] = double.Parse(tb_x3.Text);
            //nilaiAcuanX[3] = double.Parse(tb_x4.Text);

            //nilaiAcuanY[0] = double.Parse(tb_y1.Text);
            //nilaiAcuanY[1] = double.Parse(tb_y2.Text);
            //nilaiAcuanY[2] = double.Parse(tb_y3.Text);
            //nilaiAcuanY[3] = double.Parse(tb_y4.Text);

            //jumlahVariableHiddenLayer1 = int.Parse(tb_hiddenLayer1.Text);
            //jumlahVariableHiddenLayer2 = int.Parse(tb_hiddenLayer2.Text);

            //layer1 = new double[jumlahVariableHiddenLayer1];
            //layer2 = new double[jumlahVariableHiddenLayer2];
            //layerOut = new double[2];

            //sigmoid1 = new double[jumlahVariableHiddenLayer1];
            //sigmoid2 = new double[jumlahVariableHiddenLayer2];
            //sigmoidOut = new double[2];


            ////initialisasi bobot
            //bobot1 = new double[2*jumlahVariableHiddenLayer1];
            //koreksiBobot1 = new double[2 * jumlahVariableHiddenLayer1];
            //portion1 = new double[2 * jumlahVariableHiddenLayer1];
            //for (int i = 0; i < 2 * jumlahVariableHiddenLayer1; i++)
            //{
            //    bobot1[i] = double.Parse(tb_wa.Text);
            //}

            //bobot2 = new double[jumlahVariableHiddenLayer1 * jumlahVariableHiddenLayer2];
            //koreksiBobot2 = new double[jumlahVariableHiddenLayer1 * jumlahVariableHiddenLayer2];
            //portion2 = new double[jumlahVariableHiddenLayer1 * jumlahVariableHiddenLayer2];
            //for (int i = 0; i < jumlahVariableHiddenLayer1 * jumlahVariableHiddenLayer2;i++)
            //{
            //    bobot2[i] = double.Parse(tb_wb.Text);
            //}

            //bobot3 = new double[jumlahVariableHiddenLayer2 * 2];
            //koreksiBobot3 = new double[jumlahVariableHiddenLayer2 * 2];
            //portion3 = new double[jumlahVariableHiddenLayer2 * 2];
            //for (int i=0;i< jumlahVariableHiddenLayer2 * 2;i++)
            //{
            //    bobot3[i] = double.Parse(tb_wc.Text);
            //}

            //Random rand = new Random();
            //double nilaiRandom = 0;
            //for (int i=0;i<40;i++)
            //{
            //    nilaiRandom = rand.Next(0, 9)*0.1 + rand.Next(0, 9) * 0.01;
            //    dataX[i] = nilaiAcuanX[i / 10] - 0.5 + nilaiRandom;

            //    nilaiRandom = rand.Next(0, 9) * 0.1 + rand.Next(0, 9) * 0.01;
            //    dataY[i] = nilaiAcuanY[i / 10] - 0.5 + nilaiRandom;

            //    output[i] = i / 10 + 1;

            //    //Console.WriteLine("(" + dataX[i] + "," + dataY[i] + ") = " + output[i]);
            //}




            //for (int i = 0; i < 40; i++)
            //{
            //    //feedforward
            //    for (int j = 0; j < jumlahVariableHiddenLayer1; j++)
            //    {
            //        layer1[j] = bobot1[j * 2] * dataX[i] + bobot1[j * 2 + 1] * dataY[i];
            //        sigmoid1[j] = 1 / (1 + Math.Exp(-1 * layer1[j]));
            //    }

            //    for (int j = 0; j < jumlahVariableHiddenLayer2; j++)
            //    {
            //        layer2[j] = 0;
            //        for (int k = 0; k < jumlahVariableHiddenLayer1; k++)
            //        {
            //            layer2[j] += bobot2[j * jumlahVariableHiddenLayer1 + k] * sigmoid1[k];
            //        }
            //        sigmoid2[j] = 1 / (1 + Math.Exp(-1 * layer2[j]));
            //    }

            //    for (int j = 0; j < 2; j++)
            //    {
            //        layerOut[j] = 0;
            //        for (int k = 0; k < jumlahVariableHiddenLayer2; k++)
            //        {
            //            layerOut[j] += bobot3[j * jumlahVariableHiddenLayer2 + k] * sigmoid2[k];
            //        }
            //        sigmoidOut[j] = 1 / (1 + Math.Exp(-1 * layerOut[j]));
            //    }


            //    //Back Propagation dari errornya

            //    //mendapatkan output yang diinginkan
            //    if (output[i] == 1)
            //    {
            //        outputYangDiinginkan[0] = 0;
            //        outputYangDiinginkan[1] = 0;
            //    }
            //    else if (output[i] == 2)
            //    {
            //        outputYangDiinginkan[0] = 0;
            //        outputYangDiinginkan[1] = 1;
            //    }
            //    else if (output[i] == 3)
            //    {
            //        outputYangDiinginkan[0] = 1;
            //        outputYangDiinginkan[1] = 0;
            //    }
            //    else
            //    {
            //        outputYangDiinginkan[0] = 1;
            //        outputYangDiinginkan[1] = 1;
            //    }

            //    //menghitung portion of error correction weight adjustment
            //    for (int j=0;j<2;j++)
            //    {
            //        for(int k=0;k<jumlahVariableHiddenLayer2;k++)
            //        {
            //            portion3[j * jumlahVariableHiddenLayer2 + k] = (outputYangDiinginkan[j] - sigmoidOut[j]) * sigmoidOut[j] * (1 - sigmoidOut[j]);
            //            koreksiBobot3[j * jumlahVariableHiddenLayer2 + k] = learningRate * portion3[j * jumlahVariableHiddenLayer2 + k] * sigmoid2[k];
            //        }
            //    }

            //    for (int j = 0; j < jumlahVariableHiddenLayer1; j++)
            //    {
            //        for (int k = 0; k < jumlahVariableHiddenLayer2; k++)
            //        {
            //            portion2[] = (outputYangDiinginkan[j] - sigmoidOut[j]) * sigmoidOut[j] * (1 - sigmoidOut[j]);
            //            layer1[j] += bobot2[j * jumlahVariableHiddenLayer1 + k] * sigmoid1[k];
            //        }
            //        sigmoid2[j] = 1 / (1 + Math.Exp(-1 * layer2[j]));
            //    }


            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadData();

            ConstructNetwork();

            for (int i=0;i<40;i++)
            {
                input[0].value = dataX[i];
                input[1].value = dataY[i];

                //layer 1
                for (int j=0;j<layerPertama.Count;j++)
                {
                    layerPertama[j].value = 0;
                    for (int k=0;k<layerPertama[j].backwardPointer.Count;k++)
                    {
                        layerPertama[j].value += layerPertama[j].backwardPointer[k].weight * layerPertama[j].backwardPointer[k].back.value;
                    }
                    layerPertama[j].sigmoid = 1 / (1 + Math.Exp(-1 * layerPertama[j].value));
                }

                //layer2
                for (int j=0;j<layerKedua.Count;j++)
                {
                    layerKedua[j].value = 0;
                    for (int k=0;k<layerKedua[j].backwardPointer.Count;k++)
                    {
                        layerKedua[j].value += layerKedua[j].backwardPointer[k].weight * layerKedua[j].backwardPointer[k].back.sigmoid;
                    }
                    layerKedua[j].sigmoid = 1 / (1 + Math.Exp(-1 * layerKedua[j].value));
                }

                //layerOutput
                for (int j=0;j< output.Count;j++)
                {
                    output[j].value = 0;
                    for (int k=0;k<output[j].backwardPointer.Count;k++)
                    {
                        output[j].value += output[j].backwardPointer[k].weight * output[j].backwardPointer[k].back.sigmoid;
                    }
                    output[j].sigmoid = 1 / (1 + Math.Exp(-1 * output[j].value));
                }
            }

        }

        void ReadData()
        {
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
                nilaiRandom = rand.Next(0, 9) * 0.1 + rand.Next(0, 9) * 0.01;
                dataX[i] = nilaiAcuanX[i / 10] - 0.5 + nilaiRandom;

                nilaiRandom = rand.Next(0, 9) * 0.1 + rand.Next(0, 9) * 0.01;
                dataY[i] = nilaiAcuanY[i / 10] - 0.5 + nilaiRandom;

                kelas[i] = i / 10 + 1;

                //Console.WriteLine("(" + dataX[i] + "," + dataY[i] + ") = " + output[i]);
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
    }
}
