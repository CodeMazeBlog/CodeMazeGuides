namespace EnumMemberAsString;

public class Person(string name, Country country)
{
    public string Name { get; set; } = name;
    public Country Country { get; set; } = country;
}