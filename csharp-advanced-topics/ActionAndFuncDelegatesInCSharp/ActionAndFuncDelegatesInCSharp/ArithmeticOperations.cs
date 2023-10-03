using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    /// <summary>
    /// Performs basic arithmetic operations
    /// </summary>
    public class ArithmeticOperations
    {
        public double Sum(double operand1, double operand2) => operand1 + operand2;
        public double Subtract(double operand1, double operand2) => operand1 - operand2;
        public double Multiply(double operand1, double operand2) => operand1 * operand2;
        public double Divide(double operand1, double operand2) => operand1 / operand2;
        public double ExecArithmeticOperation(Func<double, double, double> operation, double operand1, double operand2)
        {
            return operation(operand1, operand2);
        }
    }
}
