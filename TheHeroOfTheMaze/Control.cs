using System;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    internal class Control : Level
    {
        int x, y;
        int numberOfSteps = 0;
        System.Windows.Forms.Label labelSteps;
        System.Windows.Forms.Label timeEnd;
        Timer timerGame;
        int leatherRopeFung = 0;

        public Control(DataGridView dataGridViewField, System.Windows.Forms.Label labelSteps,int x,int y, int[,] arrayCells,Timer timerGame, System.Windows.Forms.Label timeEnd) : base(dataGridViewField, labelSteps, arrayCells)
        {
            this.x = x;
            this.y = y;
            this.labelSteps = labelSteps;
            this.timerGame = timerGame;
            this.timeEnd = timeEnd;
        }

        
        private void End()
        {
            timerGame.Stop();
            MessageBox.Show("Вы вышли из лабиринта за количество секунд, равное " + timeEnd.Text + "!");
            FormLevels.levelPerson++;
            numberOfSteps = 0;
            timeEnd.Text = "0";
            labelSteps.Text = numberOfSteps.ToString();
            DrawLabirint();
        }
        public void UpClick()
        {
            if (y - 1 >= 0 && y - 1 <= dataGridViewField.RowCount - 1)
            {
                if (arrayCells[y - 1, x] == 0 || arrayCells[y-1, x] == 4 || arrayCells[y-1, x] == 5 || arrayCells[y-1, x] == 6)
                {
                    if (arrayCells[y - 1, x] == 4 || arrayCells[y - 1, x] == 5 || arrayCells[y - 1, x] == 6)
                    {
                        leatherRopeFung++;
                    }
                    arrayCells[y - 1, x] = 2;
                    arrayCells[y, x] = 0;
                    numberOfSteps++;
                    labelSteps.Text = numberOfSteps.ToString();
                    DrawLabirintGame();
                    y--;
                }
                else if (arrayCells[y - 1, x] == 3)
                {
                    if (FormLevels.numblvl == 5 && leatherRopeFung == 3)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text)+Convert.ToInt32(labelSteps.Text);
                        arrayCells[y - 1, x] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        y--;
                       
                        End();

                    }
                    else if (FormLevels.numblvl == 5 && leatherRopeFung != 3)
                    {
                        MessageBox.Show("Вы собрали еще не все!");
                    }
                    else if (FormLevels.numblvl < 5)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y - 1, x] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        y--;
                        
                        End();
                    }
                    
                }
                
                else if (arrayCells[y - 1, x] == 2)
                {
                    MessageBox.Show("Осторожно, стена!");
                }
            }
            else
            {
                MessageBox.Show("Осторожно, стена!");
            }
        }

        public void RightClick()
        {
            if (x + 1 >= 0 && x + 1 <= dataGridViewField.RowCount - 1)
            {
                if (arrayCells[y, x + 1] == 0 || arrayCells[y, x + 1] == 4 || arrayCells[y, x + 1] == 5 || arrayCells[y, x + 1] == 6)
                {
                    if (arrayCells[y, x + 1] == 4 || arrayCells[y, x + 1] == 5 || arrayCells[y, x + 1] == 6)
                    {
                        leatherRopeFung++;
                    }
                    arrayCells[y, x + 1] = 2;
                    arrayCells[y, x] = 0;
                    numberOfSteps++;
                    labelSteps.Text = numberOfSteps.ToString();
                    DrawLabirintGame();
                    x++;
                }
                else if (arrayCells[y, x + 1] == 3)
                {
                    if (FormLevels.numblvl == 5 && leatherRopeFung == 3)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y, x + 1] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        x++;
                        
                        FormLevels.numblvl++;
                        FormGame.nextLevel++;
                        End();
                    }
                    else if (FormLevels.numblvl == 5 && leatherRopeFung != 3)
                    {
                        MessageBox.Show("Вы собрали еще не все!");
                    }
                    else if (FormLevels.numblvl < 5)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y, x + 1] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        x++;
                       
                        FormLevels.numblvl++;
                        FormGame.nextLevel++;
                        End();
                    }
                }
                else if (arrayCells[y, x + 1] == 2)
                {
                    MessageBox.Show("Осторожно, стена!");
                }
            }
            else
            {
                MessageBox.Show("Осторожно, стена!");
            }
        }

        public void LeftClick()
        {
            if (x - 1 >= 0 && x - 1 <= dataGridViewField.RowCount - 1)
            {
                if (arrayCells[y, x - 1] == 0 || arrayCells[y, x - 1] == 4 || arrayCells[y, x - 1] == 5 || arrayCells[y, x - 1] == 6)
                {
                    if(arrayCells[y, x - 1] == 4 || arrayCells[y, x - 1] == 5 || arrayCells[y, x - 1] == 6)
                    {
                        leatherRopeFung++;
                    }
                    arrayCells[y, x - 1] = 2;
                    arrayCells[y, x] = 0;
                    numberOfSteps++;
                    labelSteps.Text = numberOfSteps.ToString();
                    DrawLabirintGame();
                    x--;
                }
                else if (arrayCells[y, x - 1] == 3)
                {
                    if (FormLevels.numblvl == 5 && leatherRopeFung == 3)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y, x - 1] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        x--;
                        
                        FormLevels.numblvl++;
                        End();
                    }

                    else if (FormLevels.numblvl == 5 && leatherRopeFung != 3)
                    {
                        MessageBox.Show("Вы собрали еще не все!");
                    }
                    else if (FormLevels.numblvl < 5)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y, x - 1] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        x--;
                        
                        FormLevels.numblvl++;
                        End();
                    }
                }
                else if (arrayCells[y, x - 1] == 2)
                {
                    MessageBox.Show("Осторожно, стена!");
                }
            }
            else
            {
                MessageBox.Show("Осторожно, стена!");
            }
        }

        public void DownClick()     
        {
            if (y + 1 >= 0 && y + 1 <= dataGridViewField.RowCount - 1)
            {
                if (arrayCells[y + 1, x] == 0 || arrayCells[y + 1, x] == 4 || arrayCells[y + 1, x] == 5 || arrayCells[y + 1, x] == 6 )
                {
                    if (arrayCells[y + 1, x] == 4 || arrayCells[y + 1, x] == 5 || arrayCells[y + 1, x] == 6)
                    {
                        leatherRopeFung++;
                    }
                    arrayCells[y + 1, x] = 2;
                    arrayCells[y, x] = 0;
                    numberOfSteps++;
                    labelSteps.Text = numberOfSteps.ToString();
                    DrawLabirintGame();
                    y++;
                }
                else if (arrayCells[y + 1, x] == 3)
                {
                    if (FormLevels.numblvl == 5 && leatherRopeFung == 3)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y + 1, x] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        y++;
                       
                        End();
                    }

                    else if (FormLevels.numblvl == 5 && leatherRopeFung != 3)
                    {
                        MessageBox.Show("Вы собрали еще не все!");
                    }
                    else if (FormLevels.numblvl < 5)
                    {
                        RegistrationName.time += Convert.ToInt32(timeEnd.Text) + Convert.ToInt32(labelSteps.Text);
                        arrayCells[y + 1, x] = 2;
                        arrayCells[y, x] = 0;
                        numberOfSteps++;
                        labelSteps.Text = numberOfSteps.ToString();
                        DrawLabirintGame();
                        y++;
                        End();
                    }
                }
                else if (arrayCells[y + 1, x] == 2)
                {
                    MessageBox.Show("Осторожно, стена!");
                }
            }
            else
            {
                MessageBox.Show("Осторожно, стена!");
            }
        }

    }
}
