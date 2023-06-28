using System;

namespace FuncAndActionInCsharp
{
    class Program
    {
        private static string PrintMsg()
        {
            return "Hi! We are in PrintMsg Method";
        }
        private static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        static void Main(string[] args)
        {
            //Creating Func Delegate
            Func<string> myFuncDelegate = PrintMsg;

            //Calling Func Delegate
            Console.WriteLine(myFuncDelegate());

            //Creating Action Delegate

            Action<string> greetAction = Greet;

            //Calling Action Delegate
            greetAction("John");
            greetAction("Emily");

            //Using Func delegate to check if a number is even
            Func<int, bool> isEvenFunc = number => number % 2 == 0;
            int num = 7;
            bool isEven = isEvenFunc(num);
            Console.WriteLine($"Is {num} even? {isEven}");

            //Using Action delegate to print the current date and time
            Action printDateTimeAction = () => Console.WriteLine(DateTime.Now);
            printDateTimeAction();

        }
    }
}