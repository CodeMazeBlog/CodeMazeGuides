using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

public class CompaniesContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;

    public CompaniesContext()
    {
    }

    public CompaniesContext(DbContextOptions<CompaniesContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=SingleAndSplitQueriesInEFCore");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var companies = DataGenerator.GenerateCompanies(1000);
        modelBuilder.Entity<Company>().HasData(companies);

        var products = DataGenerator.GenerateProducts(companies);
        modelBuilder.Entity<Product>().HasData(products);

        var departments = DataGenerator.GenerateDepartments(companies);
        modelBuilder.Entity<Department>().HasData(departments);
    }
}
