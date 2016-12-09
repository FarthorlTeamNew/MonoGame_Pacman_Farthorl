namespace Pacman.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;

    public class PacmanContext : DbContext
    {
        public PacmanContext()
            : base("name=PacmanContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Anecdote> Anecdotes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<LevelCoordinate> LevelCoordinateses { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}