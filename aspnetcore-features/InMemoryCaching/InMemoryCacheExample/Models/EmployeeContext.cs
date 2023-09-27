using Microsoft.EntityFrameworkCore;

namespace InMemoryCacheExample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
                   : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                DateOfBirth = new DateTime(1979, 04, 25),
                PhoneNumber = "999-888-7777"

            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                Email = "jan.kirsten@gmail.com",
                DateOfBirth = new DateTime(1981, 07, 13),
                PhoneNumber = "111-222-3333"
            });
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
