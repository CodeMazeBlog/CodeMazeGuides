using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public enum MathOperation
    {
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4
    }
    public class DelegatesDemo
    {
        private delegate int PerformOperation(int a, int b);
        private delegate void ProcessResult(MathOperation operation, int result);

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
            PerformOperation operationDelegate;
            switch (operation)
            {
                case MathOperation.Add:
                    operationDelegate = new PerformOperation(DelegatesDemo.Add);
                    break;
                case MathOperation.Subtract:
                    operationDelegate = new PerformOperation(DelegatesDemo.Subtract);
                    break;
                case MathOperation.Multiply:
                    operationDelegate = new PerformOperation(DelegatesDemo.Multiply);
                    break;
                case MathOperation.Divide:
                    operationDelegate = new PerformOperation(DelegatesDemo.Divide);
                    break;
                default:
                    operationDelegate = new PerformOperation(DelegatesDemo.Add);
                    break;
            }
            var result = operationDelegate(operand_1, operand_2);
            return result;
        }
        private static void Print(int result, MathOperation operation)
        {
            ProcessResult resultProcessorDelegate = new ProcessResult(PrintToConsole);
            resultProcessorDelegate(operation, result);
        }
    }
}
