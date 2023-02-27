namespace ActionAndFuncDelegatesInCSharp;

public class HandleActionDelegate
{
    public delegate string Print(int result);

    public static string PrintNumber(int a)
    {
        return $"\nResult = {a}\r\n";
    }

    public static string PrintActionDelegate()
    {
        Print print = PrintNumber;
        return print(2);
    }
}
