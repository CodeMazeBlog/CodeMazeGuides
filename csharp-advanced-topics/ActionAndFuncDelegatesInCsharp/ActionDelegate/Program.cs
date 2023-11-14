namespace ActionDelegate;

public class ActionSample
{
    public static void Hello(string name)
    {
        Console.WriteLine($"Hello, {name}");
    }

    public static void Bonjure(string name)
    {
        Console.WriteLine($"Bonjure, {name}");
    }

    public static void Main()
    {
        Action<string> sayGreetings = Hello;
        sayGreetings("Pedro");

        sayGreetings = Bonjure;
        sayGreetings("Pedro");
    }
}
