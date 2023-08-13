using System;

public class Program
{

    // Example using Func delegate to perform a math operation with a return value
    public static TResult PerformOperationWithResult<T1, T2, TResult>(T1 x, T2 y, Func<T1, T2, TResult> operation)
    {
        Console.Write($"Performing operation: {operation.Method.Name}({x}, {y}) => ");
        return operation(x, y);
    }

    // Sample math operations
    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static float Subtract(float x, float y)
    {
        return x - y;
    }

    public static double  Multiply(double x, double y)
    {
        return x * y;
    }

    public static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public static double NextDouble(double min, double max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return val;
    }

    static void Main()
    {
        int a = 10;
        int b = 5;

        // Using Func delegate to perform addition and get the result
        int result = PerformOperationWithResult(a, b, Add);
        Console.WriteLine("Result: " + result);


        // Using Func delegate to perform subtraction and get the result
        float c = NextFloat(10, 100);
        float d = NextFloat(100, 200);
        float result_float = PerformOperationWithResult(c, d, Subtract);
        Console.WriteLine("Result: " + result_float);

        double e = NextDouble(10, 100);
        double f = NextDouble(100, 200);


        double result_double = PerformOperationWithResult(e, f, Multiply);
        Console.WriteLine("Result: " + result_double);

    }
}
