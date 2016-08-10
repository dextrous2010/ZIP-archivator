using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZIP_archivator;
using Ionic.Zip;

namespace ZIP_archivator
{
    public partial class FormArchiveProperties : Form
    {
        public string savePath, fileToZip;
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
            
            using (ZipFile zip = new ZipFile())
            {
                //textBox1.Text = savePath;
                zip.AddFile(fileToZip);
                zip.Save(savePath);
                this.Close();
            }


            MessageBox.Show("Finished!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tempPath = "";

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tempPath = folderBrowserDialog1.SelectedPath; // prints path
            }

            savePath = tempPath + @"\" + System.IO.Path.GetFileNameWithoutExtension(savePath) + @".zip";
            textBox1.Text = savePath;

            //MessageBox.Show(savePath);


            
        }

       

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
