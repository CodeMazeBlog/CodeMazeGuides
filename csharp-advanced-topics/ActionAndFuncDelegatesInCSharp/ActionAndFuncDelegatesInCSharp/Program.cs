namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------Func Delegates------------------------");
        FuncDelegates.FuncDelegatesUsage();
        Console.WriteLine("-----------------------------Action Delegates-----------------------");
        ActionDelegates.ActionDelegatesUsage();
    }
}