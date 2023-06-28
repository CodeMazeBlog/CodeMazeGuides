using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreBulkUpdate
{
    public class TeamDBContext : DbContext
    {
        public TeamDBContext(DbContextOptions<TeamDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddDebug();
            });
            optionsBuilder
               .UseLoggerFactory(loggerFactory)
               .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                        .HasOne(p => p.Team)
                        .WithMany(c => c.Players)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().UseTpcMappingStrategy();
            modelBuilder.Entity<Referee>().ToTable("Referees");
            modelBuilder.Entity<Organizer>().ToTable("Organizers");

            modelBuilder.Entity<Game>().UseTptMappingStrategy();
            modelBuilder.Entity<BasketballGame>().ToTable("BasketballGames");
            modelBuilder.Entity<FootballGame>().ToTable("FootballGames");
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}