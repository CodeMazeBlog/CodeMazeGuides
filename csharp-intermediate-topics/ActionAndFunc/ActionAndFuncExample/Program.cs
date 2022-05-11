namespace ActionAndFuncExample;

public delegate void Log(string message);

public class Program
{
    static void Main()
    {
        DelegateExamples();
        ActionExamples();
        FuncExample();
    }

    static void DelegateExamples()
    {
        Console.WriteLine("\n\nDelegate example output:");
        var message = "delegate example message";

        Log logger = Logger.LogToConsole;
        Log logger1 = delegate (string message) { Console.WriteLine($"ANONYMOUS:\t{message}"); };
        Log logger2 = message => Console.WriteLine($"LAMBDA :\t{message}");

        logger(message);
        logger1(message);
        logger2(message);
    }

    static void ActionExamples()
    {
        Console.WriteLine("\n\nAction example output:");
        var message = "action example message";

        Action<string> logger = Logger.LogToConsole;
        Action<string> logger1 = delegate (string message) { Console.WriteLine($"ANONYMOUS:\t{message}"); };
        Action<string> logger2 = message => Console.WriteLine($"LAMBDA :\t{message}");

        logger(message);
        logger1(message);
        logger2(message);
    }

    static void FuncExample()
    {
        Console.WriteLine("\n\nFunc example output:");
        int num1 = 10, num2 = 2;
        Action<string> logger = Logger.LogToConsole;
        
        Func<int, int, int> calculator = Calculator.Add;
        var result = calculator(num1, num2);
        logger($"ADD: {num1} + {num2} = {result}");
        
        calculator = Calculator.Multiply;
        var result2 = calculator(num1, num2);
        logger($"MULTIPLY: {num1} + {num2} = {result2}");
    }

}
