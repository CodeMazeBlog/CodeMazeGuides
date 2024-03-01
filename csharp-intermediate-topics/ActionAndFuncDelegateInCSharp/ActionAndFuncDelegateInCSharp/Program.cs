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

        // doMathAction now performs multiplication
        doMathAction = (x, y) => Console.WriteLine(x * y);

        doMathAction(2, 3); // 6

        // ********************
        Console.WriteLine("Without Action");

        // Assign the method to a DoMathAction variable
        DoMathAction doMathActionDelegate = (x, y) => Console.WriteLine(x + y);

        // Invoke
        doMathActionDelegate(2, 3); // 5

        // doMathActionDelegate now performs multiplication
        doMathActionDelegate = (x, y) => Console.WriteLine(x * y);

        doMathActionDelegate(2, 3); // 6

        // ===============================================
        Console.WriteLine("With Func");

        // return, parameter1, parameter2
        Func<int, int, int> doMathFunc = (x, y) => x + y;

        Console.WriteLine(doMathFunc(2, 3)); // 5

        // doMathFunc now performs multiplication
        doMathFunc = (x, y) => x * y;

        Console.WriteLine(doMathFunc(2, 3)); // 6

        // ********************
        Console.WriteLine("Without Func");

        // Assign the method to a DoMathFunc variable
        DoMathFunc doMathFuncDelegate = (x, y) => x + y;

        // Invoke
        Console.WriteLine(doMathFuncDelegate(2, 3)); // 5

        // doMathFuncDelegate now performs multiplication
        doMathFuncDelegate = (x, y) => x * y;

        Console.WriteLine(doMathFuncDelegate(2, 3)); // 6
    }
}
