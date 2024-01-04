namespace ActionAndFuncDelegates;

public static class Program
{
    public static Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");

    public static Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");

    public static Func<int, int, int> multiply = (a, b) => a * b;

    public static Func<string, int> stringLength = (str) => str.Length;

    public static Action<int> processNumber = (number) => Console.WriteLine($"Processing:{number}");

    public static Func<int, int, int> safeDivision = (a, b) => b != 0 ? a / b : 0;

    public static void Main()
    {
        greet("Fred");

        add(2, 9);

        var product = multiply(2, 9);

        Console.WriteLine($"Multiplied Result: {product}");

        var length = stringLength("Love Func!");
        Console.WriteLine($"Length of the string: {length}");

        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        numbers.ForEach(processNumber);

        var divisionResult = safeDivision(20, 5);
        Console.WriteLine($"Safe Division Result: {divisionResult}");

        ExecuteActionCallback(AddAction, 5, 6);

        var result = ExecuteFuncCallback(AddFunc, 5, 6);

        Console.WriteLine($"Result from ExecuteFuncCallback: {result}");
    }

    public static void ExecuteActionCallback(Action<int, int> callback, int a, int b)
    {
        Console.WriteLine("Executing callback...");
        callback(a, b);
    }

    public static int ExecuteFuncCallback(Func<int, int, int> callback, int a, int b)
    {
        Console.WriteLine("Executing callback with result...");

        return callback(a, b);
    }

    public static int AddFunc(int a, int b)
    {
        var result = a + b;
        Console.WriteLine($"Result of operation: {result}");

        return result;
    }

    public static void AddAction(int a, int b)
    {
        var result = a + b;

        Console.WriteLine($"Result of operation: {result}");
    }
}
