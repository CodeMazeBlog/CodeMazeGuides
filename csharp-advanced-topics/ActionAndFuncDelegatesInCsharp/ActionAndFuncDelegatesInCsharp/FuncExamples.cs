namespace ActionAndFuncDelegatesInCsharp
{
    public class FuncExamples
    {
        public static void FuncWithAnonymouseMethod()
        {
            Func<string, string> hello = delegate (string name)
            {
                return $"Hello {name}";
            };
            Console.WriteLine(hello("David"));
        }

        public static void FuncWithExpressionLambda()
        {
            Func<int, int, int> sum = (int x, int y) => x + y;
            Console.WriteLine(sum(5, 10));
        }

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
