using DtoVsPoco.Domain;

namespace DtoVsPoco.DataStore
{
    public static class FakeDataStore
    {
        public static ICollection<Person> GetPersonDomainObjects()
        {
            return new List<Person>
            {
                new Person(1)
                {
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Address = "DC Street 22",
                    JobTitle = "Batman",
                    DateOfBirth = new DateTime(1972, 7, 8)
                },
                new Person(2)
                {
                    FirstName = "Tony",
                    LastName = "Stark",
                    Address = "Marvel Street 9",
                    JobTitle = "Iron-Man",
                    DateOfBirth = new DateTime(1968, 5, 5)
                },
                new Person(3)
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Address = "Marvel Street 87",
                    JobTitle = "Spider-Man",
                    DateOfBirth = new DateTime(1992, 2, 4)
                },
            };
        }
    }
}
