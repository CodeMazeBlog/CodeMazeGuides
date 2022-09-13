using System;

class Program
{
    static void Main()
    {
        Action<string> actionmessage = DisplayCodeMazeMessage;
        actionmessage.Invoke("CodeMaze is best source of C# action delegate info online.");

        Func<string> funcmessage = GetCodeMazeMessage;
        Console.WriteLine(funcmessage.Invoke());
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