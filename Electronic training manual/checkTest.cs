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

namespace Electronic_training_manual
{ 
    public partial class checkTestForm : Form
    {
        public checkTestForm()
        {
            InitializeComponent();
            LoadFiles(); // Вызываем метод загрузки файлов при инициализации формы
        }

        private void LoadFiles()
        {
            string folderPath = "save";
            string[] files = Directory.GetFiles(folderPath, "*.txt");

            foreach (string file in files)
            {
                listBox1.Items.Add(Path.GetFileName(file));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            string selectedFile = Path.Combine("save", listBox1.SelectedItem.ToString());
            string content = File.ReadAllText(selectedFile);

            MessageBox.Show(content);
        }
    }
}


