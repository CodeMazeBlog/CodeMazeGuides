using ActionAndFuncDelegatesInCsharp;

public class Program
{
    static void Main(string[] args)
    {
        //EXAMPLE OF A FUNC DELEGATE

        Console.WriteLine("Result of Func: " + ExecuteAdditionWithFunc(10, 20));

        //EXAMPLE OF AN ACTION DELEGATE

        WriteToConsoleWithAction("Hello World!");
    }

    public static int ExecuteAdditionWithFunc(int a, int b)
    {
        Func<int, int, int> addFunc = new Func<int, int, int>(Calculator.Add);
        var result = addFunc(a, b);

        return result;
    }

    public static void WriteToConsoleWithAction(string message)
    {
        Action<string> writeAction = new Action<string>(ConsoleHandler.Write);
        writeAction(message);
    }
}