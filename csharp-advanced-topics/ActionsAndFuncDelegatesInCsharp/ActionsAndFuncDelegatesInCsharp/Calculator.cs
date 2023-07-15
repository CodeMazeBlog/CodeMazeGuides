using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncDelegatesInCsharp
{
    public class Calculator
    {
        public Func<int, int, int>? Function { get; set; }
        public Action<int, string>? Action { get; set; }

        public int GetResult(int firstNumber, int secondNumber)
        {
            if (Function == null)
                throw new Exception("Function not set!");
            return Function(firstNumber, secondNumber);
        }

        public void DisplayResult(int firstNumber, int secondNumber)
        {
            if (Function == null)
                throw new Exception("Function not set!");
            if (Action == null)
                throw new Exception("Action not set!");

            var result = Function(firstNumber, secondNumber);
            Action(result, Function.Method.Name);
        }
    }
}
