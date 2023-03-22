namespace ActionAndFuncInCSharp;

public static class MethodsDefinitions
{
    public static void Greeting(string firstName, string surName)
    {
        Console.WriteLine($"Hello from {firstName} {surName}!");
    }

    public static void ExtendGreeting(string firstName, string surName, Action<string, string> action)
    {
        action(firstName, surName);
        Console.WriteLine("Everything good?");
    }

    public static long Area(int width, int height) => width * height;

    public static string GetAreaAndRecord(int width, int height, Func<int, int, long> function)
    {
        return $"area for a rectangle with width {width} and height {height} is {function(width, height)}";
    }

    public static string GetFullName(string firstName, string lastName) => $"{firstName} {lastName}";

    public static string GreetingsWithDelegate(string firstName, string lastName, AggregateStrings funcDelegate)
    {
        return $"Hello from {funcDelegate(firstName, lastName)}";
    }

    public delegate string AggregateStrings(string first, string second);
}