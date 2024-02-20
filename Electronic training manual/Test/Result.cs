using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Electronic_training_manual
{
    public partial class Final : Form
    {
        double Mark; //Средний балл

        public Final()
        {
            InitializeComponent();
        }

        public Final(string PersonName, string Theme, int NumbersOfQwest, int RightAnswers, int nepqw, List<string> errors)
        {
            InitializeComponent();

            //Заполняем текстовые поля
            label1.Text += PersonName;
            ThemeLabel.Text = Theme;
            NumbersLabel.Text += NumbersOfQwest.ToString(); // количество вопросов
            RightLabel.Text += RightAnswers.ToString(); // правильные ответы
            nepqw1.Text += nepqw; //неправильные ответы
            foreach (string str in errors)
            {
                errorsLable.Text += "\n" + str ;
            }


            //Вычисляем оценку
            double percentage = ((double)RightAnswers / NumbersOfQwest) * 100;
            int Mark;

            if (percentage >= 90)
            {
                Mark = 5;
                MarkLabel.ForeColor = Color.Green;
            }
            else if (percentage >= 70)
            {
                Mark = 4;
                MarkLabel.ForeColor = Color.Green;
            }
            else if (percentage >= 50)
            {
                Mark = 3;
                MarkLabel.ForeColor = Color.Yellow;
            }
            else if (percentage >= 0)
            {
                Mark = 2;
                MarkLabel.ForeColor = Color.Red;
            }
            else
            {
                Mark = 2;
                MarkLabel.ForeColor = Color.Red;
            }

            //Выводим оценку
            MarkLabel.Text += Mark.ToString();

        }

        


        private void TestirForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Final_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) // выход
        {
            string res = string.Format(label1.Text + "\n" + ThemeLabel.Text + "\n" + MarkLabel.Text + "\n");
            string path = Path.Combine(Application.StartupPath, "save");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            File.WriteAllText(Path.Combine(path, string.Format("{0}.txt", label1.Text.Remove(0, label1.Text.IndexOf(':') + 1))), res);
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e) // меню
        {
            string res = string.Format(label1.Text + "\n" + ThemeLabel.Text + "\n" + MarkLabel.Text + "\n");
            string path = Path.Combine(Application.StartupPath, "save");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            File.WriteAllText(Path.Combine(path, string.Format("{0}.txt", label1.Text.Remove(0, label1.Text.IndexOf(':') + 1))), res);
            Menu f = new Menu();
            f.Show();
            this.Visible = false;
        }

        private void MarkLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
