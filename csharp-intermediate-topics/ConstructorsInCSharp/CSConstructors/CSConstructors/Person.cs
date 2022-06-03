public class Person
{
    private string name;
    private int age;

    public static int studentCount;

    static Person()
    {
        studentCount = -1;
    }

    public Person()
    {
        this.name = "testName";
        this.age = 25;
        Console.WriteLine("Default Constructor Invoked");
    }

    public Person(string name)
    {
        this.name = name;
    }

    public Person(string name, int age): this(name)
    {
        this.age = age;
        Console.WriteLine("Constructor are chained and Invoked");
    }

    public Person(Person student)
    {
        this.name = student.name;
        this.age = student.age;
        Console.WriteLine("Copy Constructor Invoked");
    }

    public void display()
    {
        Console.WriteLine(name + " " + age);
    }
}