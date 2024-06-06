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

        public void array()
        {
            string path = "files/base.txt";

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
            }
        }
       
        private void buttonUp_Click(object sender, EventArgs e)
        {
            control.UpClick();
            NextLevels();
            nextLevel = 0;
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            control.RightClick();
            NextLevels();
            nextLevel = 0;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            control.DownClick();
            NextLevels();
            nextLevel = 0;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
           control.LeftClick();
            NextLevels();
            nextLevel = 0;
        }

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

        private void TextHistory(int n1, int n2)
        {

            for (int i = n1; i <= n2; i++)
            {
                labelHistoryText.Text += hist[i];
                labelHistoryText.Text += "\n";
            }
        }

        public void LevelNumb()
        {
            HistoryGame();
            if (FormLevels.numblvl == 1)
            {
                
                level.Lvl_1();
                //this.BackgroundImage = Image.FromFile("background/____.png");
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 2)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(6, 10);
                }
                
                level.Lvl_2();
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 3)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(11, 13);
                }
                
                level.Lvl_3();
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 4)
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(14, 16);
                }
                
                level.Lvl_4();
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == 5 && FormLevels.history == 1)
            {
                MessageBox.Show(lines[5]);
                if (FormLevels.history == 1)
                {
                    TextHistory(17, 19);
                }
                
                
                level.Lvl_5();
                RealizationLvl();
                
            }
            if (FormLevels.numblvl == -1) 
            {
                if (FormLevels.history == 1)
                {
                    TextHistory(1, 5);
                }
                
                FormLevels.numblvl = 1;
                level.Lvl_1();
                control = new Control(dataGridViewField, labelSteps, x, y, arrayCells, timerGame, labelTime);
                NastroikiLvl();
                labelTextLevel.Text = FormLevels.historystr;
            }
            //else
            //{
            //    exit = 0;
            //    //Close();
            //    MessageBox.Show(lines[4]);
            //}
        }

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

        public void NastroikiLvl()
        {
            x = 0;
            y = 0;
            ticks = 0;
            labelTime.Text = ticks.ToString();
            timerGame.Stop();
            timerGame.Start();
        }
     

        private void timerGame_Tick(object sender, EventArgs e)
        {
            ticks++;
            labelTime.Text = ticks.ToString();
        }

        public FormGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //array();

        }

        private void RulesGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lines[2]);

        }

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
        private void NextLevels()
        {
            if (nextLevel == 1)
            {
                LevelNumb();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            exit=0;
            Close();
            
        }

        
    }   
}
