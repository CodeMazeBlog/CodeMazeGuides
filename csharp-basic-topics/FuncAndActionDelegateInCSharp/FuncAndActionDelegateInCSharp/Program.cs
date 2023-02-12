using FuncAndActionDelegateInCSharp.StaticClasses;

internal class Program
{
    private static void Main(string[] args)
    {
        FuncDelegateExample.Print(2, 3);
        ActionDelegateExample.Print(4, 2);
        Console.ReadLine();
    }
}