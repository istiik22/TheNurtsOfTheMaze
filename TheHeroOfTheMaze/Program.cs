﻿using System;
using System.Windows.Forms;

namespace TheHeroOfTheMaze
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormHello());
            Application.Run(new RegistrationName());
            Application.Run(new FormLevels());                    

            if (FormLevels.flagclose == true)
            {
                Application.Run(new FormGame());

            }

            if (FormTopTable.lineIndex != 0)
            {
                Application.Run(new FormLevels());
            }

            while (FormGame.exit == 0)
            {
                FormGame.exit = -1;
                Application.Run(new FormLevels());

                if (FormTopTable.flagExitLvl == true)
                {
                    Application.Run(new FormLevels());
                }

                if (FormLevels.flagclose == true)
                {
                    Application.Run(new FormGame());
                }               
            }
        }
    }
}
