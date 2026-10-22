using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DateOnlyAndTimeOnlyTypes;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (builder.IsConfigured) 
            return;

        var configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        builder.UseSqlServer(configuration.GetConnectionString("Default"));
    }

    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
