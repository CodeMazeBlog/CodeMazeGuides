namespace DifferenceBetweenFieldsAndProperty;

internal class Program
{
    static void Main(string[] args)
    {
        var person = new Person { hasSuperPowers = true };
        person.UpdateName("Sam Doe");
        Person.age = 19;

        Console.Write("Enter the age: ");
        int.TryParse(Console.ReadLine(), out var age);

        var voterObject = new Voter(age);
        Voter.Name = "Kramer";

        Console.WriteLine($"Age entered: {voterObject.Age}");

        Console.WriteLine(voterObject.DisplayIsVoter());
    }
}
