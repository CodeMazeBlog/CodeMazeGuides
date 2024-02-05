using ActionAndFunc;
using static ActionAndFunc.ActionAndFunction;

class Program
{
    static void Main(string[] args)
    {
        var num1 = 5;
        var num2 = 10;

        var delegates = new ActionAndFunction();
        var results = delegates.RunDelegate(num1, num2);

        Console.WriteLine($"Result of add: {results.AddResult}");
        Console.WriteLine($"Incremented number: {results.IncrementedNumber}");
    }
}
