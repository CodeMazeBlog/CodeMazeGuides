using System;

namespace ActionandFuncDelegates
{
    // Code samples for article writing
    public class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Invoking the function by using delegate
            var firstSum = solution.sumDelegate.Invoke(2, 3);
            Console.WriteLine(firstSum);
            // Second way to invoke the delegate
            var secondSum = solution.sumDelegate(2, 3);
            Console.WriteLine(secondSum);

            // Initialising Action Delegate
            Action<string, string> print = Solution.PrintCoupleNames;
            // Invoking the Action Delegate
            print("Ravi", "Sri");

            // Initialising the Func Delegate
            Func<int, int, int> getSum = Solution.CalculateSum;
            // Invoking the Func Delegate
            var sumFromFuncDelegate = getSum(2, 3);
            Console.WriteLine($"Sum returned by the func delegate is {sumFromFuncDelegate}");

        }

    }

}
