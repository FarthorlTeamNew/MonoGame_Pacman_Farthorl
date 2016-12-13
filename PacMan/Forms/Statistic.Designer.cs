namespace Pacman.Forms
{
    partial class Statistic
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.хммммToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квоЕТToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пешоПомагайToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonAnecdotes = new System.Windows.Forms.Button();
            this.buttonPlayersStatistic = new System.Windows.Forms.Button();
            this.buttonGameStatistic = new System.Windows.Forms.Button();
            this.buttonUsersFriends = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хммммToolStripMenuItem,
            this.квоЕТToolStripMenuItem,
            this.ваToolStripMenuItem,
            this.пешоПомагайToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(158, 92);
            // 
            // хммммToolStripMenuItem
            // 
            this.хммммToolStripMenuItem.Name = "хммммToolStripMenuItem";
            this.хммммToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.хммммToolStripMenuItem.Text = "хмммм";
            // 
            // квоЕТToolStripMenuItem
            // 
            this.квоЕТToolStripMenuItem.Name = "квоЕТToolStripMenuItem";
            this.квоЕТToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.квоЕТToolStripMenuItem.Text = "кво е т";
            // 
            // ваToolStripMenuItem
            // 
            this.ваToolStripMenuItem.Name = "ваToolStripMenuItem";
            this.ваToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ваToolStripMenuItem.Text = "ва";
            // 
            // пешоПомагайToolStripMenuItem
            // 
            this.пешоПомагайToolStripMenuItem.Name = "пешоПомагайToolStripMenuItem";
            this.пешоПомагайToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.пешоПомагайToolStripMenuItem.Text = "Пешо помагай";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(666, 285);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonUsers
            // 
            this.buttonUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUsers.Location = new System.Drawing.Point(12, 12);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(52, 45);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonAnecdotes
            // 
            this.buttonAnecdotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnecdotes.Location = new System.Drawing.Point(331, 12);
            this.buttonAnecdotes.Name = "buttonAnecdotes";
            this.buttonAnecdotes.Size = new System.Drawing.Size(81, 45);
            this.buttonAnecdotes.TabIndex = 5;
            this.buttonAnecdotes.Text = "Anecdotes";
            this.buttonAnecdotes.UseVisualStyleBackColor = true;
            this.buttonAnecdotes.Click += new System.EventHandler(this.buttonAnecdotes_Click);
            // 
            // buttonPlayersStatistic
            // 
            this.buttonPlayersStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlayersStatistic.Location = new System.Drawing.Point(157, 12);
            this.buttonPlayersStatistic.Name = "buttonPlayersStatistic";
            this.buttonPlayersStatistic.Size = new System.Drawing.Size(81, 45);
            this.buttonPlayersStatistic.TabIndex = 6;
            this.buttonPlayersStatistic.Text = "Players Statistic";
            this.buttonPlayersStatistic.UseVisualStyleBackColor = true;
            this.buttonPlayersStatistic.Click += new System.EventHandler(this.buttonPlayersStatistic_Click);
            // 
            // buttonGameStatistic
            // 
            this.buttonGameStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGameStatistic.Location = new System.Drawing.Point(244, 12);
            this.buttonGameStatistic.Name = "buttonGameStatistic";
            this.buttonGameStatistic.Size = new System.Drawing.Size(81, 45);
            this.buttonGameStatistic.TabIndex = 7;
            this.buttonGameStatistic.Text = "Game Statistic";
            this.buttonGameStatistic.UseVisualStyleBackColor = true;
            this.buttonGameStatistic.Click += new System.EventHandler(this.buttonGameStatistic_Click);
            // 
            // buttonUsersFriends
            // 
            this.buttonUsersFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUsersFriends.Location = new System.Drawing.Point(70, 12);
            this.buttonUsersFriends.Name = "buttonUsersFriends";
            this.buttonUsersFriends.Size = new System.Drawing.Size(81, 45);
            this.buttonUsersFriends.TabIndex = 8;
            this.buttonUsersFriends.Text = "Users - Friends";
            this.buttonUsersFriends.UseVisualStyleBackColor = true;
            this.buttonUsersFriends.Click += new System.EventHandler(this.buttonUsersFriends_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(434, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "This is a Game, Not a Newspaper!";
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUsersFriends);
            this.Controls.Add(this.buttonGameStatistic);
            this.Controls.Add(this.buttonPlayersStatistic);
            this.Controls.Add(this.buttonAnecdotes);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Statistic";
            this.Text = "Statistic";
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem хммммToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem квоЕТToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пешоПомагайToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonAnecdotes;
        private System.Windows.Forms.Button buttonPlayersStatistic;
        private System.Windows.Forms.Button buttonGameStatistic;
        private System.Windows.Forms.Button buttonUsersFriends;
        private System.Windows.Forms.Label label1;
    }
}