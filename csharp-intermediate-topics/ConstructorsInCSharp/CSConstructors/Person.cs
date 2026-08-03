public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    private static int studentCount;

    static Person()
    {
        studentCount = -1;
    }

    public Person()
    {
        Name = "testName";
        Age = 25;
    }

    public Person(string name)
    {
        Name = name;
    }

    public Person(string name, int age)
        : this(name)
    {
        Age = age;
    }

    public Person(Person student)
    {
        Name = student.Name;
        Age = student.Age;
    }

    public void Display()
    {
        Console.WriteLine(Name + " " + Age);
    }
}