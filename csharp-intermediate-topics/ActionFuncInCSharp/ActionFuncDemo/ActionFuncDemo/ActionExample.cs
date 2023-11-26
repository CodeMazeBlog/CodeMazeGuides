namespace ActionFuncDemo;

public class ActionExample
{
    public static void PrintToConsole(int number, string text, double value)
    {
        Action<int, string, double> printToConsoleActionDelegate = (number, text, value) =>
        {
            Console.WriteLine($"Received: {number}, {text}, {value}");
        };

        printToConsoleActionDelegate(number, text, value);
    }
}