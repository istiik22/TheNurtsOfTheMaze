using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    internal class Level
    {
        protected DataGridView dataGridViewField;
        Bitmap imageWall, imageRoad, imagePlayer, imageEnd, imageRope, imageSkin, imageFung;
        protected int[,] arrayCells;
        int x, y;
        Label steps;
        string[] strings;

        private const int Road = 0;
        private const int Wall = 1;
        private const int Player = 2;
        private const int End = 3;
        private const int Fung = 4;
        private const int Skin = 5;
        private const int Rope = 6;
        public Level(DataGridView dataGridViewField, Label steps, int[,] arrayCells)
        {
            this.imageRoad = new Bitmap("image/земля.png");
            this.imageWall = new Bitmap("image/Road.png");
            this.imagePlayer = new Bitmap("image/Player1.png");
            this.imageEnd = new Bitmap("image/светлоедерево.png");
            this.imageRope = new Bitmap("image/веревка.png");
            this.imageSkin = new Bitmap("image/кожа.png");
            this.imageFung = new Bitmap("image/фынг.png");
            this.dataGridViewField = dataGridViewField;
            this.steps = steps;
            this.arrayCells = arrayCells;

        }
        public void DrawLabirint()
        {
            for (int i = 0; i < dataGridViewField.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                {
                    arrayCells[i, j] = 0;
                    dataGridViewField.Rows[i].Cells[j].Value =imageRoad;
                }
            }
        }
        public void DrawLabirintGame()
        {
            for (int i = 0; i < dataGridViewField.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                {
                    int cellType = arrayCells[i, j];

                    switch (cellType)
                    {
                        case Road:
                            dataGridViewField.Rows[i].Cells[j].Value = imageRoad;
                            break;
                        case Wall:
                            dataGridViewField.Rows[i].Cells[j].Value = imageWall;
                            break;
                        case Player:
                            dataGridViewField.Rows[i].Cells[j].Value = imagePlayer;
                            break;
                        case End:
                            dataGridViewField.Rows[i].Cells[j].Value = imageEnd;
                            break;
                        case Fung:
                            dataGridViewField.Rows[i].Cells[j].Value = imageFung;
                            break;
                        case Skin:
                            dataGridViewField.Rows[i].Cells[j].Value = imageSkin;
                            break;
                        case Rope:
                            dataGridViewField.Rows[i].Cells[j].Value = imageRope;
                            break;
                        default:
                            
                            break;
                    }
                }
            }
        }
        public void ArrayLvl()
        {
            string path = "files/lvl.txt";

            if (File.Exists(path))
            {
                strings = File.ReadAllLines(path);
            }
        }
        public void Basis(string[] lvl)
        {
            int p = 0;
            for (int i = 0; i < dataGridViewField.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                {
                    arrayCells[i, j] = Convert.ToInt32(lvl[p]);

                    if (Convert.ToInt32(lvl[p]) == 2)
                    {
                        x = i;
                        y = j;

                    }
                    p++;
                }
            }
            DrawLabirintGame();
        }

        public void Lvl(int numblevel)
        {
            ArrayLvl();
            string[] one = strings[numblevel-1].Split(',');
            Basis(one);

        }
    }
}
