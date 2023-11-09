namespace RecordsInCSharpExample;

public class Program
{
    public static void Main(string[] args)
    {
        var person1 = new Person("Joe", "Bloggs");
        var person2 = new Person("Joe", "Bloggs");
        var person3 = new Person("Jane", "Bloggs");
        Console.WriteLine($"Person1 == Person2? {person1 == person2}");
        Console.WriteLine($"Person1 == Person3? {person1 == person3}");
        Console.ReadKey();
    }
}

