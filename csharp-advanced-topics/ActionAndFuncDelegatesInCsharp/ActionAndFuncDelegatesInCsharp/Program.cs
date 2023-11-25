using System;

public class Program
{
    static void Main()
    {
        addActionDelegate(3, 5);

        Console.WriteLine($"\nSum Func Delegate: {addFuncDelegate(3, 5)}\n");
    }

    public static void addActionDelegate(int a, int b)
    {
        Action<int, int> sum = (a, b) => Console.WriteLine($"\nSum Action Delegate: {a + b}\n");
        sum(a, b);
    }

    public static int addFuncDelegate(int a, int b)
    {
        Func<int, int, int> sum = (a, b) => a + b;
        return sum(a, b);
    }
}
