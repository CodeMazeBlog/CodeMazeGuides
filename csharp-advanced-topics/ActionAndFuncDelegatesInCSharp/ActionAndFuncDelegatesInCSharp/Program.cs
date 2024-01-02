using ActionAndFuncDelegatesInCSharp;
class Program
{
    static void Main(string[] args)
    {
        var actionDelegate = new ActionDelegates();
        actionDelegate.UpdateUIWithMessage("Hello, World!");
        
        int result = FuncDelegates.multiply(5, 4);
        Console.WriteLine($"The result of multiplying 5 and 4 is: {result}");
    }
}

