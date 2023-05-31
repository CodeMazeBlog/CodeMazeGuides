namespace DelegateBasicsWithFuncAndAction
{
    using static Program;
    public class DelegateWithoutParameter
    {
        // Passing Method Reference in ExecuteDelegate Method
        public static void ExecuteDelegate(PrivateMethodDelegate method)
        {
            // Calling Print Method using delegate
            method();
        }
    }
}
