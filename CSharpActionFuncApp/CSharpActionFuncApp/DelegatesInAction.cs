namespace CSharpActionFuncApp
{
    public class DelegatesInAction
    {
        private readonly ActionFuncDelegate _objActionFuncDelegate;

        public DelegatesInAction()
        {
            _objActionFuncDelegate = new ActionFuncDelegate();
        }

        // Action delegate calls
        public int ActionDelegateInAction(int num1, int num2)
        {
            _objActionFuncDelegate._Addition(num1, num2);
            return _objActionFuncDelegate.result;
        }

        public int ActionDelegateInActionUsingAnotherWay(int num1, int num2)
        {
            _objActionFuncDelegate._AdditionActionDelegateAnotherway(num1, num2);
            return _objActionFuncDelegate.result;
        }

        //Func delegate calls
        public int FuncDelegateInAction(int num1, int num2)
        {
            return _objActionFuncDelegate._AdditionUsingFunc(num1, num2);
        }

        public int FuncDelegateInActionUsingAnotherWay(int num1, int num2)
        {
            return _objActionFuncDelegate._AdditionUsingFunc2(num1, num2);
        }
    }
}