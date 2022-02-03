using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndAction
{
    public class FuncAndActionService
    {
        public delegate int DelegateMethod(int a, int b);

        public int DisplayResult(int a, int b)
        {
            return a + b;
        }

        public int CalculateValue(int a, int b)
        {
            return a * b;
        }

        public void PrintValue(int number)
        {
            Console.WriteLine(number);
        }
    }
}
