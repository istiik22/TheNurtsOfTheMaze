using System;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    public partial class FormHello : Form
    {
        public static int control = 0;
        string[] lines;
        public FormHello()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonPlayGame_Click(object sender, EventArgs e)
        {
            control++;
            Close();           
        }

        private void array()
        {
            string path = "files/base.txt";

            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
            }
        }
        private void buttonAuthor_Click(object sender, EventArgs e)
        {
            array();
            MessageBox.Show(lines[3]);
        }
    }
}
