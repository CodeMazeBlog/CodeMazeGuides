using System;

namespace FuncDelegates
{
    public class Program
    {
        private delegate int SumDelegate(int num1, int num2);

        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(InvokeSumViaFuncDelegate(2, 2));
            // Writes 4 to the console
        }

        public static int InvokeSumViaFuncDelegate(int num1, int num2)
        {
            Func<int, int, int> sumFunc = Sum;
            return sumFunc.Invoke(num1, num2);
        }
    }
}
