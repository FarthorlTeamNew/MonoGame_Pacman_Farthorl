using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Pacman.Models;

namespace Pacman.Data
{
    public class DataBridge
    {
        private static PacmanContext context = new PacmanContext();
        private static Random random = new Random();
        private static string userSession;
        private static bool userIsLogin = false;

        public static IQueryable<string> GetAllCountriesName()
        {

            return context.Countries.Select(c => c.Name);


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

            var usernameParameter = new SqlParameter
            {
                ParameterName = "@username",
                Value = username
            };
            var passwordParameter = new SqlParameter
            {
                ParameterName = "@password",
                Value = Hash(password)
            };

            var returnSession = new SqlParameter
            {
                ParameterName = "@returnSession",
                SqlDbType = SqlDbType.VarChar,
                Value = "",
                Direction = ParameterDirection.Output
            };
            var results = context.Database.SqlQuery<string>("exec @returnSession= loginUser @username, @password",
                returnSession,
                usernameParameter,
                passwordParameter
                );

            try
            {
                var sessionId = results.FirstOrDefault();
                if (!string.IsNullOrEmpty(sessionId))
                {
                    userIsLogin = true;
                }
                

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool UserIsLogin()
        {
            return userIsLogin;
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
