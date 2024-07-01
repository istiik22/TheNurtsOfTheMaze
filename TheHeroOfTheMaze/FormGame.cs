using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    public partial class FormGame : Form
    {
        Level level;
        Control control;
        int[,] arrayCells = new int[15, 15];
        int numberOfSteps = 0;
        int x, y;
        int ticks = 0;
        int[] one = new int[225];

        string[] hist;
        public static string[] lines;

        public static int nextLevel = 0;
        public static int exit = 1;

        string filePath = "Top.txt";


        //работа с файлом рейтинга
        private List<Registration> ReadRegistrationsFromFile(string filePath)
        {
            List<Registration> registrations = new List<Registration>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {

                    if (line == "Имя: баллы")
                        continue;


                    string[] parts = line.Split(':');

                    if (parts.Length == 2)
                    {
                        string name = parts[0].Trim();
                        if (int.TryParse(parts[1].Trim(), out int rating))
                        {
                            Registration registration = new Registration();
                            registration.Name = name;
                            registration.Rating = rating;

                            registrations.Add(registration);
                        }
                    }
                }
            }

            return registrations;
        }

        //считывание с файла
        public void array()
        {
            string path = "files/base.txt";

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
            }
        }
       
        //управление вверх
        private void buttonUp_Click(object sender, EventArgs e)
        {
            control.UpClick();
            NextLevels();
            nextLevel = 0;
        }
        //управление вправо
        private void buttonRight_Click(object sender, EventArgs e)
        {
            control.RightClick();
            NextLevels();
            nextLevel = 0;
        }
        //управление вниз
        private void buttonDown_Click(object sender, EventArgs e)
        {
            control.DownClick();
            NextLevels();
            nextLevel = 0;
        }
        //управление влево
        private void buttonLeft_Click(object sender, EventArgs e)
        {
           control.LeftClick();
            NextLevels();
            nextLevel = 0;
        }
        //новая игра
        private void NewGameLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numberOfSteps=0;
            labelSteps.Text = numberOfSteps.ToString();
            level.DrawLabirint();
            ticks = 0;
            labelTime.Text = ticks.ToString();
            timerGame.Stop();
            LevelNumb();
        }
        
        private void FormBoss_Load(object sender, EventArgs e)
        {
            
            dataGridViewField.Rows.Add(15);
            level = new Level(dataGridViewField,  labelSteps, arrayCells);
            level.DrawLabirint();
            LevelNumb();
            array();         
        }
        //текст истории
        private void TextHistory(int n1, int n2)
        {
            for (int i = n1; i <= n2; i++)
            {
                labelHistoryText.Text += hist[i];
                labelHistoryText.Text += "\n";
            }
        }
        //вызывает нужный уровень
        public void LevelNumb()
        {
            HistoryGame();
            if (FormLevels.numblvl == 1)
            {
                level.Lvl(FormLevels.numblvl);
                RealizationLvl();                
            }
            if (FormLevels.numblvl == 2)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(6, 10);
                }
                level.Lvl(FormLevels.numblvl);
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 3)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(11, 13);
                }
                level.Lvl(FormLevels.numblvl);
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 4)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(14, 16);
                }
                level.Lvl(FormLevels.numblvl);
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 5 && FormLevels.history == 1)
            {
                MessageBox.Show(lines[5]);
                if (FormLevels.history == 1)
                {
                    TextHistory(17, 19);
                }
                level.Lvl(FormLevels.numblvl);

                RealizationLvl();
                List<Registration> registrations = ReadRegistrationsFromFile(filePath);

                AddRegistration(registrations, RegistrationName.nickname, RegistrationName.time);

                registrations.Sort((reg1, reg2) => reg1.Rating.CompareTo(reg2.Rating));

                WriteRegistrationsToFile(filePath, registrations);

            }
            if (FormLevels.numblvl == -1) 
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(1, 5);
                }
                
                FormLevels.numblvl = 1;
                level.Lvl(FormLevels.numblvl);
                control = new Control(dataGridViewField, labelSteps, x, y, arrayCells, timerGame, labelTime);
                NastroikiLvl();
                labelTextLevel.Text = FormLevels.historystr;
                
            }
        }
        //считывает данные истории с файла
        private void HistoryGame()
        {
            string path = "files/history.txt";

            if (File.Exists(path))
            {
                hist = File.ReadAllLines(path);
            }
        }

        private void RealizationLvl()
        {
            control = new Control(dataGridViewField, labelSteps, x, y, arrayCells, timerGame, labelTime);
            NastroikiLvl();
            if (FormLevels.history == 1)
            {
                labelTextLevel.Text = FormLevels.historystr;

            }
            else
            {
                labelTextLevel.Text = "Уровень " + FormLevels.numblvl;
            }
            
        }
        //начальное значение уровня
        public void NastroikiLvl()
        {
            x = 0;
            y = 0;
            ticks = 0;
            labelTime.Text = ticks.ToString();
            timerGame.Stop();
            timerGame.Start();
        }
        //таймер
        private void timerGame_Tick(object sender, EventArgs e)
        {
            ticks++;
            labelTime.Text = ticks.ToString();
        }

        public FormGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        
        //добавление игрока в топ
        void AddRegistration(List<Registration> registrations, string name, int rating)
        {
            Registration newRegistration = new Registration();
            newRegistration.Name = name;
            newRegistration.Rating = rating;

            registrations.Add(newRegistration);
        }
        // Запись отсортированных данных в файл
        void WriteRegistrationsToFile(string filePath, List<Registration> registrations)
        {           
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Имя: Баллы");
                foreach (var registration in registrations)
                {
                    writer.WriteLine(registration.Name + ": " + registration.Rating);
                }
            }
        }

        //об игре
        private void RulesGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lines[2]);

        }
        //управление с клавиатуры
        private void FormBoss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                control.LeftClick();
                NextLevels();
                nextLevel = 0;
            }
            if(e.KeyCode == Keys.Right)
            {
                control.RightClick();
                NextLevels();
                nextLevel = 0;
            }
            if (e.KeyCode == Keys.Up)
            {
                control.UpClick();
                NextLevels();
                nextLevel = 0;
            }
            if (e.KeyCode== Keys.Down)
            {
                control.DownClick();
                NextLevels();
                nextLevel = 0;
            }
        }
        //переход на следующий уровень
        private void NextLevels()
        {
            if (nextLevel == 1)
            {
                LevelNumb();
            }
        }
        //выход в форму с историями и уровнями
        private void buttonExit_Click(object sender, EventArgs e)
        {
            exit=0;
            Close();
            FormLevels.flagclose = false;

        }      
    }   
}
