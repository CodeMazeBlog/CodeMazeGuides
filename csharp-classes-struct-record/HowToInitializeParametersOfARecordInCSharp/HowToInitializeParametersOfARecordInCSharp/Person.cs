namespace HowToInitializeParametersOfARecordInCSharp
{
    public record Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public record Person2(string FirstName, string LastName);

    public record Person3
    {
        public Person3(string firstName, string lastName, IEnumerable<string>? friends = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Friends = friends ?? new List<string>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Friends { get; set; }
    }

    public record Person4(string FirstName, string LastName, IEnumerable<string>? Friends = null)
    {
        public IEnumerable<string> Friends { get; init; } = Friends ?? new List<string>();
    }
}
