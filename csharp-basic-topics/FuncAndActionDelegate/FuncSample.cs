using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegate
{
    public static class FuncSample
    {
        private static Func<int, int, int> Add = (x, y) => x + y;

        private static Func<int, int, int> Multiply = (x, y) => x * y;


        public static int Calculate(int firstNumber, int secondNumber, string operation)
        {
            if(operation == "add")
            {
                return Add(firstNumber, secondNumber);
            }
            if (operation == "multiply")
            {
                return Multiply(firstNumber, secondNumber);
            }
            return 0;
        }
        
    }
}
