namespace FuncDelegatesInCsharp;

public class Program
{
    static void Main(string[] args)
    {
        // Func delegate with lambda expression
        Func<int, int, int> add = (a, b) => a + b;

        // Invoke the delegate
        int result = add(2, 3); // result = 5

        //=== Passing Methods as arguments ===//

        // Pass a lambda expression to PrintSum
        PrintSum((_, _) => Add(2, 3));

        // Pass a lambda expression that calls Add to PrintSum
        PrintSum((a, b) => Add(a, b));

        // Pass the Add method to PrintSum
        PrintSum(2, 3, Add);

        Console.Read();
    }

    // Print the return value of a func delegate
    public static void PrintSum(Func<int, int, int> add)
    {
        Console.WriteLine(add(2, 3));
    }

    // Print the return value of a func delegate with two ints
    public static void PrintSum(int x, int y, Func<int, int, int> add)
    {
        Console.WriteLine(add(x, y));
    }

    // Return the sum of two ints
    public static int Add(int a, int b)
    {
        return a + b;
    }
}


