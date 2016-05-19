using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEG_EMOTIV_CONTROLLER
{
    public partial class FormSaveModel : Form
    {
        FormCreateModel f;
        public FormSaveModel(FormCreateModel fcm)
        {
            InitializeComponent();
            f = fcm;
        }

        private void FormSaveModel_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            f.modelName = textBoxModelName.Text;
            f.SavingModel();
            this.Close();
        }
    }
}
