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

            //assign directly custom add function to Action<T>
            Action<int, int> actionDelegate = MyAddFuction;
            actionDelegate(2, 3); //MyAddFuction is called via delegate , result 5

            //assign directly custom multiply function to Action<T>
            actionDelegate = MyMultiplyFuction;
            actionDelegate(2, 3);//MyMultiplyFuction is called via delegate , result 6

            Console.ReadLine();
        }
    }
}
