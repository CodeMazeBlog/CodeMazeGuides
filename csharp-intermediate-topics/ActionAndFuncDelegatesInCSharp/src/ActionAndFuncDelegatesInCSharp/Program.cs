public class Program
{
    public static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    public static TResult CalculateFunc<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
    {
        return func(arg1, arg2);
    }

    public static void InteractAction(Action<string> action, string message)
    {
        action(message);
    }

    public static void Main(string[] args)
    {
        // Action delegate
        Action<string> helloAction = SayHello;
        Action<string> goodbyeAction = SayGoodbye;
        InteractAction(helloAction, "John");
        InteractAction(goodbyeAction, "John");

        // Func delegate
        Func<int, int, int> addFunc = AddNumbers;
        Func<int, int, int> subtractFunc = SubtractNumbers;
        var addResult = CalculateFunc(addFunc, 7, 5);
        var subtractResult = CalculateFunc(subtractFunc, 7, 5);
        Console.WriteLine($"Add result: {addResult}");
        Console.WriteLine($"Subtract result: {subtractResult}");
    }

    public static void SayGoodbye(string name)
    {
        var message = $"Goodbye {name}";
        Console.WriteLine($"Message: {message}");
    }

    public static void SayHello(string name)
    {
        var message = $"Hello {name}";
        Console.WriteLine($"Message: {message}");
    }

    public static int SubtractNumbers(int a, int b)
    {
        return a - b;
    }
}
