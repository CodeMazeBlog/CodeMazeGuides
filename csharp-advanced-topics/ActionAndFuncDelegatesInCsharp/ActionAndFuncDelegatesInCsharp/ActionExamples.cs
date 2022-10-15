namespace ActionAndFuncDelegatesInCsharp
{
    public class ActionExamples
    {
        /// <summary>
        ///  Example 1: Using Anonymous methods
        /// </summary>
        public static void ActionWithAnonymouseMethod()
        {
           
            Action<string> hello = delegate (string name)
            {
                Console.WriteLine($"Hello {name}");
            };
            hello("David");
        }

        /// <summary>
        /// Example 2: Using Lambda expressions (Expression lambdas):
        /// </summary>
        public static void ActionWithExpressionLambda()
        {
            Action<int, int> sum = (int x, int y) => Console.WriteLine(x + y);
            sum(3, 4);
        }


        /// <summary>
        /// Example 3: Using Lambda expressions (Statement lambdas):
        /// </summary>
        public static void ActionWithStatementLambda()
        {
            Action<int, int> add = (int x, int y) =>
            {
                Console.WriteLine(x + y);
            };
            add(10, 20);
        }
    }
}
