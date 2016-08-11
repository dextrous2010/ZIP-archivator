using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;

namespace ZIP_archivator
{
    public partial class ExtractWindow : Form

    {
        //змінні для архівації
        public static string fullPathTofile, fullPathToDirectory;

        public ExtractWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExtractWindow_Load(object sender, EventArgs e)
        {
            textBox1.Text = fullPathToDirectory;
            label3.Text = Path.GetFileName(fullPathTofile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tempPath = fullPathToDirectory;

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();


            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tempPath = folderBrowserDialog1.SelectedPath; // prints path
            }

            textBox1.Text = tempPath;
            

            //MessageBox.Show(saveDirectory);

            // MessageBox.Show("'Browse' in progress");
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////-------------------extract--------------------------
            
                using (ZipFile zip = ZipFile.Read(fullPathTofile))
                {
                    zip.ExtractAll(textBox1.Text, ExtractExistingFileAction.OverwriteSilently);
                }
            
            MessageBox.Show("Done!");
            this.Close();
        }
    }
}
