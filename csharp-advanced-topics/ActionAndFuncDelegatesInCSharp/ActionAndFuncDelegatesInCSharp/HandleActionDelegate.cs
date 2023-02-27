namespace ActionAndFuncDelegatesInCSharp;

public class HandleActionDelegate
{
    public delegate void Print(int result);

    public static void PrintNumber(int a)
    {
        Console.WriteLine($"\nResult = {a}");
    }

    public static void PrintActionDelegate()
    {
        Print print = PrintNumber;
        print(2);
    }
}
