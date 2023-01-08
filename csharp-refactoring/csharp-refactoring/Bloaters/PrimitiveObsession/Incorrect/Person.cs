namespace csharp_refactoring.Bloaters.PrimitiveObsession.Incorrect
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string? StreetName { get; private set; }
        public string? City { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Region { get; private set; }
        public string? Country { get; private set; }

        public void AssignAddress(string streetName, string city, string postalCode, string region, string country)
        {
            this.StreetName = streetName;
            this.City = city;
            this.PostalCode = postalCode;
            this.Region = region;
            this.Country = country;
        }
    }
}
