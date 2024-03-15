namespace DifferenceBetweenFieldsAndProperty;

public class Person
{
    public static int Age;
    private string _name = "John Doe";
    public required bool HasSuperPowers;

    public Person()
    {
        Console.WriteLine(_name);

        _name = "Jane Doe";
    }

    public void UpdateName(string name)
    {
        Console.WriteLine(_name);

        _name = name;

        Console.WriteLine(_name);
    }
}
