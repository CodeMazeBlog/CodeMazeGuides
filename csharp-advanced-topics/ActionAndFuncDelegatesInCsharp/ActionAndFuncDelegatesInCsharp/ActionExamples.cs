namespace ActionAndFuncDelegatesInCsharp
{
    public class ActionExamples
    {
        public static void ActionWithAnonymouseMethod()
        {
           
            Action<string> hello = delegate (string name)
            {
                Console.WriteLine($"Hello {name}");
            };
            hello("David");
        }

        public static void ActionWithExpressionLambda()
        {
            Action<int, int> sum = (int x, int y) => Console.WriteLine(x + y);
            sum(3, 4);
        }

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
