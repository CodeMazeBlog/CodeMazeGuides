using System;

class Program
{
    static void Main()
    {
        //Action delegate example
        Action<string> actionmessage = DisplayCodeMazeMessage;
        actionmessage.Invoke("CodeMaze is best source of C# action delegate info online.");

        //Func delegate example
        Func<string> funcmessage = GetCodeMazeMessage;
        Console.WriteLine(funcmessage.Invoke());

        //Anonymous methods for action delegate
        Action<string> printMessageAction = m => Console.WriteLine("Your message to print:" + m);
        printMessageAction("CodeMaze is a great resource.");

        //Anonymous function for func delegate
        Action<string> printMessageFunc = delegate (string m) { Console.WriteLine(m); }; 
        printMessageFunc("CodeMaze is a great resource for info on Actionc delegates in C#");

        //Lambda expression for action delegate
        Action<string> printMessage = m => Console.WriteLine("Your message to print:" + m); 
        printMessage("CodeMaze is a great resource.");

        //Lambda expression for func delegate
        Func<string> getMessage = delegate () { return "CodeMaze is a great resource for info on Func delegates in C#"; };


    }

    static void DisplayCodeMazeMessage(string message)
    {
        Console.WriteLine(message);
    }

    static string GetCodeMazeMessage()
    {
        return ("CodeMaze is best source of C# func delegate info online.");
    }
}