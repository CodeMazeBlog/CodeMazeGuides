namespace FuncAndActionInCSharp
{
    public class Program
    {
        // Define your delegate
        public delegate void MyDelegate(string message);

        static void Main(string[] args)
        {
            MyDelegate myDelegate = PrintMessage;
            myDelegate("myDelegate: Hello World!");

            Calculator calculator = new();
            int addResult = calculator.Add(1, 2);
            Console.WriteLine(addResult);

            Printer printer = new();
            printer.PrintMessage("Hello World!");
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}