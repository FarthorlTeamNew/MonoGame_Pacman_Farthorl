using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.Data;
using Pacman.Models;
using Pacman.Models.Attributes;

namespace Pacman.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var register = new Register();
            Hide();
            register.Show();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataBridge.LogInUser(this.Username.Text, this.Password.Text);
            if (DataBridge.UserIsLogin())
            {
               var pacmanMenu = new PacmanMenu();
               Hide();
               pacmanMenu.Show();

            }
        }

        private void Username_Validating(object sender, CancelEventArgs e)
        {
            var user = new User()
            {
                FirstName = "validate",
                LastName ="validate",
                Email = this.Username.Text,
                Role = User.Roles.user,
                SessionId = " "
            };

            ValidationContext validationContext = new ValidationContext(user, null, null);
            ICollection<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user,validationContext, errors, true))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                this.Username.Select(0, this.Username.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(this.Username, "Invalide Email address.");
            }
        }

        private void Username_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(this.Username, "");
        }

    }
}
