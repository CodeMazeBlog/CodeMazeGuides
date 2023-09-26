using ActionAndFuncDelegates;
class Program
{
    static void Main(string[] args)
    {
        Action PrintConsoleText = MethodService.GetConsoleText;
        Action<string> PrintUserDefinedText = MethodService.GetUserDefinedText;
        Action<int, int> PrintUserDefinedNumbers = MethodService.GetUserDefinedNumbers;

        Func<int> PrintRandomNumber = MethodService.GetRandomNumber;
        Func<string, string,string, string> PrintReturnNames = MethodService.GetNamesReturn;

        Console.WriteLine("\n**** Action<T> Delegate without return value ****\n");

        PrintConsoleText();
        PrintUserDefinedText("Example Text"); 
        PrintUserDefinedNumbers(1, 10);

        Console.WriteLine("\n**** Func<T> Delegate with return value expected ****\n");

        Console.WriteLine("Random Number is: {0}", PrintRandomNumber());
        Console.WriteLine("Concatenated Names - " + PrintReturnNames("First", "Second", "Third"));
        Console.ReadLine();
    }
}