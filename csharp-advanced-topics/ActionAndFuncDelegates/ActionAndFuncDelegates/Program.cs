using ActionAndFuncDelegatesInCSharp;

namespace Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Action delegate in practical");
            PrintNumbersUsingActionDelegate();

            Console.WriteLine("\nFunc delegate in practical");
            PrintFullNamesUsingFuncDelegate();
        }

        public static void PrintNumbersUsingActionDelegate()
        {
            var actionDelegate = new ActionDelegate();

            ActionDelegate.PrintNumbers();
        }
        public static void PrintFullNamesUsingFuncDelegate()
        {
            var funcDelegate = new FuncDelegate();

            FuncDelegate.PrintFullNames();
        }
    }
}
