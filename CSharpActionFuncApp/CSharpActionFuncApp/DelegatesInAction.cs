using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpActionFuncApp
{
    public class DelegatesInAction
    {
        ActionFuncDelegate objActionFuncDelegate;

        public DelegatesInAction()
        {
            objActionFuncDelegate = new ActionFuncDelegate();
        }

        // Action delegate calls
        public void ActionDelegateInAction()
        {
            objActionFuncDelegate.Addition(10, 10);
            Console.WriteLine($"Addition = {ActionFuncDelegate.result}");

            objActionFuncDelegate.AdditionActionDelegateAnotherway(10, 20);
            Console.WriteLine($"Addition using ActionDelegateAnotherway = {ActionFuncDelegate.result}");
        }
        //Func delegate calls
        public void FuncDelegateInAction()
        {
            int sum = objActionFuncDelegate.AdditionUsingFunc(10, 30);
            Console.WriteLine($"Sum using AdditionUsingFunc = {sum}");

            sum = objActionFuncDelegate.AdditionUsingFunc2(10, 40);
            Console.WriteLine($"Sum using AdditionUsingFunc2 = {sum}");
        }


    }
}