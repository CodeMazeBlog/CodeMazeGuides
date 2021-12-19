using System;

namespace DelegatesInCSharp
{
    public class MathOperation
    {
        public string Message { get; private set; }
        public int PerformMathsOperation(Func<int, int, int> singleOperationFunc)
        {
            int input1 = 1;
            int input2 = 2;

            return singleOperationFunc(input1, input2);
        }

        public void DisplayMathResult(Action<string, string> CreateMessage)
        {
            string message1 = "message one";
            string message2 = "message two";
            CreateMessage(message1, message2);
        }

        public void ProcessSingleIntMessage(int intValue)
        {
            Message = "My Value is:" + intValue.ToString();
        }

        public void ProcessMessage(string message1, string message2)
        {
            Message = message1 + message2;
            Console.WriteLine(Message);
        }

        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        public int ProcessSingleDigit(int input)
        {
            //DO Something;
            return input;
        }
    }
}
