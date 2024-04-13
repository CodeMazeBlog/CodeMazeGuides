using Microsoft.EntityFrameworkCore;
using UniqueConstraintsInEFCore.Data.Models;

namespace UniqueConstraintsInEFCore.Data;

public class SolarSystemDbContext(DbContextOptions<SolarSystemDbContext> options)
    : DbContext(options)
{
    public DbSet<Planet> Planets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
