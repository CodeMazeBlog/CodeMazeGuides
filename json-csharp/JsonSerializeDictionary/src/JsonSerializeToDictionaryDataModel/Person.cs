namespace JsonSerializeToDictionaryDataModel;

public sealed record class Person(string FirstName, string LastName)
{
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}