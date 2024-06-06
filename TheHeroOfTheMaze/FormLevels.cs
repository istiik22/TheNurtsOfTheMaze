using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
            
            
            if (FormGame.exit != -1)
            {
                MessageBox.Show(lines[0]);
                MessageBox.Show(lines[1]);
            }
        }


        private void level1_Click(object sender, EventArgs e)
        {
            numblvl = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (levelPerson >= 2)
            {
                numblvl = 2;
                Close();
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
            }
            else
            {
                MessageBox.Show(lines[6]);
            }
        }

        private void History1_Click(object sender, EventArgs e)
        {
            numblvl = -1;
            history = 1;
            historystr = History1.Text.Trim();
            Close();
        }     
    }
}
