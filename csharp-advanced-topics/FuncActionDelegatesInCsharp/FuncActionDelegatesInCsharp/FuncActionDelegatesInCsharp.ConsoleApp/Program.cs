namespace FuncActionDelegatesInCsharp.ConsoleApp;

public class Program
{    

    public static void Main()
    {
        SelectDelegate();
        SelectFunc();
        AcceptFuncArgument();
        AcceptFuncWithParameters();
        AcceptFuncWithParametersLambda();
    }

    private static void AcceptFuncWithParameters()
    {
        var funcDelegatesParameters = new FuncDelegatesParameters();
        var result = funcDelegatesParameters.CallAcceptFuncWithParameters();
        Console.WriteLine(result);
    }

    private static void AcceptFuncWithParametersLambda()
    {
        var funcDelegatesParameters = new FuncDelegatesParameters();
        var result = funcDelegatesParameters.CallAcceptFuncWithParametersLambda();
        Console.WriteLine(result);
    }

    private static void AcceptFuncArgument()
    {
        var funcDelegatesParameters = new FuncDelegatesParameters();
        Console.WriteLine(funcDelegatesParameters.CallAcceptFunc());
    }        

    private static void SelectFunc()
    {
        var delegates = new FuncDelegates();

        Console.WriteLine("Func1 or 2?");
        var choice = Console.ReadKey();
        if (choice.Key == ConsoleKey.D1)
            Console.WriteLine(delegates.UseDelegate(1));
        else
            Console.WriteLine(delegates.UseDelegate(2));        
    }   

    private static void SelectDelegate()
    {
        var delegates = new Delegates();

        Console.WriteLine("1: Func1");
        Console.WriteLine("2: Func2");
        var choice = Console.ReadKey();
        if (choice.Key == ConsoleKey.D1)
        {
            Console.WriteLine(delegates.UseDelegate(1));
        }
        else
        {
            Console.WriteLine(delegates.UseDelegate(2));
        }
    }

}
