namespace ActionAndFuncDelegatesDemo
{
    public static class Program
    {
        public static void PrintToConsoleWithoutParameter()
        {
            Console.WriteLine("Hello, World!");
        }

        public static void PrintToConsoleWithParameter(string textToPrint)
        {
            Console.WriteLine(textToPrint);
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static void Main(string[] args)
        {
            #region Action demo

            Action printDelegate = PrintToConsoleWithoutParameter;
            printDelegate();

            Action<string> printDelegateWithParameter = PrintToConsoleWithParameter;
            printDelegateWithParameter("Here I can use whatever string value I want as a parameter");

            Action<string> printDelegateWithParameterDeclaredWithLambda = x => Console.WriteLine(x);
            printDelegateWithParameterDeclaredWithLambda("Here I also can use whatever string value I want as a parameter of the lambda expression");

            #endregion Action demo

            #region Func demo

            Func<int, int, int> addDelegate = Add;
            int result = addDelegate(1, 2);
            Console.WriteLine($"Add delegate returned: {result}");

            Func<int, int, int> addDelegateDeclaredWithLambda = (x, y) => x + y;
            result = addDelegateDeclaredWithLambda(10, 10);
            Console.WriteLine($"Add delegate returned: {result}");

            #endregion Func demo
        }
    }
}