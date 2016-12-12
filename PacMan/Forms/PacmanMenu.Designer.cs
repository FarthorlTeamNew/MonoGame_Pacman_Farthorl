namespace Pacman.Forms
{
    partial class PacmanMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacmanMenu));
            this.StartEasyGame = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.LevelsComboBox = new System.Windows.Forms.ComboBox();
            this.StartHardGame = new System.Windows.Forms.Button();
            this.statisticButton = new System.Windows.Forms.Button();
<<<<<<< .mine            this.panel1 = new System.Windows.Forms.Panel();
            this.UserTotalDuration = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TotalDuration = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.NonCompleateLevels = new System.Windows.Forms.Label();
            this.ComplateLevels = new System.Windows.Forms.Label();
            this.TotalPoints = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.UserNonCompleateLevels = new System.Windows.Forms.Label();
            this.UserComplateLevels = new System.Windows.Forms.Label();
            this.UserTotalPoints = new System.Windows.Forms.Label();
            this.LastLevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalPlayers = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
=======            this.RetrieveInput = new System.Windows.Forms.Button();
            this.FriendIdBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
>>>>>>> .theirs            this.SuspendLayout();
            // 
            // StartEasyGame
            // 
            this.StartEasyGame.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StartEasyGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartEasyGame.Location = new System.Drawing.Point(12, 40);
            this.StartEasyGame.Name = "StartEasyGame";
            this.StartEasyGame.Size = new System.Drawing.Size(170, 32);
            this.StartEasyGame.TabIndex = 0;
            this.StartEasyGame.Text = "Start Game Normal";
            this.StartEasyGame.UseVisualStyleBackColor = true;
            this.StartEasyGame.Click += new System.EventHandler(this.StartNormalButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButton.Location = new System.Drawing.Point(419, 6);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(153, 32);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "Update profile";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // LevelsComboBox
            // 
            this.LevelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LevelsComboBox.FormattingEnabled = true;
            this.LevelsComboBox.ItemHeight = 20;
            this.LevelsComboBox.Location = new System.Drawing.Point(12, 6);
            this.LevelsComboBox.Name = "LevelsComboBox";
            this.LevelsComboBox.Size = new System.Drawing.Size(340, 28);
            this.LevelsComboBox.TabIndex = 2;
            this.LevelsComboBox.Tag = "Select game level";
            // 
            // StartHardGame
            // 
            this.StartHardGame.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StartHardGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartHardGame.Location = new System.Drawing.Point(182, 40);
            this.StartHardGame.Name = "StartHardGame";
            this.StartHardGame.Size = new System.Drawing.Size(170, 32);
            this.StartHardGame.TabIndex = 3;
            this.StartHardGame.Text = "Start Game Hard";
            this.StartHardGame.UseVisualStyleBackColor = true;
            this.StartHardGame.Click += new System.EventHandler(this.StartHardGame_Click);
            // 
            // statisticButton
            // 
            this.statisticButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statisticButton.Location = new System.Drawing.Point(419, 44);
            this.statisticButton.Name = "statisticButton";
            this.statisticButton.Size = new System.Drawing.Size(153, 32);
            this.statisticButton.TabIndex = 4;
            this.statisticButton.Text = "Statistic";
            this.statisticButton.UseVisualStyleBackColor = true;
            this.statisticButton.Click += new System.EventHandler(this.statisticButton_Click);
            // 
<<<<<<< .mine            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TotalPlayers);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.UserTotalDuration);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.TotalDuration);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.NonCompleateLevels);
            this.panel1.Controls.Add(this.ComplateLevels);
            this.panel1.Controls.Add(this.TotalPoints);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.UserNonCompleateLevels);
            this.panel1.Controls.Add(this.UserComplateLevels);
            this.panel1.Controls.Add(this.UserTotalPoints);
            this.panel1.Controls.Add(this.LastLevel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 167);
            this.panel1.TabIndex = 5;
            // 
            // UserTotalDuration
            // 
            this.UserTotalDuration.AutoSize = true;
            this.UserTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserTotalDuration.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserTotalDuration.Location = new System.Drawing.Point(176, 135);
            this.UserTotalDuration.Name = "UserTotalDuration";
            this.UserTotalDuration.Size = new System.Drawing.Size(31, 20);
            this.UserTotalDuration.TabIndex = 21;
            this.UserTotalDuration.Text = "n/a";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(1, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "Total games durations:";
            // 
            // TotalDuration
            // 
            this.TotalDuration.AutoSize = true;
            this.TotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalDuration.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TotalDuration.Location = new System.Drawing.Point(473, 135);
            this.TotalDuration.Name = "TotalDuration";
            this.TotalDuration.Size = new System.Drawing.Size(31, 20);
            this.TotalDuration.TabIndex = 19;
            this.TotalDuration.Text = "n/a";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(306, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "Total games duration:";
            // 
            // NonCompleateLevels
            // 
            this.NonCompleateLevels.AutoSize = true;
            this.NonCompleateLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NonCompleateLevels.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NonCompleateLevels.Location = new System.Drawing.Point(470, 110);
            this.NonCompleateLevels.Name = "NonCompleateLevels";
            this.NonCompleateLevels.Size = new System.Drawing.Size(31, 20);
            this.NonCompleateLevels.TabIndex = 17;
            this.NonCompleateLevels.Text = "n/a";
            // 
            // ComplateLevels
            // 
            this.ComplateLevels.AutoSize = true;
            this.ComplateLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComplateLevels.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComplateLevels.Location = new System.Drawing.Point(401, 85);
            this.ComplateLevels.Name = "ComplateLevels";
            this.ComplateLevels.Size = new System.Drawing.Size(31, 20);
            this.ComplateLevels.TabIndex = 16;
            this.ComplateLevels.Text = "n/a";
            // 
            // TotalPoints
            // 
            this.TotalPoints.AutoSize = true;
            this.TotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalPoints.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TotalPoints.Location = new System.Drawing.Point(433, 60);
            this.TotalPoints.Name = "TotalPoints";
            this.TotalPoints.Size = new System.Drawing.Size(31, 20);
            this.TotalPoints.TabIndex = 15;
            this.TotalPoints.Text = "n/a";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(306, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Not compleate levels:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(306, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Compleate:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(306, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "Total points eat:";
            // 
            // UserNonCompleateLevels
            // 
            this.UserNonCompleateLevels.AutoSize = true;
            this.UserNonCompleateLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNonCompleateLevels.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserNonCompleateLevels.Location = new System.Drawing.Point(165, 110);
            this.UserNonCompleateLevels.Name = "UserNonCompleateLevels";
            this.UserNonCompleateLevels.Size = new System.Drawing.Size(31, 20);
            this.UserNonCompleateLevels.TabIndex = 9;
            this.UserNonCompleateLevels.Text = "n/a";
            // 
            // UserComplateLevels
            // 
            this.UserComplateLevels.AutoSize = true;
            this.UserComplateLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserComplateLevels.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserComplateLevels.Location = new System.Drawing.Point(96, 85);
            this.UserComplateLevels.Name = "UserComplateLevels";
            this.UserComplateLevels.Size = new System.Drawing.Size(31, 20);
            this.UserComplateLevels.TabIndex = 8;
            this.UserComplateLevels.Text = "n/a";
            // 
            // UserTotalPoints
            // 
            this.UserTotalPoints.AutoSize = true;
            this.UserTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserTotalPoints.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserTotalPoints.Location = new System.Drawing.Point(128, 60);
            this.UserTotalPoints.Name = "UserTotalPoints";
            this.UserTotalPoints.Size = new System.Drawing.Size(31, 20);
            this.UserTotalPoints.TabIndex = 7;
            this.UserTotalPoints.Text = "n/a";
            // 
            // LastLevel
            // 
            this.LastLevel.AutoSize = true;
            this.LastLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastLevel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LastLevel.Location = new System.Drawing.Point(135, 35);
            this.LastLevel.Name = "LastLevel";
            this.LastLevel.Size = new System.Drawing.Size(31, 20);
            this.LastLevel.TabIndex = 6;
            this.LastLevel.Text = "n/a";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(1, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Not compleate levels:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(1, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Compleate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(1, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total points eat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(1, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last played level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(305, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total statistic";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "User statistic";
            // 
            // TotalPlayers
            // 
            this.TotalPlayers.AutoSize = true;
            this.TotalPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalPlayers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TotalPlayers.Location = new System.Drawing.Point(413, 35);
            this.TotalPlayers.Name = "TotalPlayers";
            this.TotalPlayers.Size = new System.Drawing.Size(31, 20);
            this.TotalPlayers.TabIndex = 23;
            this.TotalPlayers.Text = "n/a";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(306, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Total players:";
            // 
=======            // RetrieveInput
            // 
            this.RetrieveInput.Location = new System.Drawing.Point(27, 190);
            this.RetrieveInput.Name = "RetrieveInput";
            this.RetrieveInput.Size = new System.Drawing.Size(155, 23);
            this.RetrieveInput.TabIndex = 5;
            this.RetrieveInput.Text = "Add/Remove Friend";
            this.RetrieveInput.UseVisualStyleBackColor = true;
            this.RetrieveInput.Click += new System.EventHandler(this.RetrieveInput_Click);
            this.RetrieveInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RetrieveInput_MouseClick);
            // 
            // FriendIdBox
            // 
            this.FriendIdBox.Location = new System.Drawing.Point(224, 193);
            this.FriendIdBox.Name = "FriendIdBox";
            this.FriendIdBox.Size = new System.Drawing.Size(33, 20);
            this.FriendIdBox.TabIndex = 6;
            this.FriendIdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Friend Id";
            // 
>>>>>>> .theirs            // PacmanMenu
            // 
            this.AcceptButton = this.StartEasyGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 261);
<<<<<<< .mine            this.Controls.Add(this.panel1);
=======            this.Controls.Add(this.label1);
            this.Controls.Add(this.FriendIdBox);
            this.Controls.Add(this.RetrieveInput);
>>>>>>> .theirs            this.Controls.Add(this.statisticButton);
            this.Controls.Add(this.StartHardGame);
            this.Controls.Add(this.LevelsComboBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.StartEasyGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "PacmanMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farthorl Pacman Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PacmanMenu_FormClosed);
            this.Load += new System.EventHandler(this.PacmanMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartEasyGame;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ComboBox LevelsComboBox;
        private System.Windows.Forms.Button StartHardGame;
        private System.Windows.Forms.Button statisticButton;
<<<<<<< .mine        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label UserNonCompleateLevels;
        private System.Windows.Forms.Label UserComplateLevels;
        private System.Windows.Forms.Label UserTotalPoints;
        private System.Windows.Forms.Label LastLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserTotalDuration;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label TotalDuration;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label NonCompleateLevels;
        private System.Windows.Forms.Label ComplateLevels;
        private System.Windows.Forms.Label TotalPoints;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TotalPlayers;
        private System.Windows.Forms.Label label8;
=======        private System.Windows.Forms.Button RetrieveInput;
        private System.Windows.Forms.TextBox FriendIdBox;
        private System.Windows.Forms.Label label1;
>>>>>>> .theirs    }
}