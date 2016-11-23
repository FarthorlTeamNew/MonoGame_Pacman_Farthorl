using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Models;

namespace Pacman.Data
{
    public class DataBridge
    {
        private static PacmanContext context = new PacmanContext();
        private static Random random = new Random();

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
    }
}
