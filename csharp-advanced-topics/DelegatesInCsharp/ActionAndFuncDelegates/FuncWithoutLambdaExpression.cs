using System;

namespace ActionAndFuncDelegates
{
    internal class FuncWithoutLambdaExpression
    {
        static void Main(string[] args)
        {
            // Func delegate without Lambda Expression
            Func<int, bool> isEvenNo = a => CheckEvenNo(a);

            Console.WriteLine($"Is {5} an even no? {isEvenNo(5)}");
            Console.ReadLine();
        }

        private static bool CheckEvenNo(int a)
        {
            return a % 2 == 0;
        }
    }
}
