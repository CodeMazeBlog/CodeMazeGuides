namespace FuncAndActionDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("When running a delegate:");
        Delegates.Delegate();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running an Action delegate:");
        ActionDelegates.ActionDelegate();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running an Action delegate with multiple parameters:");
        ActionDelegates.ActionDelegateMultipleParameters();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running a Func delegate:");
        FuncDelegates.FuncDelegate();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running a Lambda Expression");
        LambdaExpressions.LambdaExpression();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When passing a Lambda Expression as a parameter");
        LambdaExpressions.LambdaExpressionsAsParameters();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for data transformation:");
        DelegateUseCases.DelegatesDataTransformation();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for conditional filtering:");
        DelegateUseCases.DelegatesConditionalFiltering();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for invoking callbacks:");
        DelegateUseCases.DelegatesCallback();

    }
}
