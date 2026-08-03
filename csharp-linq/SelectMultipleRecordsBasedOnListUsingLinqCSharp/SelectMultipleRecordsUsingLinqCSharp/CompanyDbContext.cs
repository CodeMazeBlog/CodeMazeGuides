using Microsoft.EntityFrameworkCore;

namespace SelectMultipleRecordsUsingLinqCSharp;

public class CompanyDbContext() : DbContext()
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"DataSource=Company.db");
    }
}
