
namespace ActionAndFuncDelegates
{
    public static class Sample
    {
        // This is a target for the Action<> delegate.
        public static void MultiplePrint(string msg, int lineCount)
        {
            for (int i = 0; i < lineCount; i++)
            {
                Console.WriteLine(msg);
            }
        }

        // Target for the Func<> delegate.
        public static int Sum(int x, int y)
        {
            return x + y;
        }

        public static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}
