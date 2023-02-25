namespace ActionAndFuncDelegates
{
    public class DisplayResults
    {
        public static void Top(List<int> results)
        {
            Console.WriteLine(results.Max());
        }

        public static void Bottom(List<int> results)
        {
            Console.WriteLine(results.Min());
        }
    }
}
