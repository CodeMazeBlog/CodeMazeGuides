using System;
namespace DelegatesDemo.DelegateAppl
{
    public class FuncDemo
    {
        public static Func<int, int, int> intMultiplyFunc = delegate (int a, int b)
        {
            return a * b;
        };

        public static void RunFunc()
        {
            int intMultResult = intMultiplyFunc(15, 1);
            Console.WriteLine(intMultResult);

            Func<int, int, int> intSumFunc = (a, b) => a + b;
            int intSumResult = intSumFunc(5, 3);
            Console.WriteLine(intSumResult);
            Console.ReadKey();
        }
    }
}
