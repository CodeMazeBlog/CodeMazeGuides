using System;

namespace FuncDelegates
{
    internal class Program
    {
        private delegate int SumDelegate(int num1, int num2);

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static void Main(string[] args)
        {
            Func<int, int, int> sumFunc = Sum;
            int result = sumFunc.Invoke(2, 2);
            Console.WriteLine(result);
            // Writes 4 to the console
        }
    }
}
