using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.Data;
using Pacman.Enums;
using Pacman.Models;
using Pacman.Models.Attributes;

namespace Pacman.Forms
{
    public partial class RegisterUpdate : Form
    {
        private List<Country> coutries;
        private List<City> cities;
        private FormEnumerable formType;
        public RegisterUpdate(Enums.FormEnumerable formType)
        {
            this.coutries = new List<Country>();
            this.cities = new List<City>();
            this.formType = formType;
            InitializeComponent();
            this.coutries.AddRange(DataBridge.GetAllCountries());
            this.cities.AddRange(DataBridge.GetAllCities());
            this.Countries.Items.AddRange(this.coutries.Select(c => c.Name).ToArray());
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DataBridge.UserIsLogin())
            {
                var menu = new PacmanMenu();
                Hide();
                menu.Show();
            }
            else
            {
                Application.Exit();
            }

        }

        private void Countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cities.Items.Clear();
            this.Cities.Text = "";

            var getCities = this.cities.Where(c => c.Country.Name == this.Countries.Text).Select(c => c.Name).ToArray();
            this.Cities.Items.AddRange(getCities);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Anecdote.Text = DataBridge.GetRandomeAnecdote().AnecdoteNote;
            var anecdoteLetters = this.Anecdote.Text.Length;

            this.AnecdoteTimer.Interval = anecdoteLetters * 60;

        }

        private void Anecdote_MouseHover(object sender, EventArgs e)
        {
            this.AnecdoteTimer.Stop();
        }

        private void Anecdote_MouseLeave(object sender, EventArgs e)
        {
            this.AnecdoteTimer.Start();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            if (this.Password.Text == this.ConfirmPasword.Text)
            {
                var firstName = this.FirstName.Text;
                var lastName = this.LastName.Text;
                var burthDate = this.BurthDate.Value;
                Country country = this.coutries.FirstOrDefault(c => c.Name == this.Countries.Text);
                int? countryId = null;
                if (country != null)
                {
                    countryId = country.Id;
                }
                City city = this.cities.FirstOrDefault(c => c.Name == this.Cities.Text);
                int? cityId = null;
                if (city != null)
                {
                    cityId = city.Id;
                }
                var email = this.Username.Text;
                var password = this.Password.Text;


                if (this.formType==FormEnumerable.Register && DataBridge.CheckIsEmailExist(email))
                {
                    this.Username.BackColor = Color.LightCoral;
                    MessageBox.Show("Has existing User with the entered email");
                }
                else
                {
                    if (this.formType==FormEnumerable.Register)
                    {
                        try
                        {
                            DataBridge.RegisterUser(firstName, lastName, burthDate, countryId, cityId, email, password, false, User.Roles.user);
                            if (DataBridge.UserIsLogin())
                            {
                                PacmanMenu gameMenu = new PacmanMenu();
                                Hide();
                                gameMenu.Show();

                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("something wrong...Please try again");
                        }
                    }

                    if (this.formType==FormEnumerable.Update)
                    {
                        try
                        {
                            DataBridge.UpdateUser(firstName, lastName, burthDate, countryId, cityId, email, password, false, User.Roles.user);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("...something wrong...Please try again");
                        }
                    }
                  
                }
            }
            else
            {
                this.Password.BackColor = Color.LightCoral;
                this.ConfirmPasword.BackColor = Color.LightCoral;
                MessageBox.Show("Does not match passwords");
            }

        }

        private void RegButton_Validating()
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

            if (pass.IsValid(this.ConfirmPasword.Text) &&
                this.ConfirmPasword.Text != this.ConfirmPasword.PlaceHolderText)
            {
                this.ConfirmPasword.BackColor = Color.Aquamarine;
            }
            else
            {
                this.ConfirmPasword.BackColor = Color.LightCoral;
            }

            if (email.IsValid(this.Username.Text) &&
                pass.IsValid(this.Password.Text) &&
                pass.IsValid(this.ConfirmPasword.Text) &&
                this.Password.Text != this.Password.PlaceHolderText &&
                this.ConfirmPasword.Text != this.ConfirmPasword.PlaceHolderText)
            {
                this.RegButton.Enabled = true;
            }
            else
            {
                this.RegButton.Enabled = false;
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            RegButton_Validating();
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
            RegButton_Validating();
        }

        private void ConfirmPasword_TextChanged(object sender, EventArgs e)
        {
            if (this.ConfirmPasword.Text == this.ConfirmPasword.PlaceHolderText &&
               this.ConfirmPasword.UseSystemPasswordChar == true)
            {
                this.ConfirmPasword.UseSystemPasswordChar = false;
            }

            if (this.ConfirmPasword.Text != this.ConfirmPasword.PlaceHolderText &&
                this.ConfirmPasword.UseSystemPasswordChar == false &&
                this.ConfirmPasword.Text.Length > 0)
            {
                this.ConfirmPasword.UseSystemPasswordChar = true;
            }
            RegButton_Validating();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.FirstName.Clear();
            this.LastName.Clear();
            this.BurthDate.ResetText();
            this.Countries.ResetText();
            this.Cities.ResetText();
            this.Username.Clear();
            this.Password.Clear();
            this.ConfirmPasword.Clear();
        }

        private void RegisterUpdate_Load(object sender, EventArgs e)
        {
            if (this.formType == FormEnumerable.Register)
            {
                this.RegButton.Text = "Register";
            }

            if (this.formType == FormEnumerable.Update)
            {
                this.RegButton.Text = "Update";
                this.Username.Enabled = false;
                User user = DataBridge.GetUserData();
                this.Countries.Items.AddRange(DataBridge.GetAllCountries().ToArray());
                this.FirstName.Text = user.FirstName;
                this.LastName.Text = user.LastName;
                if (user.BurthDate != null) this.BurthDate.Value = (DateTime)user.BurthDate;
                this.Countries.Text = user.Country.Name;

                this.Cities.Items.AddRange(DataBridge.GetAllCities().Where(c => c.Country.Name == this.Countries.Text).ToArray());
                this.Cities.Text = user.City.Name;
                this.Username.Text = DataBridge.GetUserEmail();
            }
        }
    }
}
