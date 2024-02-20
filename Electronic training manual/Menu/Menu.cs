using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_training_manual
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) // о программе
        {
            Information f = new Information();
            f.Show();
            this.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e) // теория
        {
            Theory theory = new Theory();
            theory.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e) // тест
        {
            TestMenu f = new TestMenu();
            f.Show();
            this.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e) // выход
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkTestForm form = new checkTestForm();
            form.Show();
        }
    }
}
