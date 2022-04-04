using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionDelegatesInCsharp.ConsoleApp
{    
    public class FuncDelegatesParameters
    {
        private static int Add() => 1 + 4;

        public int CallAcceptFunc()
        {
            return AcceptFunc(Add);
        }

        private int AcceptFunc(Func<int> operation)
        {
            int result = operation();
            return result;
        }

        private int AddWithParameters(int x, int y) => x + y;

        public int CallAcceptFuncWithParameters() =>
            AcceptFuncWithParameters(AddWithParameters);

        public int CallAcceptFuncWithParametersLambda() =>
            AcceptFuncWithParameters((a, b) => a + b);

        public int AcceptFuncWithParameters(Func<int, int, int> operation)
        {
            int result = operation(2, 5);
            return result;
        }

    }
}
