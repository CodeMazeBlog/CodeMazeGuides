namespace RecordsInCSharpExample;

public record Employee(string FirstName, string LastName, string Job) : Person(FirstName, LastName);

