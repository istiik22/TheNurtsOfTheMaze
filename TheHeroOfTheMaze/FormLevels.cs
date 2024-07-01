using System;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    public partial class FormLevels : Form
    {
        public static int numblvl;
        public static int history;
        public static string historystr;
        string[] lines;

        public static int levelPerson = 1;

        private void array()
        {
            string path = "files/base.txt";

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
            }
        }
        public FormLevels()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            array();
            flagclose = false;
            FormTopTable.flagExitLvlEver = 0;


            if (FormGame.exit != -1)
            {
                MessageBox.Show(lines[0]);
                MessageBox.Show(lines[1]);
            }
        }

        public static bool flagclose = false;

        private void level1_Click(object sender, EventArgs e)
        {
            numblvl = 1;
            Close();
            flagclose = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (levelPerson >= 2)
            {
                numblvl = 2;
                Close();
                flagclose = true;
            }
            else
            {
                MessageBox.Show(lines[6]);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (levelPerson >= 3)
            {
                numblvl = 3;
                Close();
                flagclose = true;
            }
            else
            {
                MessageBox.Show(lines[6]);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (levelPerson >= 4)
            {
                numblvl = 4;
                Close();
                flagclose = true;
            }
            else
            {
                MessageBox.Show(lines[6]);
            }
            
        }

        private void History1_Click(object sender, EventArgs e)
        {
            flagclose = true;
            numblvl = -1;
            history = 1;
            historystr = History1.Text.Trim();
            Close();
        }      

        private void buttonTop_Click_1(object sender, EventArgs e)
        {
            //FormTopTable.flagExitLvl = true;
            //Close();

            // Создаем экземпляр второй формы
            FormTopTable topTableform = new FormTopTable();

            // Скрываем текущую форму
            this.Hide();

            // Показываем вторую форму
            topTableform.Show();

        }

    }
}
