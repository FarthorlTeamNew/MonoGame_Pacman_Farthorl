using Pacman.Models;

namespace Pacman.Forms
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Pacman.Core;
    using Pacman.Data;
    using Pacman.Enums;
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var profileUpdate = new RegisterUpdate(Enums.FormEnumerable.Update);
            Hide();
            profileUpdate.Show();
        }

        private void StartNormalButton_Click(object sender, EventArgs e)
        {
            var selectedLevel = DataBridge.GetLevelByName(this.LevelsComboBox.Text);
            if (selectedLevel != null)
            {
                Hide();
                DataBridge.StartNewGame(this.LevelsComboBox.Text);
                using (var game = new Engine(selectedLevel, DifficultyEnumerable.Easy))
                {
                    game.Run();
                }
                DataBridge.EndGame();
                Show();

            }
            else
            {
                MessageBox.Show("The selected game level is invalid.");
            }
        }

        private void StartHardGame_Click(object sender, EventArgs e)
        {
            var selectedLevel = DataBridge.GetLevelByName(this.LevelsComboBox.Text);
            if (selectedLevel != null)
            {
                Hide();
                DataBridge.StartNewGame(this.LevelsComboBox.Text);
                using (var game = new Engine(selectedLevel, DifficultyEnumerable.Hard))
                {
                    game.Run();
                }
                DataBridge.EndGame();
                Show();
                
            }
            else
            {
                MessageBox.Show("The selected game level is invalid.");
            }
        }

        private void PacmanMenu_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
            var levels = DataBridge.GetAllLevels().Select(level => level.Name);
            LevelsComboBox.Items.AddRange(levels.ToArray());
            LevelsComboBox.SelectedIndex = new Random().Next(1, levels.Count());
            if (!DataBridge.UserIsLogin())
            {
                Hide();
                Login loginForm = new Login();
                loginForm.Show();            
            }
        }
    }
}
