using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class CallingAMethodFromAFuncDelegate
    {
        int Multiply(int operand1, int operand2)
        {
            return operand1 * operand2;
        }
        public int RunExample()
        {
            Func<int, int, int> func = Multiply;
            int multiplicationResult = func(2, 2);
            return multiplicationResult;
        }
    }
}
