namespace FuncDelegatesInCsharp;

public class Program
{
    public static void Main(string[] args)
    {
        Execute(() => Add(2, 3));

        Execute((arg1, arg2) => Add(arg1, arg2));

        Console.Read();
    }

    public static int Execute(Func<int> callback)
    {
        var result = callback.Invoke();
        return result;
    }

    public static int Execute(Func<int, int, int> callback)
    {
        var argument1 = 3;
        var argument2 = 2;
        var result = callback.Invoke(argument1, argument2);
        return result;
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}


