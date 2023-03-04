using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Function_Delegates
{
    public delegate void DelegateOutsideClass(int x);
    public class DelegateSample
    {
        public static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public delegate string DelegateInsideClass(string arg);

        public static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        public static void PrintNumber(int x)
        {
            Console.WriteLine($"Number passed to method {x}");
        }

        public static string PrintArgPass(string arg)
        {
            return arg.ToUpper();
        }

        public static void TestDelegate()
        {
            DelegateOutsideClass delegateOutsideClass = new(PrintNumber);
            DelegateInsideClass delegateInsideClass = new(PrintArgPass);

            delegateOutsideClass(20);
            var upperString = delegateInsideClass("change me to upper case");

            Action<int> printDelegate = new(PrintNumber);
            printDelegate(20);

            Func<int, int, int> addDelegate = AddTwoNumbers;
            addDelegate(20, 20);
        }
    }
}
