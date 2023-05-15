using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegation
{
    public class GenericMethods
    {
        public double Addition(float num1, float num2)
        {
            return num1 + num2;
        }

        public double Multiplication(float num1, float num2)
        {
            return num2 * num1;
        }

        public void PrintString(string stringVal)
        {
            Console.WriteLine(stringVal);
        }
    }
}
