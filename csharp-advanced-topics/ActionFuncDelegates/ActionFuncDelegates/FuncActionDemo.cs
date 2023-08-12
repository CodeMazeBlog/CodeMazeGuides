using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class FuncActionDemo
    {
        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static int Subtract(int x, int y)
        {
            return x - y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
        private static int Divide(int x, int y)
        {
            return x / y;
        }

        private static void PrintToConsole(MathOperation operation, int result)
        {
            Console.WriteLine($"Result of {operation.ToString()} : {result}");
        }
        public static void CalculateAndPrint(int operand_1, int operand_2, MathOperation operation)
        {
            var result = Calculate(operand_1, operand_2, operation);
            Print(result, operation);
        }
        public static int Calculate(int operand_1, int operand_2, MathOperation operation)
        {
            //private delegate int PerformOperation(int a, int b) -- NOT REQUIRED
            Func<int, int, int> operationFunc;

            switch (operation)
            {
                case MathOperation.Add:
                    operationFunc = Add;
                    break;
                case MathOperation.Subtract:
                    operationFunc = Subtract;
                    break;
                case MathOperation.Multiply:
                    operationFunc = Multiply;
                    break;
                case MathOperation.Divide:
                    operationFunc = Divide;
                    break;
                default:
                    operationFunc = Add;
                    break;

            }
            var result = operationFunc(operand_1, operand_2);
            return result;
        }
        private static void Print(int result, MathOperation operation)
        {
            //private delegate void ProcessResult(MathOperation operation, int result) -- NOT REQUIRED
            Action<MathOperation, int> resultProcessorAction = PrintToConsole;

            resultProcessorAction(operation, result);
        }
    }
}
