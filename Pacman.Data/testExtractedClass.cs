namespace Pacman.Data
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class testExtractedClass
    {
        public static void LogInUser(string username, string password)
        {

            var firstNameParameter = new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = "", Direction = ParameterDirection.Output };
            var lastNameParameter = new SqlParameter { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = "", Direction = ParameterDirection.Output };
            var burthDateParameter = new SqlParameter { ParameterName = "@burthDate", SqlDbType = SqlDbType.DateTime, Size = 100, Value = DateTime.Now, Direction = ParameterDirection.Output };
            var countryIdParameter = new SqlParameter { ParameterName = "@countryId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };
            var cityIdParameter = new SqlParameter { ParameterName = "@cityId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };
            var usernameParameter = new SqlParameter { ParameterName = "@userName", SqlDbType = SqlDbType.NVarChar, Value = username };
            var passwordParameter = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = DataBridge.Hash(password) };
            var returnSession = new SqlParameter { ParameterName = "@sessionID", SqlDbType = SqlDbType.VarChar, Size = 100, Value = "", Direction = ParameterDirection.Output };
            var userIdParameter = new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };

            try
            {

                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PacmanContext"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("loginUser", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(usernameParameter);
                    sqlCommand.Parameters.Add(passwordParameter);
                    sqlCommand.Parameters.Add(firstNameParameter);
                    sqlCommand.Parameters.Add(lastNameParameter);
                    sqlCommand.Parameters.Add(burthDateParameter);
                    sqlCommand.Parameters.Add(countryIdParameter);
                    sqlCommand.Parameters.Add(cityIdParameter);
                    sqlCommand.Parameters.Add(returnSession);
                    sqlCommand.Parameters.Add(userIdParameter);

                    sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    sqlCommand.ExecuteNonQuery(); // Execute the Query
                    if (!string.IsNullOrEmpty(sqlCommand.Parameters["@sessionId"].Value.ToString()) &&
                        !string.IsNullOrEmpty(sqlCommand.Parameters["@userId"].Value.ToString()))
                    {
                        int userId = (int)sqlCommand.Parameters["@userId"].Value;

                        DataBridge.user = DataBridge.context.Users.FirstOrDefault(u => u.Id == userId);
                        DataBridge.userSessionId = (string)sqlCommand.Parameters["@sessionId"].Value;
                        DataBridge.userEmail= (string)sqlCommand.Parameters["@userName"].Value;
                        DataBridge.userIsLogin = true;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}