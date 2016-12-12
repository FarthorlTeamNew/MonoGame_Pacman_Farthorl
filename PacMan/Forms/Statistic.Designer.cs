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
            this.buttonUsers.Location = new System.Drawing.Point(12, 12);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(43, 37);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonAnecdotes
            // 
            this.buttonAnecdotes.Location = new System.Drawing.Point(61, 12);
            this.buttonAnecdotes.Name = "buttonAnecdotes";
            this.buttonAnecdotes.Size = new System.Drawing.Size(67, 37);
            this.buttonAnecdotes.TabIndex = 5;
            this.buttonAnecdotes.Text = "Anecdotes";
            this.buttonAnecdotes.UseVisualStyleBackColor = true;
            this.buttonAnecdotes.Click += new System.EventHandler(this.buttonAnecdotes_Click);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 375);
            this.Controls.Add(this.buttonAnecdotes);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Statistic";
            this.Text = "Statistic";
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

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
    }
}