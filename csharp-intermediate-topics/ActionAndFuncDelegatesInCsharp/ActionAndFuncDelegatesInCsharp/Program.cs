using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tests")]


namespace ActionAndFuncDelegatesInCsharp;

internal class Program
{
    internal static void Print()
    {
        Console.WriteLine("Happy Coding");
    }

    internal static void PrintMessage(string message1, string message2)
    {
        Console.WriteLine($"{message1}{message2}");
    }

    internal static string CapitaliseMessage(string message)
    {
        return message.ToUpper();
    }

    static void Main(string[] args)
    {
        //Declare Actions and Func
        Action actionWithoutParameters = Print;
        Action<string, string> actionWithParameters = PrintMessage;
        Func<string, string> funcWithParameter = CapitaliseMessage;

        // Execute Actions and Func
        actionWithoutParameters();
        actionWithParameters("Happy Coding", " with CodeMaze");

        string upperHappyCoding = funcWithParameter("Happy Coding");
        Console.WriteLine(upperHappyCoding);

        var messages = new List<string>() { "Happy", "Coding", "with", "CodeMaze" };
        messages = messages
                    .Where(m => m.Length > 4)
                    .Select(m => m.ToUpper())
                    .ToList();
        //messages is: { "HAPPY", "CODING", "CODEMAZE" }
    }


}