namespace JsonSerializeToDictionaryDataModel;

public sealed record Person(string FirstName, string LastName)
{
    public override string ToString() => (FirstName + " " + LastName).Trim();
}