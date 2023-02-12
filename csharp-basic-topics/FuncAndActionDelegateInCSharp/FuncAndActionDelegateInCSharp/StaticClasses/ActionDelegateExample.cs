namespace FuncAndActionDelegateInCSharp.StaticClasses
{
    public static class ActionDelegateExample
    {
        public static void Print(int x, int y)
        {
            Display codeMaze1 = PrintSum;
            Display codeMaze2 = new(PrintMultiply);
            codeMaze1.Invoke(x, y);
            codeMaze2(x, y);
        }

        private static void PrintSum(int x, int y)
        {
            Console.WriteLine($"Action Delegate Sum Result: {x + y}");
        }

        private static void PrintMultiply(int x, int y)
        {
            Console.WriteLine($"Action Delegate Multiply Result:{x * y}");
        }

        private delegate void Display(int x, int y);
    }
}
