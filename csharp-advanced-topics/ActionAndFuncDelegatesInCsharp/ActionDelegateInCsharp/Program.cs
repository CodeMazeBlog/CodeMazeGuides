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
        var message = "Hello World!";
        callback.Invoke(message);
    }

    public static void Execute(Action<string, string> callback)
    {
        var greeting = "Hello";
        var name = "World";
        callback.Invoke(greeting, name);
    }
}


