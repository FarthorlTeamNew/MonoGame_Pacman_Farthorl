using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Pacman.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using Pacman.Models;

    public class DataBridge
    {
        private static PacmanContext context = new PacmanContext();
        private static Random random = new Random();
        private static User user = new User();
        private static Statistic statistic = new Statistic();
        private static ICollection<Country> countries;
        private static ICollection<City> cities;
        private static ICollection<Level> levels;
        private static string userEmail;
        private static string userSessionId;
        private static bool userIsLogin = false;

        public static IQueryable<string> AllCountriesName
        {
            get
            {
                if (countries == null)
                {
                    countries = context.Countries.ToList();
                }

                return countries.Select(c => c.Name) as IQueryable<string>;
            }
        }

        public static ICollection<Country> AllCountries => countries ?? (countries = context.Countries.ToList());

        public static ICollection<City> GetAllCities => cities ?? (cities = context.Cities.ToList());

        public static ICollection<City> GetCitiesByCountryName(string countryName)
        {
            using (context)
            {
                return context.Cities.Where(city => city.Country.Name == countryName).ToArray();
            }
        }

        public static Anecdote GetRandomeAnecdote()
        {

            var count = context.Anecdotes.Count();
            var randomIndex = random.Next(1, count);
            Anecdote anecdote = context.Anecdotes.FirstOrDefault(a => a.Id == randomIndex);
            return anecdote;
        }

        public static void LogInUser(string username, string password)
        {

            var firstNameParameter = new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = "", Direction = ParameterDirection.Output };
            var lastNameParameter = new SqlParameter { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = "", Direction = ParameterDirection.Output };
            var burthDateParameter = new SqlParameter { ParameterName = "@burthDate", SqlDbType = SqlDbType.DateTime, Size = 100, Value = DateTime.Now, Direction = ParameterDirection.Output };
            var countryIdParameter = new SqlParameter { ParameterName = "@countryId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };
            var cityIdParameter = new SqlParameter { ParameterName = "@cityId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };
            var usernameParameter = new SqlParameter { ParameterName = "@userName", SqlDbType = SqlDbType.NVarChar, Value = username };
            var passwordParameter = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = Hash(password) };
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
                    try
                    {
                        sqlCommand.ExecuteNonQuery(); // Execute the Query
                    }
                    catch (Exception e)
                    {

                        throw;
                    }

                    if (!string.IsNullOrEmpty(sqlCommand.Parameters["@sessionId"].Value.ToString()) &&
                        !string.IsNullOrEmpty(sqlCommand.Parameters["@userId"].Value.ToString()))
                    {
                        int userId = (int)sqlCommand.Parameters["@userId"].Value;

                        user = context.Users.FirstOrDefault(u => u.Id == userId);
                        userSessionId = (string)sqlCommand.Parameters["@sessionId"].Value;
                        userEmail = (string)sqlCommand.Parameters["@userName"].Value;
                        userIsLogin = true;

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public static void RegisterUser(string firstName, string lastName, DateTime burthDate, int? countryId,
                                        int? cityId, string email, string password, bool isDelete, User.Roles role)
        {

            var firstNameParameter = new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = firstName };
            var lastNameParameter = new SqlParameter { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = lastName };
            var burthDateParameter = new SqlParameter { ParameterName = "@burthDate", SqlDbType = SqlDbType.DateTime, Value = burthDate };
            var countryIdParameter = new SqlParameter { ParameterName = "@countryId", SqlDbType = SqlDbType.Int, Value = countryId };
            var cityIdParameter = new SqlParameter { ParameterName = "@cityId", SqlDbType = SqlDbType.Int, Value = cityId };
            var emailParameter = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = email };
            var passwordParameter = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = Hash(password) };
            var isDeleteParameter = new SqlParameter { ParameterName = "@isDelete", SqlDbType = SqlDbType.Bit, Value = isDelete };
            var roleParameter = new SqlParameter { ParameterName = "@role", SqlDbType = SqlDbType.Int, Value = (int)role };
            var sessionIdParameter = new SqlParameter { ParameterName = "@sessionID", SqlDbType = SqlDbType.VarChar, Size = 100, Value = "", Direction = ParameterDirection.Output };
            var userIdParameter = new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PacmanContext"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("registerUser", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(firstNameParameter);
                sqlCommand.Parameters.Add(lastNameParameter);
                sqlCommand.Parameters.Add(burthDateParameter);
                sqlCommand.Parameters.Add(countryIdParameter);
                sqlCommand.Parameters.Add(cityIdParameter);
                sqlCommand.Parameters.Add(emailParameter);
                sqlCommand.Parameters.Add(passwordParameter);
                sqlCommand.Parameters.Add(isDeleteParameter);
                sqlCommand.Parameters.Add(roleParameter);
                sqlCommand.Parameters.Add(sessionIdParameter);
                sqlCommand.Parameters.Add(userIdParameter);

                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
                try
                {
                    sqlCommand.ExecuteNonQuery(); // Execute the Query
                }
                catch (Exception e)
                {
                    throw;
                }

                if (!string.IsNullOrEmpty(sqlCommand.Parameters["@sessionId"].Value.ToString()) &&
                    !string.IsNullOrEmpty(sqlCommand.Parameters["@userId"].Value.ToString()))
                {
                    LogInUser(email, password);
                }
            }

        }

        public static void UpdateUser(string firstName, string lastName, DateTime burthDate, int? countryId,
                                       int? cityId, string email, string password, bool isDelete, User.Roles role)
        {
            var firstNameParameter = new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = firstName };
            var lastNameParameter = new SqlParameter { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = lastName };
            var burthDateParameter = new SqlParameter { ParameterName = "@burthDate", SqlDbType = SqlDbType.DateTime, Value = burthDate };
            var countryIdParameter = new SqlParameter { ParameterName = "@countryId", SqlDbType = SqlDbType.Int, Value = countryId };
            var cityIdParameter = new SqlParameter { ParameterName = "@cityId", SqlDbType = SqlDbType.Int, Value = cityId };
            var emailParameter = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = email };
            var passwordParameter = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = Hash(password) };
            var isDeleteParameter = new SqlParameter { ParameterName = "@isDelete", SqlDbType = SqlDbType.Bit, Value = isDelete };
            var roleParameter = new SqlParameter { ParameterName = "@role", SqlDbType = SqlDbType.Int, Value = (int)role };
            var inputSessionIdParameter = new SqlParameter { ParameterName = "@inputSessionId", SqlDbType = SqlDbType.VarChar, Size = 100, Value = userSessionId };
            var sessionIdParameter = new SqlParameter { ParameterName = "@sessionID", SqlDbType = SqlDbType.VarChar, Size = 100, Value = "", Direction = ParameterDirection.Output };
            var userIdParameter = new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.Int, Size = 100, Value = 0, Direction = ParameterDirection.Output };

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PacmanContext"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("updateUser", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(firstNameParameter);
                sqlCommand.Parameters.Add(lastNameParameter);
                sqlCommand.Parameters.Add(burthDateParameter);
                sqlCommand.Parameters.Add(countryIdParameter);
                sqlCommand.Parameters.Add(cityIdParameter);
                sqlCommand.Parameters.Add(emailParameter);
                sqlCommand.Parameters.Add(passwordParameter);
                sqlCommand.Parameters.Add(isDeleteParameter);
                sqlCommand.Parameters.Add(roleParameter);
                sqlCommand.Parameters.Add(inputSessionIdParameter);
                sqlCommand.Parameters.Add(sessionIdParameter);
                sqlCommand.Parameters.Add(userIdParameter);

                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
                sqlCommand.ExecuteNonQuery(); // Execute the Query
                if (!string.IsNullOrEmpty(sqlCommand.Parameters["@sessionId"].Value.ToString()) &&
                    !string.IsNullOrEmpty(sqlCommand.Parameters["@userId"].Value.ToString()))
                {
                    int userId = (int)sqlCommand.Parameters["@userId"].Value;

                    user = context.Users.FirstOrDefault(u => u.Id == userId);
                    userSessionId = (string)sqlCommand.Parameters["@sessionId"].Value;
                    userEmail = email;
                    userIsLogin = true;

                }
            }
        }
        public static bool CheckIsEmailExist(string email)
        {
            bool result = false;

            var checkEmail = new SqlParameter { ParameterName = "@checkEmail", SqlDbType = SqlDbType.VarChar, Value = email };
            var resultParameter = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.VarChar, Value = "", Direction = ParameterDirection.Output };
            var results = context.Database.SqlQuery<int>("exec @result= checkEmail @checkEmail", resultParameter, checkEmail);
            try
            {
                var isExist = results.FirstOrDefault();
                if (isExist == 1)
                {
                    result = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static bool UserIsLogin()
        {
            return userIsLogin;
        }

        public static User GetUserData()
        {
            return user;
        }

        public static string GetUserEmail()
        {
            return userEmail;
        }

        public static ICollection<Level> GetAllLevels()
        {
            return levels ?? (levels = context.Levels.ToList());
        }

        public static Level GetLevelByName(string levelName)
        {
            var levels = GetAllLevels();

            return levels.FirstOrDefault(level => level.Name == levelName);
        }

        public static string AddRemoveFriend(object id)
        {
            int result = 0;
            bool isNumber = int.TryParse(id.ToString(), out result);
            if (!isNumber)
            {
                return "Please write a valid integer number!";
            }
            try
            {
                int friendId = int.Parse(id.ToString());
                User userToAddOrRemove = context.Users.FirstOrDefault(us => us.Id == friendId);

                if (GetUserData().Friends.Any(us => us.Id == userToAddOrRemove.Id))
                {
                    GetUserData().Friends.Remove(userToAddOrRemove);
                    //context.SaveChanges();
                    UpdateDatabaseStats();
                    return
                        $"You have removed {userToAddOrRemove.FirstName} {userToAddOrRemove.LastName} from your friends list!";
                }
                GetUserData().Friends.Add(userToAddOrRemove);
                //context.SaveChanges();
                UpdateDatabaseStats();
                return
                    $"You have added {userToAddOrRemove.FirstName} {userToAddOrRemove.LastName} to your friends list!";
            }
            catch (Exception)
            {
                return $"No such user with Id = {id} was found!";
            }


        }

        public static void UpdateDatabaseStats()
        {
            //context.SaveChanges();
            context.SaveChangesAsync();
        }

        public static void StartNewGame(string levelName)
        {
            statistic.Level = levels.FirstOrDefault(level => level.Name == levelName);
            statistic.UserId = user.Id; //Important Do not change
            statistic.StartGame = DateTime.Now;
            context.Statistics.Add(statistic);
            //context.SaveChanges();
            UpdateDatabaseStats();
        }

        public static void EndGame()
        {
            if (statistic != null)
            {
                statistic.EndGame = DateTime.Now;
                statistic.Duration = statistic.EndGame - statistic.StartGame;
                //context.SaveChanges();
                UpdateDatabaseStats();
            }
        }

        public static int GetLevelsCount()
        {
            return levels.Count;
        }

        public static string GetLastPlayedGame()
        {
            var firstOrDefault = context.Statistics
                .FirstOrDefault(s => s.UserId == user.Id);
            if (firstOrDefault != null)
            {
                var result = firstOrDefault
                    .Level
                    .Name;
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }

            return "n/a";
        }

        public static string GetUserTotalPoints()
        {
            var result = context.PlayerStatistics
                .Where(ps => ps.User.Id == user.Id);

            if (result.Any())
            {
                var sumResult = result.Sum(ps => ps.PlayerPointsEaten).ToString();
                if (!string.IsNullOrEmpty(sumResult))
                {
                    return sumResult;
                }
            }

            return "n/a";
        }

        public static string GetUserComplateLevels()
        {
            var statisticData = context.PlayerStatistics
                .Where(ps => ps.User.Id == user.Id);

            if (statisticData != null)
            {
                var resultStatisticData = statisticData.Select(ps => new { ps.EasyLevelsCompleted, ps.HardLevelsCompleted });
                if (resultStatisticData.Any())
                {
                    return "Easy:" +
                       resultStatisticData.First().EasyLevelsCompleted +
                       " / Hard:" +
                       resultStatisticData.First().HardLevelsCompleted;
                }
            }

            return "n/a";

        }

        public static string UserNonCompleateLevels()
        {
            var result = context.PlayerStatistics
                                .Where(ps => ps.User.Id == user.Id);

            if (result != null)
            {
                var returnResult = result.Select(ps => ps.PlayerTimesDied);
                if (returnResult.Any())
                {
                    return result.First().ToString();
                }
            }

            return "n/a";
        }

        public static string UserTotalDuration()
        {
            var result = context.Statistics.Where(s => s.UserId == user.Id).Select(s => s.Duration).ToList();


            if (result != null)
            {
                var sumResult = (from r in result let timeSpan = r where timeSpan != null select timeSpan.Value.TotalHours).Sum();
                return sumResult.ToString("0.###") + " hours";
            }

            return "n/a";

        }

        public static string GetTotalPlayers()
        {
            var result = context.Users.Count();
            return result.ToString();
        }

        public static string GetTotalPoints()
        {
            var result = context.PlayerStatistics;

            if (result != null)
            {
                var sumPoints = result.Sum(ps => ps.PlayerPointsEaten).ToString();
                if (!string.IsNullOrEmpty(sumPoints))
                {
                    return sumPoints;

                }
            }

            return "n/a";
        }

        public static string GetComplateLevels()
        {
            var statisticData = context.PlayerStatistics;

            if (statisticData != null)
            {
                var resultData = statisticData.GroupBy(ps => 1)
                .Select(ps => new
                {
                    easyCount = ps.Sum(el => el.EasyLevelsCompleted),
                    hardCount = ps.Sum(hc => hc.HardLevelsCompleted)
                });
                if (resultData.Any())
                {
                    return "Easy:" +
                       resultData.First().easyCount +
                       " / Hard:" +
                       resultData.First().hardCount;
                }
            }


            return "n/a";

        }

        public static string NonCompleateLevels()
        {
            var result = context.PlayerStatistics;
            if (result != null)
            {
                var returnResult = result.Sum(ps => ps.PlayerTimesDied);
                if (!string.IsNullOrEmpty(returnResult.ToString()))
                {
                    return returnResult.ToString();
                }
            }




            return "n/a";
        }
        public static string TotalDuration()
        {
            var result = context.Statistics;
            if (result != null)
            {
                var returnResult = result.Select(s => s.Duration).ToList();
                if (returnResult != null)
                {
                    var sumResult = (from r in returnResult let timeSpan = r where timeSpan != null select timeSpan.Value.TotalHours).Sum();
                    return sumResult.ToString("0.###") + " hours";
                }
            }

            return "n/a";

        }

        public static Level GerRandomLevel(string exlusionByName)
        {
            var myLevels = GetAllLevels().Where(l => l.Name != exlusionByName);
            var count = myLevels.Count();
            var randomIndex = random.Next(1, count);
            return myLevels.ToList()[randomIndex];
        }

        //Hash the password with SHA256 algoritm, before save into the User object
        private static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
