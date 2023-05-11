using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Entities.Classes;
using RecordsAsModelClasses.Core.Entities.Records;

namespace RecordsAsModelClasses.Core.Context;

public class CarDbContext : DbContext
{
    public DbSet<RecordCar> RecordCars { get; set; }
    public DbSet<ClassCar> ClassCars { get; set; }

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