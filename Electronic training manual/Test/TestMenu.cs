using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Electronic_training_manual
{
    public partial class TestMenu : Form
    {
        XmlReader xmlThemeRead;
        DirectoryInfo testsDirectory = new DirectoryInfo("Tests"); //Создаем объект сообтветствующий папке Tests
        public TestMenu()

        {
            InitializeComponent();

            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
            {
                textbox.Dispose();
            }

            if (testsDirectory.Exists == false)
                CreateTestDir();

            comboBox1.Items.AddRange(testsDirectory.GetDirectories()); //Добавление подпапок из директории Tests
        }

        

        #region Выход
        private void exitButton_Click(object sender, EventArgs e) // Кнопка Выход
        { 
            Application.Exit();
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                this.Visible = true;
        }
#endregion 

        
        #region Создание папок
        public void CreateTestDir()
        {
            testsDirectory.Create();
            testsDirectory.CreateSubdirectory("первый");
            testsDirectory.CreateSubdirectory("второй");
            testsDirectory.CreateSubdirectory("третий");
            
        }
        #endregion


        #region Обновление ListBox'a
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ThemeLabel.Text = "Тема: "; //Принудительная очистка темы
            DirectoryInfo testsDir = new DirectoryInfo("Tests\\" + comboBox1.Text); //Создем объект соответствующий выбраной папке
            listBox1.Items.Clear(); //Очищаем listBox1

            foreach (FileInfo file in testsDir.GetFiles())
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }

            LoadButton.Enabled = false;
        }
        #endregion

        #region Выбор теста в listBox'e
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                xmlThemeRead = new XmlTextReader("Tests\\" + comboBox1.Text + "\\" + listBox1.Text + ".xml");

                // ищем узел <Theme>
                do xmlThemeRead.Read();
                while (xmlThemeRead.Name != "Theme");

                // считываем тему теста
                xmlThemeRead.Read();

                // вывести тему теста
                ThemeLabel.Text = "Тема: " + xmlThemeRead.Value;

                // выходим из узла <Theme>
                xmlThemeRead.Read();

                LoadButton.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Такого файла не существует или нет прав для его открытия!\n\t\tВыберите другой файл!", "Ошибка!");
            }
        }
        #endregion

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Введите вашу фамилию и группу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Просим ввести имя
            else
            {
                string xmlPath = "Tests\\" + comboBox1.Text + "\\" + listBox1.Text + ".xml"; //Сохраняем путь к xml - файлу
                 
                TestirForm MF = new TestirForm(xmlPath, textBox1.Text, ThemeLabel.Text); //Передаем во 2ую форму путь к тесту и имя пользователя
                MF.Show(); //Вызываем форму тестирования
                this.Visible = false; //Скрываем первую форму
            }
        }

        private void Load_Load(object sender, EventArgs e)
        {
        }

        private void ThemeLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            f.Show();
            this.Visible = false;
        }
    }
    }

