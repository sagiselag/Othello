using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Othello
{
    internal static class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UI.NewGame();
            new OthelloGameSettings().ShowDialog();
        }
    }
}