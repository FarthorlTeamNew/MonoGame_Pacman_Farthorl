namespace Pacman.Forms
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BurthDate = new System.Windows.Forms.DateTimePicker();
            this.Countries = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Cities = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AnecdoteTimer = new System.Windows.Forms.Timer(this.components);
            this.Anecdote = new System.Windows.Forms.RichTextBox();
            this.RegButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConfirmPasword = new Pacman.Menu.PlaceHolderTextBox();
            this.Password = new Pacman.Menu.PlaceHolderTextBox();
            this.Username = new Pacman.Menu.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 12);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(88, 20);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "First name:";
            // 
            // FirstName
            // 
            this.FirstName.AccessibleDescription = "";
            this.FirstName.AccessibleName = "";
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstName.Location = new System.Drawing.Point(149, 9);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(226, 26);
            this.FirstName.TabIndex = 2;
            this.FirstName.Tag = "";
            // 
            // LastName
            // 
            this.LastName.AccessibleDescription = "";
            this.LastName.AccessibleName = "";
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastName.Location = new System.Drawing.Point(149, 41);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(226, 26);
            this.LastName.TabIndex = 4;
            this.LastName.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date of burth:";
            // 
            // BurthDate
            // 
            this.BurthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BurthDate.Location = new System.Drawing.Point(149, 73);
            this.BurthDate.Name = "BurthDate";
            this.BurthDate.Size = new System.Drawing.Size(226, 26);
            this.BurthDate.TabIndex = 7;
            // 
            // Countries
            // 
            this.Countries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Countries.FormattingEnabled = true;
            this.Countries.Location = new System.Drawing.Point(149, 105);
            this.Countries.Name = "Countries";
            this.Countries.Size = new System.Drawing.Size(226, 28);
            this.Countries.TabIndex = 8;
            this.Countries.SelectedIndexChanged += new System.EventHandler(this.Countries_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Country:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "City";
            // 
            // Cities
            // 
            this.Cities.DropDownHeight = 150;
            this.Cities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cities.FormattingEnabled = true;
            this.Cities.IntegralHeight = false;
            this.Cities.Location = new System.Drawing.Point(149, 141);
            this.Cities.Name = "Cities";
            this.Cities.Size = new System.Drawing.Size(226, 28);
            this.Cities.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "E-mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Confirm password:";
            // 
            // AnecdoteTimer
            // 
            this.AnecdoteTimer.Enabled = true;
            this.AnecdoteTimer.Interval = 1;
            this.AnecdoteTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Anecdote
            // 
            this.Anecdote.BackColor = System.Drawing.SystemColors.Control;
            this.Anecdote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Anecdote.Enabled = false;
            this.Anecdote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Anecdote.Location = new System.Drawing.Point(392, 9);
            this.Anecdote.Name = "Anecdote";
            this.Anecdote.Size = new System.Drawing.Size(280, 365);
            this.Anecdote.TabIndex = 19;
            this.Anecdote.Text = "";
            this.Anecdote.MouseLeave += new System.EventHandler(this.Anecdote_MouseLeave);
            this.Anecdote.MouseHover += new System.EventHandler(this.Anecdote_MouseHover);
            // 
            // RegButton
            // 
            this.RegButton.Enabled = false;
            this.RegButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegButton.Location = new System.Drawing.Point(149, 308);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(138, 30);
            this.RegButton.TabIndex = 20;
            this.RegButton.Text = "Register";
            this.RegButton.UseVisualStyleBackColor = true;
            this.RegButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(293, 308);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(82, 30);
            this.ClearButton.TabIndex = 24;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ConfirmPasword
            // 
            this.ConfirmPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.ConfirmPasword.ForeColor = System.Drawing.Color.Gray;
            this.ConfirmPasword.Location = new System.Drawing.Point(149, 276);
            this.ConfirmPasword.Name = "ConfirmPasword";
            this.ConfirmPasword.PlaceHolderText = "Please confirm password";
            this.ConfirmPasword.Size = new System.Drawing.Size(226, 26);
            this.ConfirmPasword.TabIndex = 23;
            this.ConfirmPasword.Text = "Please confirm password";
            this.ConfirmPasword.TextChanged += new System.EventHandler(this.ConfirmPasword_TextChanged);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.Password.ForeColor = System.Drawing.Color.Gray;
            this.Password.Location = new System.Drawing.Point(149, 244);
            this.Password.Name = "Password";
            this.Password.PlaceHolderText = "Please enter password";
            this.Password.Size = new System.Drawing.Size(226, 26);
            this.Password.TabIndex = 22;
            this.Password.Text = "Please enter password";
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.Username.ForeColor = System.Drawing.Color.Gray;
            this.Username.Location = new System.Drawing.Point(149, 212);
            this.Username.Name = "Username";
            this.Username.PlaceHolderText = "Please enter valid E-mail";
            this.Username.Size = new System.Drawing.Size(226, 26);
            this.Username.TabIndex = 21;
            this.Username.Text = "Please enter valid E-mail";
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 386);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ConfirmPasword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.RegButton);
            this.Controls.Add(this.Anecdote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cities);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Countries);
            this.Controls.Add(this.BurthDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.FirstNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 425);
            this.MinimumSize = new System.Drawing.Size(700, 425);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hello New User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker BurthDate;
        private System.Windows.Forms.ComboBox Countries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer AnecdoteTimer;
        private System.Windows.Forms.RichTextBox Anecdote;
        private System.Windows.Forms.Button RegButton;
        private Menu.PlaceHolderTextBox Username;
        private Menu.PlaceHolderTextBox Password;
        private Menu.PlaceHolderTextBox ConfirmPasword;
        private System.Windows.Forms.Button ClearButton;
    }
}