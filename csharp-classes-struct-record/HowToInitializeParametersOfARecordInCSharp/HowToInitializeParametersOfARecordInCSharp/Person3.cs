namespace HowToInitializeParametersOfARecordInCSharp;

public record Person3
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<string> Friends { get; set; }

    public Person3(string firstName, string lastName, IEnumerable<string>? friends = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Friends = friends ?? new List<string>();
    }
}