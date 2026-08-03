namespace RecordsInCSharpExample;

public record Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string LastName { get; set; }
    public string FirstName { get; set; }
}

