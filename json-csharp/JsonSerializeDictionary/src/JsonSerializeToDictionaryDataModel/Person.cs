namespace JsonSerializeToDictionaryDataModel;

public sealed record class Person(string FirstName, string LastName)
{
    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(LastName)) return FirstName;
        if (string.IsNullOrWhiteSpace(FirstName)) return LastName;
        return FirstName + " " + LastName;
    }
}