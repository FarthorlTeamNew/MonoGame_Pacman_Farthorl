using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Forms
{
    public partial class Statistic : Form
    {
        private SqlConnection connectionDataBase;

        public Statistic()
        {
            InitializeComponent();

            string connectionString = "Server=tcp:farthorl.database.windows.net,1433;Initial Catalog=PacmanDB;Persist Security Info=False;User ID=FarthorlTeam;Password=teamPassword@Azure;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            this.connectionDataBase = new SqlConnection(connectionString);
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Users", connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void buttonAnecdotes_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Anecdotes", connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void ExecuteCommandInDataGrid(SqlCommand command)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable table = new DataTable("MyUsers");
                sda.Fill(table);
                BindingSource bindingSource = new BindingSource();

                bindingSource.DataSource = table;
                this.dataGridView1.DataSource = bindingSource;
                sda.Update(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
