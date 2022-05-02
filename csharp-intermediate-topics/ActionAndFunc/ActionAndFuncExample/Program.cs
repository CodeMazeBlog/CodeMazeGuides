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
    static void LogToConsole(string message)
    {
        Console.WriteLine($"METHOD :\t{message}");
    }
    static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
    static int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }

    static void DelegateExamples()
    {
        Console.WriteLine("\n\nDelegate example output:");
        string message = "delegate example message";
        Log logger = LogToConsole;
        Log logger1 = delegate (string message) { Console.WriteLine($"ANONYMOUS:\t{message}"); };
        Log logger2 = message => Console.WriteLine($"LAMBDA :\t{message}");
        logger(message);
        logger1(message);
        logger2(message);
    }
    static void ActionExamples()
    {
        Console.WriteLine("\n\nAction example output:");
        string message = "action example message";
        // Initiate Action delegate 
        Action<string> logger = LogToConsole;
        Action<string> logger1 = delegate (string message) { Console.WriteLine($"ANONYMOUS:\t{message}"); };
        Action<string> logger2 = message => Console.WriteLine($"LAMBDA :\t{message}");
        // Call Action delegates
        logger(message);
        logger1(message);
        logger2(message);
    }
    static void FuncExample()
    {
        Console.WriteLine("\n\nFunc example output:");
        int num1 = 10, num2 = 2;
        Action<string> logger = message => Console.WriteLine($"{DateTime.Now} :\t{message}");
        // Inistantiate Func delegate 
        Func<int, int, int> calculator = Add;
        // Call Func delegate
        int result = calculator(num1, num2);
        logger($"{num1} + {num2} = {result}");
        calculator = Multiply;
        int result2 = calculator(num1, num2);
        logger($"{num1} + {num2} = {result2}");
    }
}
