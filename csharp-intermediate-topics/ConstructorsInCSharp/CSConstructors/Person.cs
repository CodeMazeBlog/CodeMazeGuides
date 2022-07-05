public class Person
{
    private string _name;
    private int _age;

    private static int studentCount;

    static Person()
    {
        studentCount = -1;
    }

    public Person()
    {
        _name = "testName";
        _age = 25;
        Console.WriteLine("Default Constructor Invoked");
    }

    public Person(string name)
    {
        _name = name;
    }

    public Person(string name, int age): this(name)
    {
        _age = age;
        Console.WriteLine("Constructor are chained and Invoked");
    }

    public Person(Person student)
    {
        _name = student._name;
        _age = student._age;
        Console.WriteLine("Copy Constructor Invoked");
    }

    public void Display()
    {
        Console.WriteLine(_name + " " + _age);
    }
}