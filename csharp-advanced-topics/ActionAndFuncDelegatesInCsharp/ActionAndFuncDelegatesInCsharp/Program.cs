// See https://aka.ms/new-console-template for more information
namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string> writeMessage = Display.DisplayText;
            writeMessage("WARAP");

            Func<int, int, int> multiply = Calculator.Multiply;
            int myResult = multiply(1, 2);
            Console.WriteLine(myResult);
        }
    }
}
