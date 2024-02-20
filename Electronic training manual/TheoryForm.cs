using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_training_manual
{
    public partial class Theory : Form
    {
        public string pathToTheoryDir = @"Введение";

        public Theory()
        {
            InitializeComponent();

            this.CenterToScreen();

            LoadDirectory(pathToTheoryDir);
        }

        #region FillTreeView
        private void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);

            TreeNode tds = treeView1.Nodes.Add(di.Name);

            tds.Tag = di.FullName;

            tds.StateImageIndex = 0;

            LoadFiles(Dir, tds);

            LoadSubDirectories(Dir, tds);
        }

        private void LoadSubDirectories(string dir, TreeNode td)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);

                TreeNode tds = td.Nodes.Add(di.Name);

                tds.StateImageIndex = 0;

                tds.Tag = di.FullName;

                LoadFiles(subdirectory, tds);

                LoadSubDirectories(subdirectory, tds);
            }
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] files = Directory.GetFiles(dir, "*.rtf");
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                TreeNode tds = td.Nodes.Add(fi.Name);

                tds.Tag = fi.FullName;

                tds.StateImageIndex = 1;
            }
        }
        

    
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (Path.GetExtension(treeView1.SelectedNode.FullPath) == ".rtf")
            {
                richTextBox1.LoadFile(treeView1.SelectedNode.FullPath);
            }


        }
        #endregion

        public void Theory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

            Menu main = new Menu();

            main.Show();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Theory_Load(object sender, EventArgs e)
        {
           

        }

        private void pictureBox1_Click(object sender, EventArgs e) // меню
        {
            Menu f = new Menu();
            f.Show();
            this.Visible = false;
        }
    }
}