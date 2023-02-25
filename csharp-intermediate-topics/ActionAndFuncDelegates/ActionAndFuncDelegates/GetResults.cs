namespace ActionAndFuncDelegates
{
    public class GetResults
    {
        public static int Top(List<int> results)
        {
            return results.Max();
        }

        public static int Bottom(List<int> results)
        {
            return results.Min();
        }
    }
}
