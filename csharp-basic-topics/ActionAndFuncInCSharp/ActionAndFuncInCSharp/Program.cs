namespace ActionAndFuncInCSharp
{
    internal class Program
    {
        internal static void Main()
        {
            var console = new RealConsole(); // Wraps the console for the sake of testing

            var actionMethods = new ActionMethods(console);
            var funcMethods = new FuncMethods(console);

            Console.WriteLine("Welcome! Let's exercise some Action delegates.");
            Console.WriteLine();

            Console.WriteLine("First, we print a simple message.");
            Console.Write("> ");
            actionMethods.PrintAMessage();
            Console.WriteLine();

            Console.WriteLine("Next, print a custom message by passing an action to a method.");
            Console.Write("> ");
            actionMethods.PrintAHelloMessage();
            Console.WriteLine();

            Console.WriteLine("Finally, print a repeated message by passing an action to be invoked multiple times.");
            Console.Write("> ");
            actionMethods.PrintMoreHelloMessages();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Now let's see some Func delegates.");
            Console.WriteLine();

            Console.WriteLine("First, we stringify the number 42.");
            Console.Write("> ");
            funcMethods.PrintANumber();
            Console.WriteLine();

            Console.WriteLine("Next, let's calculate the square of the number 2.");
            Console.Write("> ");
            funcMethods.SquareANumber();
            Console.WriteLine();

            Console.WriteLine("A different func references the same method to calculate the square of the number 10.");
            Console.Write("> ");
            funcMethods.SquareAnotherNumber();
            Console.WriteLine();

            Console.WriteLine("And this one has more than one input. Let's check whether 1 is greater than 2.");
            Console.Write("> ");
            funcMethods.CheckANumber();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
