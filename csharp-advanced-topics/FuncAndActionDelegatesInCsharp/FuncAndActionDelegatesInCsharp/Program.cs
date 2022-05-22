using FuncAndActionDelegatesInCsharp.Action;
using FuncAndActionDelegatesInCsharp.Func;

namespace FuncAndActionDelegatesInCsharp;
class Program
{
    static void Main(string[] args)
    {

        // Action delegate
        Console.WriteLine(nameof(BeforeUsingActionDelegate));
        var beforeAction = new BeforeUsingActionDelegate();
        beforeAction.SendEmails();

        Console.WriteLine();

        Console.WriteLine(nameof(AfterUsingActionDelegate));
        var afterAction = new AfterUsingActionDelegate();
        afterAction.SendEmails();

        Console.WriteLine();

        // Func delegate
        Console.WriteLine(nameof(BeforeUsingFuncDelegate));
        var beforeFunc = new BeforeUsingFuncDelegate();
        beforeFunc.SendEmails();

        Console.WriteLine();

        Console.WriteLine(nameof(AfterUsingFuncDelegate));
        var afterFunc = new AfterUsingFuncDelegate();
        afterFunc.SendEmails();
    }
}
