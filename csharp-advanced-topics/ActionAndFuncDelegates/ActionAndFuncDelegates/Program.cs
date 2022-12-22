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
            ActionDelegate.PrintNumbers();
        }

        public static void PrintFullNamesUsingFuncDelegate()
        {
            FuncDelegate.PrintFullNames();
        }
    }
}
