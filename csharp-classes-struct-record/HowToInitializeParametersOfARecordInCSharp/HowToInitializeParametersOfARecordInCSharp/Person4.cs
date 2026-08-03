namespace HowToInitializeParametersOfARecordInCSharp;

public record Person4(string FirstName, string LastName, IEnumerable<string>? Friends = null)
{
    public IEnumerable<string> Friends { get; init; } = Friends ?? new List<string>();
}
