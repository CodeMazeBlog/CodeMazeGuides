namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    static void Main(string[] args)
    {
        Action<string> printAction = PrintMessage;
        printAction("Hello, code maze, this is an action delegate!");


        Func<int, int> squareFunc = Square;
        var result = squareFunc(7);

        Console.WriteLine($"A square of 7 is {result}");
    }

    public static void PrintMessage(string message) => Console.WriteLine(message);

    public static int Square(int number) => number * number;
}