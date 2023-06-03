using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace delegate_namespace
{
    public class Delegates
    {
        public static int GetSquare(int number)
        {
            return number * number;
        }

        public static void GetCube(int number)
        {
            int result = CalculateCube(number);
            Console.WriteLine($"The result is {result}");
        }

        private static int CalculateCube(int number)
        {
            return number * number * number;
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