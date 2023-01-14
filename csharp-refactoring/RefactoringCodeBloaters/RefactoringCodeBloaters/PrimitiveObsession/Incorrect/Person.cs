namespace RefactoringCodeBloaters.PrimitiveObsession.Incorrect
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
            StreetName = streetName;
            City = city;
            PostalCode = postalCode;
            Region = region;
            Country = country;
        }
    }
}
