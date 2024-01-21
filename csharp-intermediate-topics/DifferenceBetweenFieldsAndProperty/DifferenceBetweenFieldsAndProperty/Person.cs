namespace DifferenceBetweenFieldsAndProperty;

public class Person
{
    public string name = "John Doe";
    public static int age;
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
