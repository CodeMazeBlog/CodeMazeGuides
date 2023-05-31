namespace DelegateBasicsWithFuncAndAction
{
    using static Program;
    public class DelegateWithParameter
    {
        // Passing Method Reference in ExecuteDelegate Method
        public static void ExecuteDelegate(PrivateMethodWithParameterDelegate method)
        {
            // Calling Print Method using delegate
            method("Calling Private Method!!!");
        }
    }
}
