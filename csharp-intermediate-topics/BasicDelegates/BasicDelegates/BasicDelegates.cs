using System;

namespace BasicDelegates
{
    public class BasicDelegates
    {
        static void PrintGreeting()
        {
            Console.WriteLine("Hello from PrintGreeting!");
        }

        static void DelegateReceiver(Action delegateToUse)
        {
            delegateToUse();
        }

        public static void Main(string[] args)
        {
            // Each of these will invoke the PrintGreeting method.
            Action printDelegate;
            printDelegate = PrintGreeting;
            PrintGreeting();

            // Using the delegate as a variable.
            printDelegate();

            // Passing it to another parameter.
            DelegateReceiver(printDelegate);
        }
    }
}
