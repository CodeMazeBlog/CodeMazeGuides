using Microsoft.EntityFrameworkCore;

namespace ProjectConfigurationDemo.Models;

public class ConfigurationDbContext(string? connectionString) : DbContext
{
    private readonly string? _connectionString = connectionString;

    public DbSet<ConfigurationEntity> ConfigurationEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);
}
