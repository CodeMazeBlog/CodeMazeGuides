using System;

class Program
{
    static void Main()
    {
        Action<int, int> addActionDelegate = (a, b) => Console.WriteLine($"\nSum Action Delegate: {a + b}\n");
        Func<int, int, int> addFuncDelegate = (a, b) => a + b;

        addActionDelegate(3, 5);
        int resultFuncDelegate = addFuncDelegate(3, 5);

        Console.WriteLine($"\nSum Func Delegate: {resultFuncDelegate}\n");
    }
}
