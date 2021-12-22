using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFunc
{
    public class ActionAndFuncMethod
    {

        //Methods that takes parameters but returns nothing:  

        public static void PrintProjectTitle()
        {
            Console.WriteLine("Func and Action delegate simulator");
        }

        public static void PrintRange(int start, int target)
        {
            for (int i = start; i <= target; i++)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }

        public static void PrintCustomInput(string message)
        {
            Console.WriteLine(message);
        }

        //Methods that takes parameters and returns a value:  

        public static int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public static string AddWithNarration(int a, int b)
        {
            return string.Format("Addition of {0} and {1} is {2}", a, b, a + b);
        }

        public static string ConcatinateName(string firstName, string lastName)
        {
            return string.Format("Your Name is {0} {1}", firstName, lastName);
        }
    }
}
