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
            //assign directly add function to Func<T,TResult> delegete
            Func<int, int, int> myFuncDelegate = MyAddFuction;
            int result = myFuncDelegate(2, 3); //MyAddFuction is called via Func delegate, there is a return value
            Console.WriteLine($"Result {result}");//result 5

            //assign directly multiply function to Func<T,TResult>
            myFuncDelegate = MyMultiplyFuction;
            result = myFuncDelegate(2, 3);//MyMultiplyFuction is called via Func delegate, there is a return value
            Console.WriteLine($"Result {result}");//result 6

            Console.ReadLine();
        }
    }
}
