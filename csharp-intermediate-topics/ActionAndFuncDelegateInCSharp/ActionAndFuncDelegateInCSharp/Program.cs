// With Action
namespace ActionAndFuncDelegateInCSharp;

public static class Program
{
    delegate void DoMathAction(int x, int y);
    delegate int DoMathFunc(int x, int y);

    public static void Main()
    {
        Console.WriteLine("With Action");

        // void parameter1, parameter2
        Action<int, int> doMathAction = (x, y) => Console.WriteLine(x + y);

        doMathAction(2, 3); // 5

        doMathAction = (x, y) => Console.WriteLine(x * y);

        doMathAction(2, 3); // 6

        // ********************
        Console.WriteLine("Without Action");

        DoMathAction doMathActionDelegate = (x, y) => Console.WriteLine(x + y);

        doMathActionDelegate(2, 3); // 5

        doMathActionDelegate = (x, y) => Console.WriteLine(x * y);

        doMathActionDelegate(2, 3); // 6

        // ===============================================
        Console.WriteLine("With Func");

        // return, parameter1, parameter2
        Func<int, int, int> doMathFunc = (x, y) => x + y;

        Console.WriteLine(doMathFunc(2, 3)); // 5

        doMathFunc = (x, y) => x * y;

        Console.WriteLine(doMathFunc(2, 3)); // 6

        // ********************
        Console.WriteLine("Without Func");

        DoMathFunc doMathFuncDelegate = (x, y) => x + y;

        Console.WriteLine(doMathFuncDelegate(2, 3)); // 5

        doMathFuncDelegate = (x, y) => x * y;

        Console.WriteLine(doMathFuncDelegate(2, 3)); // 6
    }
}
