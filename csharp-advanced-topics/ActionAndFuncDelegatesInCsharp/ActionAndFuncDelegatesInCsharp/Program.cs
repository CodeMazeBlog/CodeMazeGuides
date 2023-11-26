using System;

public class Program
{
    static void Main()
    {
        AddActionDelegate(3, 5);

        Console.WriteLine($"Sum Func Delegate: {AddFuncDelegate(3, 5)}");
    }

    public static void AddActionDelegate(int a, int b)
    {
        Action<int, int> sum = (a, b) => Console.WriteLine($"Sum Action Delegate: {a + b}");
        sum(a, b);
    }

    public static int AddFuncDelegate(int a, int b)
    {
        Func<int, int, int> sum = (a, b) => a + b;
        return sum(a, b);
    }
}
