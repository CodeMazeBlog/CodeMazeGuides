using App.DomainModels;
using App.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.DataAccess;

public class WebShopDbContext : DbContext
{
    public DbSet<Item> Items => Set<Item>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Your connection string here";
        optionsBuilder.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemConfig());
        modelBuilder.ApplyConfiguration(new ClothingItemConfig());
        modelBuilder.ApplyConfiguration(new ElectronicItemConfig());
    }
}