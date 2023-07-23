using Microsoft.EntityFrameworkCore;

namespace FilteringResultsInsideInclude.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AppDB;Trusted_Connection=True;");
        }
    }
}
