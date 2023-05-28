using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_namespace
{
    internal class Delegates
    {
        public static int GetSquare(int number)
        {
            return number * 2;
        }
        public static void GetCube(int number)
        {
            int result = number * 3;
            Console.WriteLine($"The result is {result}");
        }
        public static void Main(string[] args)
        {
            Func<int, int> funcDelegate = GetSquare;
            int result = funcDelegate.Invoke(19);
            Console.WriteLine($"The result is {result}");

            Action<int> actionDelegate = GetCube;
            actionDelegate.Invoke(33);

            Console.ReadKey();
        }
    }
}