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
    public partial class FormArchiveProperties : Form
    {
        public FormArchiveProperties()
        {
            InitializeComponent();
        }

        private void ArchiveProperties_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'OK' in progress");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Browse' in progress");
        }
    }
}
