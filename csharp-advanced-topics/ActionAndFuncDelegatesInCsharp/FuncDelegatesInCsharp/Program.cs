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
        var arg1 = 2;
        var arg2 = 3;
        var result = callback.Invoke(arg1, arg2);
        return result;
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }
}


