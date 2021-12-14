namespace RecordsInCSharpExample;

public abstract record Person(string FirstName, string LastName);
public record Employee(string FirstName, string LastName, string Job) : Person(FirstName, LastName);

public class Program
{
    public static void Main(string[] args)
    {
        var person1 = new Employee("Joe", "Bloggs" , "Firefigher");
        var person2 = new Employee("Joe", "Bloggs", "Teacher");
        var person3 = new Employee("Jane", "Bloggs", "Programmer");
                
        Console.WriteLine($"Person1 == Person2? {person1 == person2}");
        Console.WriteLine($"Person1 == Person3? {person1 == person3}");

        var person4 = person3 with { LastName = "Doe" };
        Console.WriteLine(person4);

        Console.ReadKey();
    }
}

