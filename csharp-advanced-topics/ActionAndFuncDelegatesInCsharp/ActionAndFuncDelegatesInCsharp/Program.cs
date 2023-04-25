// See https://aka.ms/new-console-template for more information
namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string> writeMessage = Display.DisplayText;
            writeMessage("WARAP");

            Func<int, int, int> multiply = new Calculator().Multiply;
            int myResult = multiply(1, 2);
            Console.WriteLine(myResult);

            //int result = addNumbers(1, 2);
            //Console.WriteLine(result);
            
            //var calculator = new Calculator();
            //int a = 2;
            //int b = 3;
            //int result = calculator.Multiply(a, b);
            //Console.WriteLine(result);
        }
    }
}
