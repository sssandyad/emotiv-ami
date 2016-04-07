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
    public partial class Form2 : Form
    {
        form1 f;
        public Form2(form1 form)
        {
            InitializeComponent();

            f = form;

            chart1.Series.Add("error");
            chart1.Series["error"].Color = Color.DarkRed;
            chart1.Series["error"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["error"].IsVisibleInLegend = false;

            dataGridView1.Columns.Add("Y1", "Y1");
            dataGridView1.Columns.Add("Y2", "Y2");
            dataGridView1.Columns.Add("X1", "X1");
            dataGridView1.Columns.Add("X2", "X2");
            dataGridView1.Columns.Add("Y1d", "Y1d");
            dataGridView1.Columns.Add("Y2d", "Y2d");
            
            
            for(int i=0;i<40;i++)
            {
                dataGridView1.Rows.Add(0,0,0,0,0,0);
            }
        }

        public void SetGambar(Bitmap g)
        {
            pictureBox1.Image = g;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void AddValueChart(double value)
        {
            chart1.Series["error"].Points.AddY(value);
        }

        public void ResetChart()
        {
            chart1.Series["error"].Points.Clear();
        }

        public void UpdateTable(List<double[]> data)
        {
            for (int i = 0; i < 40; i++)
            {
                dataGridView1.Rows[i].Cells["Y1"].Value = data[i][4].ToString("0.####");
                dataGridView1.Rows[i].Cells["Y2"].Value = data[i][5].ToString("0.####");
                dataGridView1.Rows[i].Cells["X1"].Value = data[i][0].ToString("0.##");
                dataGridView1.Rows[i].Cells["X2"].Value = data[i][1].ToString("0.##");
                dataGridView1.Rows[i].Cells["Y1d"].Value = data[i][2].ToString("0");
                dataGridView1.Rows[i].Cells["Y2d"].Value = data[i][3].ToString("0");
            }
            dataGridView1.Invalidate();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             
        }

        public void UpdateError(double e)
        {
            textBoxError.Text = e.ToString();
        }

        public void UpdateIterasi(int t)
        {
            textBoxIterasi.Text = t.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.StopFromOther();
        }
    }
}
