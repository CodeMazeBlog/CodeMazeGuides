using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class DelegatesMethods
    {
        //Methods that takes parameters but returns nothing:
        public static void PrintText()
        {
            Console.WriteLine("Text Printed with the help of Action delegates!");
        }
        public static void PrintNumbers(int startNumber, int EndNumber)
        {
            for (int i = startNumber; i < EndNumber; i++)
        {
                Console.Write("{0}", i);
            }
            Console.WriteLine();
        }
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        //Methods that takes parameters and returns a value:

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static string DisplayAddition(int a, int b)
        {
            return string.Format("Addition of {0} and {1} is {2}", a, b, a + b);
        }

        public static string FullName(string firstName, string lastName)
        {
            return string.Format("Your Name is {0} {1}", firstName, lastName);
        }
    }
}
