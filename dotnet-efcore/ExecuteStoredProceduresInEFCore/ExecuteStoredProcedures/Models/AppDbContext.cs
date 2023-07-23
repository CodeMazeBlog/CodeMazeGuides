using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExecuteStoredProceduresInEFCore.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("default"));
        }
    }
}
