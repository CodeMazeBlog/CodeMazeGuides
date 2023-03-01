namespace ActionAndFuncDelegatesInCSharp;

public class HandleFuncDelegate
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static string PrintFuncDelegate()
    {
        Func<int, int, int> AddNumbers = Add;
        var result = AddNumbers(10, 30);

        return $"\nResult = {result}\r\n";
    }
}
