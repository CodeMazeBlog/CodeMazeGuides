using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncApp
{
    internal class Program
    {
        private static int result;
        static void Main(string[] args)
        {
            //Action Delegate in Action
            //way 1 to refer to a function using Action delegate.
            Action<int, int> Addition = AddNumbers;
            Addition(10, 20);
            Console.WriteLine($"Addition = {result}");

            // Way 2 to refer to a function using Action delegate.
            Action<int, int> AdditionActionDelegateAnotherway = new Action<int, int>(AddNumbers);
            AdditionActionDelegateAnotherway(1, 10);
            Console.WriteLine($"Addition using ActionDelegateAnotherway = {result}");

            // Way 3 to refer to a function using Action delegate.
            Action<int, int> SubsActionDelegateAnonymous = delegate (int num1, int num2)
            {
                result = num1 - num2;
            };

            SubsActionDelegateAnonymous(20, 15);
            Console.WriteLine($"Addition using SubsActionDelegateAnonymous = {result}");

            //Func Delegate example
            // Way 1 to refer to a function using Func delegate.
            Func<int, int, int> AdditionUsingFunc =GetSum;
            int sum = AdditionUsingFunc(20, 40);
            Console.WriteLine($"Sum using AdditionUsingFunc = {sum}");

            // Way 2 to refer to a function using Func delegate.
            Func<int, int, int> AdditionUsingFunc2 = new Func<int, int, int>(GetSum);
            sum = AdditionUsingFunc2(30, 40);
            Console.WriteLine($"Sum using AdditionUsingFunc2 = {sum}");

            // Way 3 to refer to a function using Func delegate.
            Func<int, int, int> AdditionUsingFunc3 = delegate(int num1, int num2){
                return num1 + num2;
            };
            sum = AdditionUsingFunc3(40, 40);
            Console.WriteLine($"Sum using AdditionUsingFunc3 = {sum}");

            Console.ReadKey();
        }

        private static void AddNumbers(int param1, int param2)
        {
            result = param1 + param2;
        }

        private static int GetSum(int param1, int param2)
        {
            return param1 + param2;
        }
    }
}
