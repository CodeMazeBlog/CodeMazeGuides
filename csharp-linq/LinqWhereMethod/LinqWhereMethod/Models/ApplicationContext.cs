using Microsoft.EntityFrameworkCore;

namespace LinqWhereMethod.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext() {}

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "PeopleDatabase");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>().HasData(
            new Pet
            {
                Id = 1,
                Breed = "Australian Shepherd",
                Name = "Naïa",
                PersonId = 4
            },
            new Pet
            {
                Id = 2,
                Breed = "Jack Russel",
                Name = "Tiboo",
                PersonId = 4
            },
            new Pet
            {
                Id = 3,
                Breed = "French Bulldog",
                Name = "Lucky",
                PersonId = 2
            }
        );

        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                Street = "20 rue Victor Hugo",
                City = "LYON",
                ZipCode = "69001",
                PersonId = 1
            }
            , new Address
            {
                Id = 2,
                Street = "43 allée Serpentine",
                City = "MARSEILLE",
                ZipCode = "13014",
                PersonId = 2
            },
            new Address
            {
                Id = 3,
                Street = "5 rue de la Cristallerie",
                City = "NANCY",
                ZipCode = "54010",
                PersonId = 3
            },
            new Address
            {
                Id = 4,
                Street = "128 avenue des Champs Elysées",
                City = "PARIS",
                ZipCode = "75008",
                PersonId = 4
            }
        );

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Address)
            .WithOne(a => a.Person)
            .HasForeignKey<Address>(a => a.PersonId);

        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = 1,
                FirstName = "Judith",
                LastName = "PRICE",
                BirthDate = new DateTime(1973, 02, 17)
            },
            new Person
            {
                Id = 2,
                FirstName = "Colleen",
                LastName = "JACKSON",
                BirthDate = new DateTime(1975, 09, 15)
            },
            new Person
            {
                Id = 3,
                FirstName = "Dennis",
                LastName = "LAWRENCE",
                BirthDate = new DateTime(1968, 08, 03)
            },
            new Person
            {
                Id = 4,
                FirstName = "Dan",
                LastName = "RICHARD",
                BirthDate = new DateTime(1974, 07, 02)
            }
        );
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Pet> Pets { get; set; }
}