using System;

namespace ActionFuncDelegates
{
    class Program
    {
        public static void Subtract(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        public static int Multiply(int num1, int num2, int num3)
        {
            return num1 * num2 * num3;
        }

        static void Main(string[] args)
        {
            Action<int, int> substractNumbers = Subtract;
            substractNumbers(10, 3);

            Func<int, int, int, int> multiplyNumbers = Multiply;
            Console.WriteLine(multiplyNumbers(10, 10, 1));
        }
    }
}
