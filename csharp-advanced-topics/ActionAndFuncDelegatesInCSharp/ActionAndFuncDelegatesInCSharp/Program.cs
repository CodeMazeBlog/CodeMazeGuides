namespace ActionAndFuncDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        const string message = "Hello, Code Maze!";

        PrintMessageWithAction(message);

        var length = GetMessageLengthWithFunc("Hello, Code Maze!");
        Console.WriteLine(length);
    }

    public static void PrintMessageWithAction(string message)
    {
        var action = ShowMessage;
        action(message);
    }

    public static int GetMessageLengthWithFunc(string message)
    {
        var getMessageLength = MessageLength;
        var length = getMessageLength(message);
        return length;
    }

    private static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    private static int MessageLength(string message)
    {
        return message.Length;
    }
}