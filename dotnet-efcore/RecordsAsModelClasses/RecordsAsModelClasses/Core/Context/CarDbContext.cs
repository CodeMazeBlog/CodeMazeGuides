using Microsoft.EntityFrameworkCore;

namespace RecordsAsModelClasses.Core.Context;

public class CarDbContext : DbContext
{
    public DbSet<Entities.Records.Car> RecordCars { get; set; }
    public DbSet<Entities.Classes.Car> ClassCars { get; set; }

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