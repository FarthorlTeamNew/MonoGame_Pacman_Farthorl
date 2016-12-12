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
            this.RetrieveInput = new System.Windows.Forms.Button();
            this.FriendIdBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.statisticButton.Location = new System.Drawing.Point(419, 84);
            this.statisticButton.Name = "statisticButton";
            this.statisticButton.Size = new System.Drawing.Size(153, 32);
            this.statisticButton.TabIndex = 4;
            this.statisticButton.Text = "Statistic";
            this.statisticButton.UseVisualStyleBackColor = true;
            this.statisticButton.Click += new System.EventHandler(this.statisticButton_Click);
            // 
            // RetrieveInput
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
            // PacmanMenu
            // 
            this.AcceptButton = this.StartEasyGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FriendIdBox);
            this.Controls.Add(this.RetrieveInput);
            this.Controls.Add(this.statisticButton);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartEasyGame;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ComboBox LevelsComboBox;
        private System.Windows.Forms.Button StartHardGame;
        private System.Windows.Forms.Button statisticButton;
        private System.Windows.Forms.Button RetrieveInput;
        private System.Windows.Forms.TextBox FriendIdBox;
        private System.Windows.Forms.Label label1;
    }
}