using DynamicQueriesInCSharp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicQueriesInCSharp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new
                {
                    Id = 1,
                    FirstName = "Manoel",
                    LastName = "Nobrega",
                    Age = 18,
                    Gender = "M"
                },
                new
                {
                    Id = 2,
                    FirstName = "Kenneth",
                    LastName = "Geoghegan",
                    Age = 22,
                    Gender = "M"
                },
                new
                {
                    Id = 3,
                    FirstName = "Leo",
                    LastName = "Candelaria",
                    Age = 15,
                    Gender = "M"
                },
                new
                {
                    Id = 4,
                    FirstName = "Benedetta",
                    LastName = "Coppola",
                    Age = 36,
                    Gender = "F"
                },
                new
                {
                    Id = 5,
                    FirstName = "Noemi",
                    LastName = "Costantini",
                    Age = 76,
                    Gender = "F"
                },
                new
                {
                    Id = 6,
                    FirstName = "Raul",
                    LastName = "Prates",
                    Age = 27,
                    Gender = "M"
                }
            );

            modelBuilder.Entity<Person>().OwnsOne(c => c.Address).HasData(
                new
                {
                    PersonId = 1,
                    Country = "USA",
                    State = "Iowa",
                    City = "South Lera",
                    AddressLine = "38678 Gottlieb Squares"
                },
                new
                {
                    PersonId = 2,
                    Country = "USA",
                    State = "Tennessee",
                    City = "Calihaven",
                    AddressLine = "384 Okey Centers"
                },
                new
                {
                    PersonId = 3,
                    Country = "ESP",
                    State = "Valladolid",
                    City = "Las Gimeno",
                    AddressLine = "Travessera Nevárez, 730, 74º B"
                },
                new
                {
                    PersonId = 4,
                    Country = "ITA",
                    State = "Agrigento",
                    City = "Borgo Mariapia",
                    AddressLine = "Incrocio Ferrara 70"
                },
                new
                {
                    PersonId = 5,
                    Country = "ITA",
                    State = "Ragusa",
                    City = "Sesto Teseo",
                    AddressLine = "Via Sue ellen 171 Piano 2"
                }
            );
        }
    }
}
