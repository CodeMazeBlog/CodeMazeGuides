namespace ActionAndFuncDelegates
{
    public delegate void SimpleDelegate();
    public delegate string SimpleDelegateWithStringReturnType();
    public delegate string SimpleDelegateWithStringReturnTypeAndParameter(string name);

    public class Delegates
    {
        public static void Driver()
        {
            SimpleDelegate firstDelegate = MethodWithVoidReturnTypeAndNoParameter;
            SimpleDelegateWithStringReturnType secondDelegate = MethodWithStringReturnTypeAndNoParameter;
            SimpleDelegateWithStringReturnTypeAndParameter thirdDelegate = MethodWithStringReturnTypeAndStringParameter;

            firstDelegate();
            var secondDelegateReturns = secondDelegate();
            var thirdDelegateReturns = thirdDelegate("code-maze");

            Console.WriteLine(secondDelegateReturns);
            Console.WriteLine(thirdDelegateReturns);
        }

        private static void MethodWithVoidReturnTypeAndNoParameter()
        {
            Console.WriteLine($"Simple Called");
        }

        private static string MethodWithStringReturnTypeAndNoParameter()
        {
            return $"Delegate with string return type";
        }

        private static string MethodWithStringReturnTypeAndStringParameter(string name)
        {
            return $"Delegate with string return type and parameter {name}";
        }
    }
}
