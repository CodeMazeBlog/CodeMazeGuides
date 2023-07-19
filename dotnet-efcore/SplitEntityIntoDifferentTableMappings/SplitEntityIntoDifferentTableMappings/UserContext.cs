using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SplitEntityIntoDifferentTableMappings
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> contextOptions)
            : base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                eb =>
                {
                    eb
                    .ToTable("Users")
                    .SplitToTable(
                        "UserSettings",
                        tb =>
                        {
                            tb.Property(user => user.Id).HasColumnName("UserId");
                            tb.Property(user => user.RememberMe);
                            tb.Property(user => user.Theme);
                        });
                });
        }

        public DbSet<User> Users { get; set; }

        /* only for debugging purposes -- start */
        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }
        /* only for debugging purposes -- end */
    }
}
