using ActionFuncDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        Delegates.CreateDelegates();
        Console.Write(Environment.NewLine);

        ActionDelegates.CreateActionDelegates();
        Console.Write(Environment.NewLine);

        FuncDelegates.CreateFuncDelegates();
    }
}