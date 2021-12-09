using System;

namespace ActionAndFuncDelegatesCSharp
{
    public class Program
    {
        // Declaration of non-generic SayPhrase delegate type
        public delegate void SayPhrase(string phrase);

        public static void NamedDelegateVsActionComparison()
        {
            // Non-generic SayPhrase delegate assignment
            SayPhrase sayPhraseDelegate = Console.WriteLine;

            // Generic Action<T> delegate assignment
            Action<string> SayPhraseAction = Console.WriteLine;

            var hw = "Hello world!";

            // Both work in the same way after assigned
            sayPhraseDelegate(hw);
            SayPhraseAction(hw);
        }

        public static void ActionAndFuncUsageExample()
        {
            Action<int, int, double> printNumbers = (n1, n2, n3) => Console.WriteLine($"{n1}, {n2}, {n3}");
            Func<int, int, double, double> sumNumbers = (n1, n2, n3) => n1 + n2 + n3;

            printNumbers(1, 2, 2.2); // Will print the numbers and return nothing
            sumNumbers(1, 2, 2.2); // Will return the sum of all numbers (5.2)

            // You can even combine the invocation of the delegates:
            printNumbers(3, 12, sumNumbers(4, 2, 5.1));
        }

        static void Main(string[] args)
        {
            NamedDelegateVsActionComparison();
            Console.Write("\n");
            ActionAndFuncUsageExample();
        }

    }
}
