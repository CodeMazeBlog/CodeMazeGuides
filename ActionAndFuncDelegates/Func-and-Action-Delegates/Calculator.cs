using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_and_Action_Delegates
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class CalculatorWrapper
    {
        private readonly Func<int, int, int> _addFunc;

        public CalculatorWrapper(Func<int, int, int> addFunc)
        {
            _addFunc = addFunc;
        }

        public int Add(int a, int b)
        {
            return _addFunc(a, b);
        }
    }
}
