using System;

namespace FuncActionDelegates
{
    class Program
    {
        public static int SumTwoNumbers(int first, int second)
        {
            return first + second;
        }
        static void Main(string[] args)
        {
            Func<int, int, int> funcVariables = SumTwoNumbers;

            int returnFromSum = funcVariables(100, 50);

            Console.WriteLine("Sum of variables is:" + returnFromSum);

            CallActionDelegate();
        }

        private static void CallActionDelegate()
        {
            Action<int> addCredit = delegate (int value)
            {
                Console.WriteLine("Added credit value: " + value);
            };

            addCredit(10);
        }
    }
}
