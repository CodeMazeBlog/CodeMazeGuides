using Bogus;
using Microsoft.EntityFrameworkCore;
using Person = EntityFrameworkCoreVsDapper.Models.Person;

namespace EntityFrameworkCoreVsDapper.EFCore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var id = 1;
            var fakePersons = new Faker<Person>().StrictMode(true)
                .RuleFor(o => o.Id, f => id++)
                .RuleFor(u => u.Name, (f, u) => f.Name.FullName());

            var persons = fakePersons.Generate(100000);

            modelBuilder.Entity<Person>().HasData(persons);
        }
    }
}
