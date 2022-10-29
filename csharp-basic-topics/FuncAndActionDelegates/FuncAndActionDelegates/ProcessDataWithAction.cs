using System;
namespace FuncAndActionDelegates
{
    public class ProcessDataWithAction
    {
        void Process()
        {
            //Simplest declaration
            Action simpleAction;

            //1 parameter
            Action<int> actionWith1Param;

            //2 parameters
            Action<int, int> actionWith2Params;

            Action<int, int> doSomethingWithBothParams = CalculateSum;
            //var doSomethingWithBothParams = CalculateSum;

            Action doSomethingAction;
            doSomethingAction = doSomethingMethod;
            doSomethingAction();

            doSomethingAction?.Invoke();
        }

        void GetData(Action<int, int> addUpNumbers)
        {
            addUpNumbers(1, 2);
        }

        void doSomethingMethod()
        {
            //Do something
        }

        void CalculateSum(int val1, int val2)
        {
            var sum = val1 + val2;
        }
    }
}

