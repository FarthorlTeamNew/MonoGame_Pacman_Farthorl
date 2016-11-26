using System;
using System.Collections.Generic;
using System.Linq;
using Pacman.Data;
using Pacman.Models;
using System.Windows.Forms;

namespace Pacman
{
    using Core;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Login());
            //using (var game = new Engine())
            //{
            //    game.Run();
            //}
        }

       
    }
}