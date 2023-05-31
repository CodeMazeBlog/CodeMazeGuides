namespace DelegateBasicsWithFuncAndAction
{
    using System.Diagnostics.CodeAnalysis;
    using static Program;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        // Declaration of Delegate
        public delegate void PrivateMethodDelegate();
        public delegate void PrivateMethodWithParameterDelegate(string message);
        public static void Main(string[] args)
        {
            // Instantiation of Delegate

            // Declare Delegate for method without parameter
            PrivateMethodDelegate privateMethod = Print;

            // Declare Delegate for method without parameter
            PrivateMethodWithParameterDelegate privateMethodWithParameter = PrintWithParameter;


            //Invocations of delegates
            // Passing Reference of method 
            DelegateWithoutParameter.ExecuteDelegate(privateMethod);
            DelegateWithParameter.ExecuteDelegate(privateMethodWithParameter);

            // Invoke Func Method delegate
            FuncDelegate.FuncMethod();

            //Invoke Action Method delegate
            ActionDelegate.ActionMethod();

            Console.ReadLine();
        }

        private static void Print()
        {
            Console.WriteLine("Calling Private Method!!!");
        }

        private static void PrintWithParameter(string msg)
        {
            Console.WriteLine($"{msg}");
        }
    }

}