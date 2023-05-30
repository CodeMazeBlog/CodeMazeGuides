namespace ActionDelegateInCsharp;

public class Program
{
    static void Main(string[] args)
    {
        // Define an action that prints Hello World!
        Action greet = () => Console.WriteLine("Hello World!");

        // Invoke the action
        greet(); // prints: Hello World!
        greet.Invoke(); // prints: Hello World!

        // Define an action that takes a string and prints it
        Action<string> greetMessage = message => Console.WriteLine(message);

        // Invoke the action with a message
        greetMessage("Hello, world!"); // prints: Hello, world!
        greetMessage.Invoke("Hello, world!"); // prints: Hello, world!

        //=== Passing Methods as arguments ===//

        // Pass a lambda expression as an argument to Execute method
        Execute(() => Console.WriteLine("Hello World!")); // prints: Hello World!

        // Pass a lambda expression with a parameter as an argument to Execute method
        Execute(message => Console.WriteLine(message)); // prints: Hello World!

        // Pass a string and a lambda expression as arguments to Execute method
        Execute("John", message => Console.WriteLine(message)); // prints: Hello John!

        Console.Read();
    }

    // Execute a given action
    public static void Execute(Action callback)
    {
        callback();
    }

    // Execute a given action with a name
    public static void Execute(Action<string> callback)
    {
        var name = "World";
        callback(name + "!");
    }

    // Execute a given action with a name
    public static void Execute(string name, Action<string> greet)
    {
        greet("Hello " + name + "!");
    }
}


