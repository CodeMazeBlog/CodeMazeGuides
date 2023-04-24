using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Entities;

namespace RecordsAsModelClasses.Core.Context;

public class CarDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<VintageCar> VintageCars { get; set; }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "CarsDb");
    }
}