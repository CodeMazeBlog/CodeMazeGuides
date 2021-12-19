using System;
using System.Collections.Generic;
using System.Text;

namespace FuncAndActionDelegate
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Func Delegate
            FuncDelegate func = new FuncDelegate();
            float funcResult = func.SimpleFuncDelegate();

            // Func Delegate with Lambda Expression
            float funcResultwithLambda = func.FuncDelegateWithLambda();

            //ActionDelegate
            ActionDelegate action = new ActionDelegate();
            action.SimpleActionDelegate();

            // Func Delegate with Lambda Expression
            action.ActionDelegateWithLambda();
        }
    }
}
