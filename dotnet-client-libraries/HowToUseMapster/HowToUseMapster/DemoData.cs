using HowToUseMapster.Data;

namespace HowToUseMapster
{
    public static class DemoData
    {
        public static Person CreatePerson()
        {
            return new Person()
            {
                Title = "Mr.",
                FirstName = "Peter",
                LastName = "Pan",
                DateOfBirth = new DateTime(2000, 1, 1),
                Address = new Address()
                {
                    Country = "Neverland",
                    PostCode = "123N",
                    Street = "Funny Street 2",
                    City = "Neverwood"
                },
            };
        }

        public static ICollection<Person> CreatePeople()
        {
            return new List<Person>()
            {
                new Person()
                {
                    Title = "Mr.",
                    FirstName = "Peter",
                    LastName = "Pan",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Address = new Address()
                    {
                        Country = "Neverland",
                        PostCode = "123N",
                        Street = "Funny Street 2",
                        City = "Neverwood"
                    },
                },
                new Person()
                {
                    Title = "Mr.",
                    FirstName = "Captain",
                    LastName = "Hook",
                    DateOfBirth = new DateTime(1970, 5, 5),
                    Address = new Address()
                    {
                        Country = "Neverland",
                        PostCode = "U132",
                        Street = "Water Street 22",
                        City = "Watertown"
                    },
                },
                new Person()
                {
                    Title = "Ms.",
                    FirstName = "Tinker",
                    LastName = "Bell",
                    DateOfBirth = new DateTime(2005, 11, 11),
                    Address = new Address()
                    {
                        Country = "Neverland",
                        PostCode = "123N",
                        Street = "Fairy Street 15b",
                        City = "Fairytown"
                    },
                }
            };
        }
    }
}
