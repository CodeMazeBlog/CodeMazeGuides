using ActionFuncDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        Delegates.CreateDelegates();
        Console.WriteLine("");

        ActionDelegates.CreateActionDelegates();
        Console.WriteLine("");

        FuncDelegates.CreateFuncDelegates();
    }
}