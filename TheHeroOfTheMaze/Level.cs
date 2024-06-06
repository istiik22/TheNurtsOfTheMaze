using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    internal class Level
    {
        Control cntrl;
        protected DataGridView dataGridViewField;
        Bitmap imageWall, imageRoad, imagePlayer, imageEnd, imageRope, imageSkin, imageFung;
        protected int[,] arrayCells;
        int x, y;
        Label steps;
        string[] strings;

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
                    if (arrayCells[i, j] == 0)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageRoad;
                    }
                    if (arrayCells[i, j] == 1)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageWall;
                    }
                    if (arrayCells[i, j] == 2)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imagePlayer;
                    }
                    if (arrayCells[i, j] == 3)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageEnd;
                    }
                    if (arrayCells[i, j] == 4)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageFung;
                    }
                    if (arrayCells[i, j] == 5)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageSkin;
                    }
                    if (arrayCells[i, j] == 6)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = imageRope;
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
        public void Lvl_1()
        {
            ArrayLvl();
            string[] one = strings[0].Split(','); 
            Basis(one);
            
        }
        public void Lvl_2()
        {
            ArrayLvl();
            string[] one = strings[1].Split(',');
            Basis(one);
        }
        public void Lvl_3()
        {
            ArrayLvl();
            string[] one = strings[2].Split(',');
            Basis(one);
        }
        public void Lvl_4() 
        {
            ArrayLvl();
            string[] one = strings[3].Split(',');
            Basis(one);
        }
        public void Lvl_5()
        {
            ArrayLvl();
            string[] one = strings[4].Split(',');
            Basis(one);
        }
    }
}
