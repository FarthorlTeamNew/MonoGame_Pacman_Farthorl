using Pacman.Models;

namespace Pacman.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PacmanContext : DbContext
    {
        public PacmanContext()
            : base("name=PacmanContext")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
    }

}