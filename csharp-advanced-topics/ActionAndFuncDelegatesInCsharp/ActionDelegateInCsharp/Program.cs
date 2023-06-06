namespace ActionDelegateInCsharp;

public class Program
{
    public static void Main(string[] args)
    {
        Execute(() => Console.WriteLine("Hello World!"));

        Execute(message => Console.WriteLine(message));

        Execute((greeting, name) => Console.WriteLine($"{greeting} {name}!"));

        Console.Read();
    }

    public static void Execute(Action callback)
    {
        callback.Invoke();
    }

    public static void Execute(Action<string> callback)
    {
        var argument = "Hello World!";
        callback.Invoke(argument);
    }

    public static void Execute(Action<string, string> callback)
    {
        var argument1 = "Hello";
        var argument2 = "World";
        callback.Invoke(argument1, argument2);
    }
}


