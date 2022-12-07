using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate
{
    public class BasicMaths
    {
        //Methods that takes parameters and returns a value:
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        //Methods that takes parameters but returns nothing:
        public static void EvenOrOdd(int number)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("{0} is even number.", number);
            }
            else
            {
                Console.WriteLine("{0} is odd number.", number);
            }
        }

        public static void Maximum(double number1, double number2)
        {
            Console.WriteLine("Maximum of {0} and {1} is {2}.", number1, number2, Math.Max(number1, number2));
        }
    }
}
