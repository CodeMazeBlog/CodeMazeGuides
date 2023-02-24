namespace ActionAndFuncDelegatesInCSharp;

public class HandleFuncDelegates
{
    
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static void PrintFuncDelegate()
    {
        Func<int, int, int> AddNumbers = Add;
        var result = Add(10, 30);
        Console.WriteLine($"\nResult = {result}");
    }
}
