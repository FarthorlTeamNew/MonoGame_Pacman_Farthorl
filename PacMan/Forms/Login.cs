
namespace Pacman.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Pacman.Data;
    using Pacman.Models.Attributes;

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var register = new RegisterUpdate(Enums.FormEnumerable.Register);
            Hide();
            register.Show();

        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            this.LoginButton.Text = "Please wait...";
            this.LoginButton.Enabled = false;
            this.RegisterButton.Enabled = false;

            DataBridge.LogInUser(this.Username.Text, this.Password.Text);

            if (DataBridge.UserIsLogin())
            {
                var pacmanMenu = new PacmanMenu();
                Hide();
                pacmanMenu.Show();
            }
            else
            {
                MessageBox.Show("The User not found.Please try again.");
            }

            this.LoginButton.Text = "Login";
            this.RegisterButton.Enabled = true;

        }

        private void LoginButton_Validating(object sender)
        {

            Password pass = new Password(6, 50);
            Email email = new Email();

            if (email.IsValid(this.Username.Text))
            {
                this.Username.BackColor = Color.Aquamarine;
            }
            else
            {
                this.Username.BackColor = Color.LightCoral;
            }

            if (pass.IsValid(this.Password.Text) && this.Password.Text != this.Password.PlaceHolderText)
            {
                this.Password.BackColor = Color.Aquamarine;
            }
            else
            {
                this.Password.BackColor = Color.LightCoral;
            }

            if (email.IsValid(this.Username.Text) && pass.IsValid(this.Password.Text) && this.Password.Text != this.Password.PlaceHolderText)
            {
                this.LoginButton.Enabled = true;
            }
            else
            {
                this.LoginButton.Enabled = false;
            }

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Username_TextChanged_1(object sender, EventArgs e)
        {
            CancelEventArgs arg = new CancelEventArgs();
            LoginButton_Validating(null);
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (this.Password.Text == this.Password.PlaceHolderText &&
                this.Password.UseSystemPasswordChar == true)
            {
                this.Password.UseSystemPasswordChar = false;
            }

            if (this.Password.Text != this.Password.PlaceHolderText &&
                this.Password.UseSystemPasswordChar == false &&
                this.Password.Text.Length > 0)
            {
                this.Password.UseSystemPasswordChar = true;
            }

            LoginButton_Validating(null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.LoginButton.Text == "Please wait...")
            {
                this.LoginButton.Text = "Please wait.";

            }
            else if (this.LoginButton.Text == "Please wait.")
            {
                this.LoginButton.Text = "Please wait..";
            }
            else if (this.LoginButton.Text == "Please wait..")
            {
                this.LoginButton.Text = "Please wait...";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            PacmanContext context = new PacmanContext();

            context.Database.Initialize(true);
            this.ActiveControl = this.Username;
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (string.IsNullOrEmpty(this.Password.Text) || this.Password.Text == this.Password.PlaceHolderText)
                {
                    this.ActiveControl = this.Password;
                }
                else if (this.LoginButton.Enabled)
                {
                    LoginButton_Click(sender, e);
                }
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (string.IsNullOrEmpty(this.Username.Text) || this.Username.Text == this.Username.PlaceHolderText)
                {
                    this.ActiveControl = this.Username;
                }
                else if (this.LoginButton.Enabled)
                {
                    LoginButton_Click(sender, e);
                }

            }
        }
    }
}