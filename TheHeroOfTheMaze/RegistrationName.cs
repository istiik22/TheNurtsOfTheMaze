using System;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    public partial class RegistrationName : Form
    {
        public static string nickname;
        public static int time = 0;
        public RegistrationName()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonGame_Click(object sender, EventArgs e)
        {
            nickname = textBoxName.Text;
            Close();
        }
    }
}
