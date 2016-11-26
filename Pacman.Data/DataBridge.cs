using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        public static ICollection<Country> GetAllCountries()
        {

            return context.Countries.ToList();

        }

        public static ICollection<City> GetAllCities()
        {

            return context.Cities.ToList();

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

        public static void RegisterUser(string firstName,string lastName,DateTime burthDate,int? countryId,
                                        int? cityId,string email,string password,bool isDelete,User.Roles role)
        {
            var firstNameParameter = new SqlParameter{ParameterName = "@firstName",SqlDbType = SqlDbType.NVarChar,Value = firstName};
            var lastNameParameter = new SqlParameter{ParameterName = "@lastName",SqlDbType = SqlDbType.NVarChar,Value = lastName};
            var burthDateParameter = new SqlParameter{ParameterName = "@burthDate",SqlDbType = SqlDbType.DateTime,Value = burthDate};
            var countryIdParameter = new SqlParameter{ParameterName = "@countryId",SqlDbType = SqlDbType.Int,Value = countryId};
            var cityIdParameter = new SqlParameter{ParameterName = "@cityId",SqlDbType = SqlDbType.Int,Value = cityId};
            var emailParameter = new SqlParameter {ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = email };
            var passwordParameter = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = Hash(password) };
            var isDeleteParameter = new SqlParameter { ParameterName = "@isDelete", SqlDbType = SqlDbType.Bit, Value = isDelete };
            var roleParameter = new SqlParameter { ParameterName = "@role", SqlDbType = SqlDbType.Int, Value = (int)role };
            var returnSession = new SqlParameter{ParameterName = "@returnSession",SqlDbType = SqlDbType.VarChar,Value = "",Direction = ParameterDirection.Output};

            var results = context.Database.SqlQuery<string>("exec @returnSession= registerUser " +
                                                            "@firstName, @lastName, @burthDate," +
                                                            "@countryId, @cityId, @email, @password," +
                                                            "@isDelete, @role",
                                                            returnSession,firstNameParameter,lastNameParameter,
                                                            burthDateParameter,countryIdParameter,cityIdParameter,
                                                            emailParameter,passwordParameter,isDeleteParameter,
                                                            roleParameter
                                                            );

            try
            {
                var sessionId = results.FirstOrDefault();
                if (!string.IsNullOrEmpty(sessionId) && sessionId.Length==64)
                {
                    userIsLogin = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckEmail(string email)
        {
            bool result=false;
            
            var checkEmail = new SqlParameter {ParameterName = "@checkEmail", SqlDbType = SqlDbType.VarChar, Value = email};
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

        //Hash the password with SHA256 algoritm, before save into the User object
        private static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
