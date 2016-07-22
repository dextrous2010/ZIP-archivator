using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZIP_archivator
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
        }

        
        private void MainWindowForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormArchiveProperties newArchiveForm = new FormArchiveProperties();
            newArchiveForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Extract To' in progress");
        }
    }
}
