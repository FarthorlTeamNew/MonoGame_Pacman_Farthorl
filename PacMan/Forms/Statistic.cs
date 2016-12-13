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
            string sql = "SELECT u.Id, FirstName, LastName, BurthDate, DATEDIFF(year, [BurthDate], GETDATE()) as Age, c.Name as Country, ci.Name as City " +
                                "FROM Users u " +
                                "join Countries c " +
                                "on u.CountryId = c.Id " +
                                "join Cities ci " +
                                "on u.CityId = ci.Id";
            SqlCommand command = new SqlCommand(sql, connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void buttonAnecdotes_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Anecdotes", connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void buttonPlayersStatistic_Click(object sender, EventArgs e)
        {
            string sql = "SELECT (u.FirstName + ' ' + u.LastName) as UserName, PlayerPointsEaten, PlayerFruitEatenCount, PlayerGhostsEatenCount, PlayerGhostkillersEaten, HardLevelsCompleted, EasyLevelsCompleted, PlayerTimesDied " +
                                 "FROM PlayerStatistics ps " +
                                 "join Users u " +
                                 "on ps.UserId = u.Id " +
                                 "order by PlayerPointsEaten desc ";
            SqlCommand command = new SqlCommand(sql, connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void buttonGameStatistic_Click(object sender, EventArgs e)
        {
            string sql = "SELECT s.Id ,(u.FirstName + ' ' + u.LastName) as UserName ,l.Name ,StartGame ,EndGame ,Duration " +
                     "FROM [Statistics] s " +
                     "join Users u " +
                     "on s.UserId = u.Id " +
                     "join Levels l " +
                     "on s.LevelId = l.Id " +
                     "order by s.StartGame desc ";
            SqlCommand command = new SqlCommand(sql, connectionDataBase);

            ExecuteCommandInDataGrid(command);
        }

        private void buttonUsersFriends_Click(object sender, EventArgs e)
        {
            string sql = "SELECT (u.FirstName + ' ' + u.LastName) as UserName, (f.FirstName + ' ' + f.LastName) as FriendName " +
                             "FROM [dbo].[UsersFriends] uf " +
                             "join Users u " +
                             "on u.Id = uf.UserId " +
                             "join Users f " +
                             "on f.Id = uf.FriendId " +
                             "order by uf.userId ";
            SqlCommand command = new SqlCommand(sql, connectionDataBase);

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
