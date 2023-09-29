using ActionDelegates;
class Program
{
    static void Main(string[] args)
    {
        Action PrintConsoleText = ActionHandler.GetConsoleText;
        Action<string> PrintUserDefinedText = ActionHandler.GetUserDefinedText;
        Action<int, int> PrintUserDefinedNumbers = ActionHandler.GetUserDefinedNumbers;

        PrintConsoleText();
        PrintUserDefinedText("Example Text");
        PrintUserDefinedNumbers(1, 10);
        Console.ReadLine();
    }
}