namespace ActionAndFuncDelegatesInCSharp;

public class HandleFuncDelegate
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static void Main(string[] args)
    {
        Func<int, int, int> AddNumbers = Add;
        var result = Add(10, 30);
        Console.WriteLine($"\nResult = {result}");
    }
}
