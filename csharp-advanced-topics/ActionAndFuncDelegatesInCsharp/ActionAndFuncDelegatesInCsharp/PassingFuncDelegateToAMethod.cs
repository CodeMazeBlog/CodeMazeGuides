using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class PassingFuncDelegateToAMethod
    {
        int Multiply(int operand1, int operand2)
        {
            return operand1 * operand2;
        }
        int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
        int Calculate(int operand1, int operand2, Func<int, int, int> operation)
        {
            return operation(operand1, operand2);
        }
        public int RunAddExample()
        {
            int operationResult = Calculate(4, 2, Add);
            return operationResult;
        }
        public int RunMultiplyExample()
        {
            int operationResult = Calculate(4, 2, Multiply);
            return operationResult;
        }
    }
}
