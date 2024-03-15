using Microsoft.EntityFrameworkCore;

namespace UsingMariaDBWithASPNETCoreWebAPI.Models
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "456 Oak St",
                }
            );
        }
    }
}