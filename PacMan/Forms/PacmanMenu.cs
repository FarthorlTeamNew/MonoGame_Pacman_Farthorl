using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.Core;

namespace Pacman.Forms
{
    public partial class PacmanMenu : Form
    {
        public PacmanMenu()
        {
            InitializeComponent();
        }

        private void PacmanMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (var game = new Engine())
            {
                game.Run();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var profileUpdate = new RegisterUpdate(Enums.FormEnumerable.Update);
            Hide();
            profileUpdate.Show();
        }
    }
}
