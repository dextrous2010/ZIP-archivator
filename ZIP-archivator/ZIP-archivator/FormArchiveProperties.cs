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

namespace ZIP_archivator
{
    public partial class FormArchiveProperties : Form
    {

        //змінні для архівації
        public static string fullPathTofile, fullPathToDirectory, saveDirectory;

        public FormArchiveProperties()
        {
            InitializeComponent();
        }

        private void ArchiveProperties_Load(object sender, EventArgs e)
        {
            textBox1.Text = fullPathToDirectory + @"\" + System.IO.Path.GetFileNameWithoutExtension(fullPathTofile) + @".zip";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(fullPathTofile))
                {
                    using (ZipFile zip = new ZipFile())
                    {

                        zip.AddFile(fullPathTofile);
                        zip.Save(textBox1.Text);

                    }
                    //MessageBox.Show("This is file");
                }
                else if (System.IO.Directory.Exists(fullPathTofile))
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddDirectory(fullPathTofile);
                        zip.Save(textBox1.Text);
                    }
                    //MessageBox.Show("This is directory");
                }

                MessageBox.Show("Done!");

            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("You cannot archive a system file!");
            }

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

            saveDirectory = tempPath + @"\" + System.IO.Path.GetFileNameWithoutExtension(fullPathTofile) + @".zip";
            textBox1.Text = saveDirectory;

            //MessageBox.Show(saveDirectory);

            // MessageBox.Show("'Browse' in progress");
        }
    }
}
