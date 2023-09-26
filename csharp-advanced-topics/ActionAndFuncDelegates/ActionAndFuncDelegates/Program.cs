using ActionAndFuncDelegates;

class Program
{
    static void Main(string[] args)
    {
        // passing all method directly that needs to be called,as it reduces more code spaces and looks more readable
       
        Action PrintConsoleText = MethodService.GetConsoleText;
        Action<string> PrintUserDefinedText = MethodService.GetUserDefinedText;
        Action<int, int> PrintUserDefinedNumbers = MethodService.GetUserDefinedNumbers;

        Func<int> PrintRandomNumber = MethodService.GetRandomNumber;
        Func<string, string,string, string> PrintReturnNames = MethodService.GetNamesReturn;

        Console.WriteLine("\n*** Action<T> Delegate without return value ***************\n");

        PrintConsoleText(); // without any input, no output expected
        PrintUserDefinedText("Example Text"); // input is there,it will only print the text with that input 
        PrintUserDefinedNumbers(1, 10); // inputs are there,it will only print the numbers.
        
        Console.WriteLine("\n***** Func<T> Delegate with return value expected ************\n");

        Console.WriteLine("Random Number is: {0}", PrintRandomNumber()); // without any input,return value integer
        Console.WriteLine("Concatenated Names - " + PrintReturnNames("First", "Second", "Third")); // with inputs,return concatenated string
        Console.ReadLine();
    }
}