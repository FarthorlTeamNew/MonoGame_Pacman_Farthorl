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
        private static ICollection<Country> countries;
        private static ICollection<City> cities;
        private static string userSession;
        private static bool userIsLogin = false;

        public static IQueryable<string> GetAllCountriesName()
        {

            return context.Countries.Select(c => c.Name);


        }

        public static ICollection<Country> GetAllCountries()
        {
            if (countries == null)
            {
                countries = context.Countries.ToList();
            }
            return countries;

        }

        public static ICollection<City> GetAllCities()
        {
            if (cities == null)
            {
                cities = context.Cities.ToList();
            }
            return cities;

        }

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
                    sqlCommand.ExecuteNonQuery();
                    if (!string.IsNullOrEmpty(sqlCommand.Parameters["@sessionId"].Value.ToString()))
                    {
                        user.FirstName = (string)sqlCommand.Parameters["@firstName"].Value;
                        user.LastName = (string)sqlCommand.Parameters["@lastName"].Value;
                        DateTime datetime = new DateTime();
                        if (DateTime.TryParse(sqlCommand.Parameters["@burthDate"].Value.ToString(), out datetime))
                        {
                            user.BurthDate = datetime;
                        }
                        else
                        {
                            user.BurthDate = null;
                        }
                        user.Country = GetAllCountries().FirstOrDefault(c => c.Id == (int)sqlCommand.Parameters["@countryId"].Value);
                        user.City = GetAllCities().FirstOrDefault(c => c.Id == (int)sqlCommand.Parameters["@cityId"].Value);
                        user.Email = username;
                        user.SessionId = (string)sqlCommand.Parameters["@sessionId"].Value;
                        user.Id = (int)sqlCommand.Parameters["@userId"].Value;
                        userIsLogin = true;

                    }
                }
            }
            catch (Exception)
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
            var returnSession = new SqlParameter { ParameterName = "@returnSession", SqlDbType = SqlDbType.VarChar, Value = "", Direction = ParameterDirection.Output };

            var results = context.Database.SqlQuery<string>("exec @returnSession= registerUser " +
                                                            "@firstName, @lastName, @burthDate," +
                                                            "@countryId, @cityId, @email, @password," +
                                                            "@isDelete, @role",
                                                            returnSession, firstNameParameter, lastNameParameter,
                                                            burthDateParameter, countryIdParameter, cityIdParameter,
                                                            emailParameter, passwordParameter, isDeleteParameter,
                                                            roleParameter
                                                            );

            try
            {
                var sessionId = results.FirstOrDefault();
                if (!string.IsNullOrEmpty(sessionId) && sessionId.Length == 64)
                {
                    var countries = GetAllCountries();
                    var cities = GetAllCities();
                    userIsLogin = true;
                    user.SessionId = sessionId;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.BurthDate = burthDate;
                    user.Email = email;
                    user.Country = countries.FirstOrDefault(c => c.Id == countryId);
                    user.City = cities.FirstOrDefault(c => c.Id == cityId);
                }


            }
            catch (Exception)
            {
                throw;
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
            var sessionIdParameter = new SqlParameter { ParameterName = "@sessionId", SqlDbType = SqlDbType.VarChar, Value = user.SessionId };
            var returnSession = new SqlParameter { ParameterName = "@returnSession", SqlDbType = SqlDbType.VarChar, Value = "", Direction = ParameterDirection.Output };

            var results = context.Database.SqlQuery<string>("exec @returnSession= updateUser " +
                                                            "@firstName, @lastName, @burthDate," +
                                                            "@countryId, @cityId, @email, @password," +
                                                            "@isDelete, @role, @sessionId",
                                                            returnSession, firstNameParameter, lastNameParameter,
                                                            burthDateParameter, countryIdParameter, cityIdParameter,
                                                            emailParameter, passwordParameter, isDeleteParameter,
                                                            roleParameter, sessionIdParameter
                                                            );

            try
            {
                var sessionId = results.FirstOrDefault();
                if (!string.IsNullOrEmpty(sessionId) && sessionId.Length == 64)
                {
                    var countries = GetAllCountries();
                    var cities = GetAllCities();
                    userIsLogin = true;
                    user.SessionId = sessionId;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.BurthDate = burthDate;
                    user.Email = email;
                    user.Country = countries.FirstOrDefault(c => c.Id == countryId);
                    user.City = cities.FirstOrDefault(c => c.Id == cityId);
                }

            }
            catch (Exception e)
            {
                throw;
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

        //Hash the password with SHA256 algoritm, before save into the User object
        private static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
