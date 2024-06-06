using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.Run(new FormLevels());
            Application.Run(new FormGame());

            while (FormGame.exit == 0)
            {
                FormGame.exit = -1;
                Application.Run(new FormLevels());
                Application.Run(new FormGame());
            }

        }
    }
}
