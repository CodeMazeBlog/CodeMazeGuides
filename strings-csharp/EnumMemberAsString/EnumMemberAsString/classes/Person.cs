namespace EnumMemberAsString;

public class Person
{
    public string Name { get; set; }
    public Country Country { get; set; }

    public Person(string name, Country country)
    {
        Name = name;
        Country = country;
    }
}