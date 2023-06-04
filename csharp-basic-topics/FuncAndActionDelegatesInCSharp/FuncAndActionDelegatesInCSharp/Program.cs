// See https://aka.ms/new-console-template for more information

namespace FuncAndActionDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("When running a delegate:");
        Delegate();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running an Action delegate:");
        ActionDelegate();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running an Action delegate with multiple parameters:");
        ActionDelegateMultipleParameters();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running a Func delegate:");
        FuncDelegates();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When running a Lambda Expression");
        LambdaExpressions();

        Console.WriteLine("=============================================================");

        Console.WriteLine("When passing a Lambda Expression as a parameter");
        LambdaExpressionsAsParameters();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for data transformation:");
        DelegatesDataTransformation();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for conditional filtering:");
        DelegatesConditionalFiltering();

        Console.WriteLine("=============================================================");

        Console.WriteLine("Using delegates for invoking callbacks:");
        DelegatesCallback();

    }




    public static void Delegate()
    {
        static void GreetUser(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }
        Greet greetMethod = GreetUser;
        greetMethod("Code Maze"); //Output: Hello, Code Maze
    }

    public static void ActionDelegate()
    {
        Action<string> greetMethod = GreetUser;
        static void GreetUser(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }
        greetMethod("Code Maze"); //Output: Hello, Code Maze
    }

    public static void ActionDelegateMultipleParameters()
    {
        Action<string, DateTime> greetMethod = GreetUser;
        static void GreetUser(string name, DateTime date)
        {
            Console.WriteLine($"Hello, {name} @ {date:dd/MM/yyyy HH:mm}");
        }
        greetMethod("Code Maze", DateTime.Now); //Output: Hello, Code Maze @ 04/06/2023 11:32
    }

    public static void FuncDelegates()
    {
        Func<string, DateTime, string> greetMethod = GetGreetUser;
        static string GetGreetUser(string name, DateTime date)
        {
            return $"Hello, {name} @ {date:dd/MM/yyyy HH:mm}";
        }
        var greetResult = greetMethod("Code Maze", DateTime.Now);
        Console.WriteLine(greetResult); //Output: Hello, Code Maze @ 04/06/2023 11:32
    }

    public static void LambdaExpressions()
    {
        Func<string, string> greetExpression = (name) => $"Hello, {name}";
        Console.WriteLine(greetExpression("Code Maze")); //Output: Hello, Code Maze
    }

    public static void LambdaExpressionsAsParameters()
    {
        static void PrintGreet(string name, Func<string, string> greetFunc)
        {
            Console.WriteLine(greetFunc(name));
        }
        PrintGreet("Code Maze", (name) => $"Hello, {name}"); //Output: Hello, Code Maze
    }

    public static void DelegatesDataTransformation()
    {
        var values = new List<string>
    {
        "code maze",
        "c#",
        "delegates"
    };
        Func<string, string> capitalize = (value) => value.ToUpper();
        var capitalizedValues = values.Select(capitalize).ToList(); //Result: {"CODE MAZE", "C#", "DELEGATES"}
        capitalizedValues.ForEach(Console.WriteLine);
    }

    public static void DelegatesConditionalFiltering()
    {
        var values = new List<string>
    {
        "this string contains Code Maze",
        "this string does not!",
    };
        Func<string, bool> containsCodeMaze = (value) => value.Contains("Code Maze");
        var stringsWithCodeMaze = values.Where(containsCodeMaze).ToList(); //Result: {""this string contains Code Maze"}
        stringsWithCodeMaze.ForEach(Console.WriteLine);
    }

    public static void DelegatesCallback()
    {
        static void Callback(string value)
        {
            Console.WriteLine($"Callback invoked with value: {value}");
        }
        static void ProcessEvent(string initailValue, Action<string> callback)
        {
            var newValue = $"{initailValue} Maze";
            callback(newValue);
        }
        ProcessEvent("Code", Callback); //Output: Callback invoked with value: Code Maze
    }



    delegate void Greet(string name);
}
