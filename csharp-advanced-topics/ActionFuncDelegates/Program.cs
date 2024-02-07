
using ActionFuncDelegates;

public static class Program
{
    public static void Main(string[] args)
    {
        ActionDelegate.Run();

        Console.WriteLine("*******************************");

        FuncDelegate.Run();
    }

}