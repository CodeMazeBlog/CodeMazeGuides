namespace DifferenceBetweenFieldsAndProperty;

public class Person
{
    public static int age;
    public string name = "John Doe";
    public required bool hasSuperPowers;

    public Person()
    {
        Console.WriteLine(name);

        name = "Jane Doe";
    }

    public void UpdateName(string name)
    {
        Console.WriteLine(this.name);

        this.name = name;

        Console.WriteLine(this.name);
    }
}
