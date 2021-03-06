﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;

namespace ZIP_archivator
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            for (int i = 0; i < allDrives.Length; i++)
            {
                PopulateTreeView(allDrives[i].Name);
            }

    //        this.treeView1.NodeMouseClick +=
    //new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }


        private void MainWindowForm_Load(object sender, EventArgs e)
        {

        }

        private void AddButtom_Click_1(object sender, EventArgs e)
        {
            if (fullPath == null)
            {
                MessageBox.Show("Please, choose the file");
            }
            else
            {
                FormArchiveProperties newArchiveForm = new FormArchiveProperties();
                newArchiveForm.Show();
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(fullPath) == null)
            {
                MessageBox.Show("File is not chosen!");
            }
            else if (Path.GetExtension(fullPath) != ".zip")
            {
                MessageBox.Show("This is not an archive");
            }

            else
            {
                ExtractWindow extractWindow = new ExtractWindow();
                extractWindow.Show();
            }
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
                if ((subDir.Attributes & FileAttributes.System) != FileAttributes.System & subDir.FullName != @"C:\Windows" & subDir.FullName != @"C:\ProgramData")
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

        TreeViewEventArgs e_dup;

        // Handle the NodeMouseClick event for treeview1, 
        // and implement the code to populate listview1 with a node's contents 
        // when a node is clicked
        //

        //void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{

        //}


        void listViewDraw()
        {

            ImageList imageList1 = new ImageList();
            listView1.LargeImageList = imageList1;

            TreeNode newSelected = e_dup.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            try
            {
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

                    // Set a default icon for the file
                    Icon iconForFile = SystemIcons.WinLogo;
                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);

                    // Check to see if the image collection contains an image
                    // for this extension, using the extension as a key

                    if (!imageList1.Images.ContainsKey(file.Extension))
                    {
                        // If not, add the image to the image list
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                        imageList1.Images.Add(file.Extension, iconForFile);
                    }
                    try
                    {
                        item.ImageKey = file.Extension;
                    }
                    catch (System.NullReferenceException) { }


                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                                              { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("This folder doesn't exist!");
            }
        }


        String fullPath;
        String fileName;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            e_dup = e;

            fullPath = null;
            fileName = treeView1.SelectedNode.Text;
            fullPath = treeView1.SelectedNode.FullPath;
            // MessageBox.Show(fullPath);

            try
            {
                FormArchiveProperties.fullPathTofile = fullPath;
                FormArchiveProperties.fullPathToDirectory = treeView1.SelectedNode.FullPath;
                ExtractWindow.fullPathTofile = fullPath;
                ExtractWindow.fullPathToDirectory = treeView1.SelectedNode.FullPath;
            }
            catch (NullReferenceException) { }

            listViewDraw();

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            fullPath = null;
            try
            {
                fullPath = treeView1.SelectedNode.FullPath + @"\" + listView1.FocusedItem.Text;
            }
            catch (NullReferenceException) {}

            try
            {
                FormArchiveProperties.fullPathTofile = fullPath;
                FormArchiveProperties.fullPathToDirectory = treeView1.SelectedNode.FullPath;
                ExtractWindow.fullPathTofile = fullPath;
                ExtractWindow.fullPathToDirectory = treeView1.SelectedNode.FullPath;
            }
            catch (NullReferenceException) { }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try { listViewDraw(); }
            catch (System.NullReferenceException) { }            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            if (Path.GetExtension(fullPath) == null)
            {
                MessageBox.Show("File is not chosen!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete It?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    // Detect whether its a directory or a file

                    try
                    {
                        if (File.GetAttributes(fullPath).HasFlag(FileAttributes.Directory))
                            try
                            {
                                Directory.Delete(fullPath);
                                MessageBox.Show("The directory was deleted!");
                            }
                            catch (System.IO.IOException)
                            {
                                MessageBox.Show("Cannot deleted!");
                            }
                            catch (System.UnauthorizedAccessException)
                            {
                                MessageBox.Show("You don't have right permissions!");
                            }
                        else
                        {
                            try
                            {
                                File.Delete(fullPath);
                                MessageBox.Show("The file was deleted!");
                            }
                            catch (System.IO.IOException)
                            {
                                MessageBox.Show("Cannot deleted!");
                            }
                            catch (System.UnauthorizedAccessException)
                            {
                                Directory.Delete(fullPath);
                                MessageBox.Show("You don't have right permissions!");
                            }
                        }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("File or directory doesn't exist!");
                    }
                }
            }  
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Archiving tool.");
        }

    }

}
