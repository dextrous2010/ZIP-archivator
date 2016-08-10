using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZIP_archivator
{
    public partial class MainWindowForm : Form
    {
        public String fullPath, fileName;
       
        public MainWindowForm()
        {
            InitializeComponent();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            for (int i = 0; i < allDrives.Length; i++)
            {
                PopulateTreeView(allDrives[i].Name);
            }

            this.treeView1.NodeMouseClick +=
    new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }


        private void MainWindowForm_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Extract To' in progress");
        }

        // Populating the TreeView with nodes and subnodes
        //
        private void PopulateTreeView(String path)
        {

            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                if ((subDir.Attributes & FileAttributes.System) != FileAttributes.System & subDir.FullName != @"C:\Windows")
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }
                    nodeToAddTo.Nodes.Add(aNode);
                }
            }
        }

        // Handle the NodeMouseClick event for treeview1, 
        // and implement the code to populate listview1 with a node's contents 
        // when a node is clicked
        //
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ImageList imageList1 = new ImageList();
            listView1.SmallImageList = imageList1;
            // listView1.View = View.SmallIcon;

    
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;


            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {

                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                          {new ListViewItem.ListViewSubItem(item, "Directory"),
                   new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);



                listView1.Items.Add(item);
            }

            

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                          { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);

                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                if (!imageList1.Images.ContainsKey(file.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                }
                item.ImageKey = file.Extension;
                listView1.Items.Add(item);
            }

            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }


        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            fullPath = null;
            fullPath = treeView1.SelectedNode.FullPath;
            // MessageBox.Show(fullPath);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            
            fullPath = null;

            fullPath = treeView1.SelectedNode.FullPath + @"\" + listView1.FocusedItem.Text;
            fileName = treeView1.SelectedNode.FullPath + @"\" + System.IO.Path.GetFileNameWithoutExtension(fullPath);
            
            MessageBox.Show(fileName);
            //listView1.Focused
            //listView1.FocusedItem.
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            FormArchiveProperties newArchiveForm = new FormArchiveProperties();
            newArchiveForm.fileToZip = fullPath;
            newArchiveForm.textBox1.Text = fileName + @".zip";
            newArchiveForm.savePath = fileName + @".zip";
            newArchiveForm.Show();

        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
