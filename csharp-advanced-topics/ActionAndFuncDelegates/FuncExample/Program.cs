using System;

namespace FuncExample
{
    class Program
    {
        static int MyAddFuction(int x, int y)
        {
            return x + y;
        }

        static int MyMultiplyFuction(int x, int y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
            Func<int, int, int> myFuncDelegate = MyAddFuction;
            int result = myFuncDelegate(2, 3); 
            Console.WriteLine($"Result {result}");

            myFuncDelegate = MyMultiplyFuction;
            result = myFuncDelegate(2, 3);
            Console.WriteLine($"Result {result}");

            Console.ReadLine();
        }
    }
}
