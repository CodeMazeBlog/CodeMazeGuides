using FuncDelegates;
class Program
{
    static void Main(string[] args)
    {
        Func<int> PrintRandomNumber = FuncHandler.GetRandomNumber;
        Func<string, string, string, string> PrintReturnNames = FuncHandler.GetNamesReturn;

        Console.WriteLine("Random Number is: {0}", PrintRandomNumber());
        Console.WriteLine("Concatenated Names - " + PrintReturnNames("First", "Second", "Third"));
        Console.ReadLine();
    }
}