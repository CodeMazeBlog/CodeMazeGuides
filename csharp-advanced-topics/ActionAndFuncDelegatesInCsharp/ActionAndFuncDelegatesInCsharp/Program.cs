DemoClass.RunActionWithInstantiation();
DemoClass.RunActionWithReference();
DemoClass.RunActionWithLambdaMethod();
DemoClass.RunActionInHigherOrderFunction();
DemoClass.RunActionWithAParameter();
DemoClass.RunFuncWithoutParameter();
DemoClass.RunFuncWithAParameter();

public class DemoClass
{
    private static void PrintHelloWorld()
    {
        Console.WriteLine("Hello World!");
    }

    private static void RunAction(Action action)
    {
        Console.Write("Greetings! ");
        action();
    }

    public static void RunActionWithInstantiation()
    {
        var action = new Action(PrintHelloWorld);
        action();
    }

    public static void RunActionWithReference()
    {
        var action = PrintHelloWorld;
        action();
    }

    public static void RunActionWithLambdaMethod()
    {
        var action = () => { Console.WriteLine("Hello World!"); };
        action();
    }

    public static void RunActionInHigherOrderFunction()
    {
        RunAction(PrintHelloWorld);
    }

    public static void RunActionWithAParameter()
    {
        Action<string> printMessage
            = (message) => { Console.WriteLine(message); };

        printMessage("Hello Code Maze!");
    }

    public static void RunFuncWithoutParameter()
    {
        Func<int> get42 = () => 42;
        Console.WriteLine(get42());
    }

    public static void RunFuncWithAParameter()
    {
        Func<int, int> add42 = (x) => x + 42;
        Console.WriteLine(add42(5));
    }
}
