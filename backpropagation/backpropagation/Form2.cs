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
        public Form2(Bitmap gambar)
        {
            InitializeComponent();

            pictureBox1.Image = gambar;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             
        }
    }
}
