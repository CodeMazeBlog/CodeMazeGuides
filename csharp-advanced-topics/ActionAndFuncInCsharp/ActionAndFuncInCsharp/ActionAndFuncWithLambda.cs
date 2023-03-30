namespace ActionAndFuncInCsharp
{
    public static class ActionAndFuncWithLambda
    {
        // Func with Lambda expression

        public static Func<int, int, int> SubstractionResult = (a, b) => a - b;


        public static Func<int, bool> IsDecimalNumber = num => num > 10;

        // Func with Linq

        public static IEnumerable<int> GetDecimalNumbers()
        {
            int[] numbers = { 1, 4, 11, 2, 15, 7 };

            return numbers.Where(IsDecimalNumber);
        }

        // Action with Lambda expression

        public static Action action2 = () => Console.WriteLine("This is my first Action with Lambda");
    }
}
