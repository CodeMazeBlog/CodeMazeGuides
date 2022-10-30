namespace CSharpActionFuncApp
{
    public class ActionFuncDelegate
    {
        public int result;

        public readonly Action<int, int> _Addition;

        public readonly Action<int, int> _AdditionActionDelegateAnotherway;

        public readonly Func<int, int, int> _AdditionUsingFunc;
        public readonly Func<int, int, int> _AdditionUsingFunc2;

        public ActionFuncDelegate()
        {
            //way 1 to refer to a function using Action delegate.
            _Addition = AddNumbers;
            //way 2 to refer to a function using Action delegate.
            _AdditionActionDelegateAnotherway = new Action<int, int>(AddNumbers);
            // Way 1 to refer to a function using Func delegate.
            _AdditionUsingFunc = GetSum;
            // Way 2 to refer to a function using Func delegate.
            _AdditionUsingFunc2 = new Func<int, int, int>(GetSum);
        }

        private void AddNumbers(int param1, int param2)
        {
            result = param1 + param2;
        }

        private int GetSum(int param1, int param2)
        {
            return param1 + param2;
        }
    }
}
