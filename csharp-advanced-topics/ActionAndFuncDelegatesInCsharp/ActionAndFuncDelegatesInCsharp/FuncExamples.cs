namespace ActionAndFuncDelegatesInCsharp
{
    public class FuncExamples
    {
        /// <summary>
        ///  Example 1: Using Anonymous methods
        /// </summary>
        public static void FuncWithAnonymouseMethod()
        {
            Func<string, string> hello = delegate (string name)
            {
                return $"Hello {name}";
            };
            Console.WriteLine(hello("David"));
        }

        /// <summary>
        /// Example 2: Using Lambda expressions (Expression lambdas):
        /// </summary>
        public static void FuncWithExpressionLambda()
        {
            Func<int, int, int> sum = (int x, int y) => x + y;
            Console.WriteLine(sum(5, 10));
        }


        /// <summary>
        /// Example 3: Using Lambda expressions (Statement lambdas):
        /// </summary>
        public static void FuncWithStatementLambda()
        {
            Func<int, int, int> add = (int x, int y) =>
            {
                return x + y;
            };
            Console.WriteLine(add(10, 20));
        }
    }
}
