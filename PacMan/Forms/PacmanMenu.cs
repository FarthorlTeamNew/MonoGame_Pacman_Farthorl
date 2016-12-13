namespace Pacman.Forms
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Pacman.Core;
    using Pacman.Data;
    using Pacman.Enums;
    using System.Drawing;

    public partial class PacmanMenu : Form
    {
        public PacmanMenu()
        {
            this.InitializeComponent();
            this.AnimationButtons();
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

            //Fill User statistic
            this.LastLevel.Text = DataBridge.GetLastPlayedGame();
            this.UserTotalPoints.Text = DataBridge.GetUserTotalPoints();
            this.UserComplateLevels.Text = DataBridge.GetUserComplateLevels();
            this.UserNonCompleateLevels.Text = DataBridge.UserNonCompleateLevels();
            this.UserTotalDuration.Text = DataBridge.UserTotalDuration();

            //Fill Total statistic
            this.TotalPlayers.Text = DataBridge.GetTotalPlayers();
            this.TotalPoints.Text = DataBridge.GetTotalPoints(); ;
            this.ComplateLevels.Text = DataBridge.GetComplateLevels(); ;
            this.NonCompleateLevels.Text = DataBridge.NonCompleateLevels(); ;
            this.TotalDuration.Text = DataBridge.TotalDuration(); ;
        }

        private void statisticButton_Click(object sender, EventArgs e)
        {
            var statisticForm = new Statistic();
            //this.Hide();
            statisticForm.Show();
        }
        private void AnimationButtons()
        {
            this.StartEasyGame.BackColor = Color.LightGreen;
            this.StartEasyGame.ForeColor = Color.Blue;
            this.StartEasyGame.Font = new Font(this.StartEasyGame.Font.FontFamily, 12);
            this.StartHardGame.Font = new Font(this.StartHardGame.Font.FontFamily, 12);
            this.StartHardGame.BackColor = Color.LightGreen;
            this.StartEasyGame.DialogResult = DialogResult.OK;
            this.statisticButton.BackColor = Color.Coral;
            this.StartHardGame.ForeColor = Color.Red;
            this.UpdateButton.BackColor = Color.Coral;
            this.RetrieveInput.BackColor = Color.LightGreen;
            this.RetrieveInput.ForeColor = Color.Blue;
            this.RetrieveInput.Font = new Font(FontFamily.GenericMonospace, 10.6f);
            this.FriendIdBox.ForeColor = Color.Red;
            this.FriendIdBox.BackColor = Color.LightGreen;
            this.LevelsComboBox.BackColor = Color.LightGreen;
            this.LevelsComboBox.ForeColor = Color.Blue;
            this.LevelsComboBox.Tag = Color.LightGreen;



        }

        private void RetrieveInput_Click(object sender, EventArgs e)
        {
            string friendId = this.FriendIdBox.Text;
            string operationResult = DataBridge.AddRemoveFriend(friendId);
            DialogResult dialog = MessageBox.Show(operationResult);
        }

        private void RetrieveInput_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TotalDuration_Click(object sender, EventArgs e)
        {

        }

        private void TotalPlayers_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
