using BogusNugetPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace BogusNugetPackage.Database;
public sealed class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=EmployeeDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True")
            .UseSeeding((context, _) =>
            {
                if (context.Set<Employee>().Any())
                {
                    return;
                }

                context.Set<Employee>().AddRange(DataGenerator.Employees);
                context.SaveChanges();
            });
        options.EnableSensitiveDataLogging();
    }
}
