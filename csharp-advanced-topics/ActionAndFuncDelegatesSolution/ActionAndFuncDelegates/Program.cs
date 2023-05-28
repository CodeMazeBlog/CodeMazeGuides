using System;

namespace delegate_namespace
{
    internal class Delegates
    {
        public static int GetSquare(int number)
        {
            return number * number;
        }
        public static void GetCube(int number)
        {
            int result = number * number * number;
            Console.WriteLine($"The result is {result}");
        }
        public static void Main(string[] args)
        {
            Func<int, int> funcDelegate = GetSquare;
            int result = funcDelegate.Invoke(11);
            Console.WriteLine($"The result is {result}");

            Action<int> actionDelegate = GetCube;
            actionDelegate.Invoke(6);

            Console.ReadKey();
        }
    }
}