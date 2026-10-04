using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData
                (
                 new Employee
                 {
                     Id = new Guid("07e57250-5443-4bdc-be13-59239ada918e"),
                     Name = "Mark",
                     AccountNumber = "123-3452134543-32",
                     Age = 30
                 },
                 new Employee
                 {
                     Id = new Guid("195430d1-9227-451e-8378-65df427be580"),
                     Name = "Evelin",
                     AccountNumber = "123-9384613085-55",
                     Age = 28
                 }
                );
        }

        public DbSet<Employee>? Employees { get; set; }
    }
}
