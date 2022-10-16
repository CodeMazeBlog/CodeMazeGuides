using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpActionFuncApp
{
    public class ActionFuncDelegate
    {
        public static int result = 0;

        public Action<int, int> Addition;
        
        public Action<int, int> AdditionActionDelegateAnotherway;

        public Func<int, int, int> AdditionUsingFunc;
        public Func<int, int, int> AdditionUsingFunc2;

        public ActionFuncDelegate()
        {
            //way 1 to refer to a function using Action delegate.
            Addition = AddNumbers;
            //way 2 to refer to a function using Action delegate.
            AdditionActionDelegateAnotherway = new Action<int, int>(AddNumbers);
            // Way 1 to refer to a function using Func delegate.
            AdditionUsingFunc = GetSum;
            // Way 2 to refer to a function using Func delegate.
            AdditionUsingFunc2 = new Func<int, int, int>(GetSum);
        }

        public void AddNumbers(int param1, int param2)
        {
            result = param1 + param2;
        }

        int GetSum(int param1, int param2)
        {
            return param1 + param2;
        }
    }
}
