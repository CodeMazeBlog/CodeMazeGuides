// Program.cs
using System;

public class Program
{
    public static void PrintMessage(string message)
    {
        Console.WriteLine("Message: " + message);
    }

    public static int CalculateSquare(int num)
    {
        return num * num;
    }

    public static void Main()
    {
        Action<string> printMessageDelegate = PrintMessage;
        printMessageDelegate("Hello, delegates!");

        Func<int, int> calculateSquareDelegate = CalculateSquare;
        int num = 5;
        int square = calculateSquareDelegate(num);
        Console.WriteLine($"Square of {num}: {square}");
    }
}

