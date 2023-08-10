using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    public class FuncAndActionService
    {
        public static int CalculateValue(int a, int b)
        {
            return a * b;
        }

        public static void PrintValue(int number)
        {
            Console.WriteLine($"{number}");
        }
    }
}
