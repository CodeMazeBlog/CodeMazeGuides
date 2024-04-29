using Microsoft.EntityFrameworkCore;

namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource=Employee.db");
        }
    }
}