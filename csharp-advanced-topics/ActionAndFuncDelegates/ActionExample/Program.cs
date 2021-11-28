using System;

namespace ActionExample
{
    class Program
    {
        static void MyAddFuction(int x, int y)
        {
            Console.WriteLine($"Result {x + y}");
        }

        static void MyMultiplyFuction(int x, int y)
        {
            Console.WriteLine($"Result {x * y}");
        }

        static void Main(string[] args)
        {

            Action<int, int> actionDelegate = MyAddFuction;
            actionDelegate(2, 3); 

            actionDelegate = MyMultiplyFuction;
            actionDelegate(2, 3);

            Console.ReadLine();
        }
    }
}
