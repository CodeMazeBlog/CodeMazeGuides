using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

public class CompaniesContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=SingleAndSplitQueriesInEFCore");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var companies = DataGenerator.GenerateCompanies(100);
        modelBuilder.Entity<Company>().HasData(companies);

        var products = DataGenerator.GenerateProducts(1000, companies);
        modelBuilder.Entity<Product>().HasData(products);

        var departments = DataGenerator.GenerateDepartments(1000, companies);
        modelBuilder.Entity<Department>().HasData(departments);

        var employees = DataGenerator.GenerateEmployees(10000, departments);
        modelBuilder.Entity<Employee>().HasData(employees);
    }
}
