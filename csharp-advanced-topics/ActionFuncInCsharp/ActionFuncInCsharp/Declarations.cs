using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncInCsharp
{
    public class Declarations
    {
        //traditional delegate way for void method
        public delegate void PrintMultiplicationDelegate(int a, int b);
        public PrintMultiplicationDelegate printMultiplicationDelegateRefer;

        //Action delegate way
        public Action<int, int> printMultiplicationActionDelegateRefer;

        //traditional delegate way for return value method
        public delegate int ReturnMultiplicationDelegate(int a, int b);
        public ReturnMultiplicationDelegate returnMultiplicationDelegateRefer;

        //Func delegate way
        public Func<int, int, int> returnMultiplicationFuncDelegateRefer;

        public Declarations()
        {
            printMultiplicationDelegateRefer = PrintMultiplication;
            printMultiplicationActionDelegateRefer = PrintMultiplication;

            returnMultiplicationDelegateRefer = ReturnMultiplication;
            returnMultiplicationFuncDelegateRefer = ReturnMultiplication;
        }


        private void PrintMultiplication(int a, int b) => Console.WriteLine(a * b);
        private int ReturnMultiplication(int a, int b) => a * b;
    }
}
