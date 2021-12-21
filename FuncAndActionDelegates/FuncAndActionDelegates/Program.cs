namespace FuncAndActionDelegate
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Func Delegate
            FuncDelegate func = new FuncDelegate();
            double funcResult = func.SimpleFuncDelegate();

            // Func Delegate with Anonymous Method
            int funcResultwithAnonymousMethod = func.FuncDelegateWithAnonymousMethods();

            // Func Delegate with Lambda Expression
            double funcResultwithLambda = func.FuncDelegateWithLambda();

            //Action Delegate
            ActionDelegate action = new ActionDelegate();
            action.SimpleActionDelegate();

            // Action Delegate with Anonymous Method
            action.ActionDelegateWithAnonymousMethods();

            // Action Delegate with Lambda Expression
            action.ActionDelegateWithLambda();
        }
    }
}
