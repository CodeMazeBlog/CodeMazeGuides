using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Entities;

namespace RecordsAsModelClasses.Core.Context;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<VintageCar> VintageCars { get; set; }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "CarsDb");
    }
}
