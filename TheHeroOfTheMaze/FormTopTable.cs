using System;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    public partial class FormTopTable : Form
    {
        string[] lines;
        public static bool flagExitLvl = false;
        public static int flagExitLvlEver = 0;
        public static int lineIndex = 0;

        public FormTopTable()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string path = "Top.txt";
            FailTop(path);
            dataGridViewTableTop.Rows.Add(lines.Length + 1);

            RealiseTable();
        }
        public void FailTop(string path)
        {
            if (File.Exists(path))
            {
                lines = File.ReadAllLines(path);
            }
        }
        public void RealiseTable()
        {
            int h = 0;
            for (int i = 0; i < dataGridViewTableTop.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewTableTop.ColumnCount; j += 2)
                {
                    if (h < lines.Length)
                    {
                        string[] parts = lines[h].Split(':');
                        dataGridViewTableTop.Rows[i].Cells[j].Value = parts[0].Trim();
                        dataGridViewTableTop.Rows[i].Cells[j + 1].Value = parts[1].Trim();
                        h++;
                    }
                    else
                    {
                        dataGridViewTableTop.Rows[i].Cells[j].Value = "";
                        dataGridViewTableTop.Rows[i].Cells[j + 1].Value = "";
                    }
                }
            }
        }

        private void buttonExitLvl_Click(object sender, EventArgs e)
        {
            FormGame.exit= -1;
            lineIndex++;

            this.Close();
        }
    }
}

