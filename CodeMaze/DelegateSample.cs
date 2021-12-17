using System;
using System.Linq;

namespace CodeMaze
{
    public class MathOperation
    {
        public static int PerformMathsOperation(Func<int, int, int> singleOperationFunc)
        {
            int input1 = 1;
            int input2 = 2;

            return singleOperationFunc(input1, input2);
        }

        public static void DisplayMathResult(Action<string,string> CreateMessage)
        {
            string message1 = "message one";
            string message2 = "message two";
            CreateMessage(message1, message2);
        }

        public static void ProcessMessage(string message1, string message2)
        {
            Console.WriteLine(message1 + message2);
        }

        public static int Add(int input1, int input2)
        {
            return input1 + input2;
        }
    }

    public class DelegateSample
    {
        public int ProcessSingleDigit(int input)
        {
            //DO Something;
            return input;
        }

      
        static void Main(string[] args)
        {
            DelegateSample delegateSample = new DelegateSample();

            //Func Delegate Example

            //Deferred execution means that the evaluation of an
            //expression is delayed until its realized value is 
            //actually required. It greatly improves performance
            //by avoiding unnecessary execution.

            var result = Enumerable.Range(1, 5).Select(delegateSample.ProcessSingleDigit);

            //Can also be done using inline syntax
            //var inlineReult = Enumerable.Range(1, 5).Select((o) => { return o; });

            MathOperation.PerformMathsOperation((input1, input2) => { return input1 + input2; });
            //MathOperation.PerformMathsOperation(MathOperation.Add);

            //Action delegate Example
            result.ToList().ForEach(Console.WriteLine);
            Console.ReadKey();

            MathOperation.DisplayMathResult((message1, message2) => { Console.WriteLine(message1 + message2); });
            //MathOperation.DisplayMathResult(MathOperation.ProcessMessage);
        }
    }
}
