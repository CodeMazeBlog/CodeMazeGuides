namespace ActionFuncDelegates
{
    public class Program
    {
        public delegate string FormatString(string s);

        public readonly FormatString Format = s => s.Trim();

        public static string DoSomething(FormatString format)
        {
            string s = "a string";
            return format(s);
        }

        private static void Main(string[] args)
        {
            // Action delegate
            Action doSomething = () => Console.WriteLine("action");
            doSomething();

            Action<string> print = Console.WriteLine;
            print("hello world");

            static void printSum(int x, int y) => Console.WriteLine(x + y);
            printSum(3, 4);

            // Func delegate
            static string getString() => "hardcoded string";
            string s = getString();

            static int sum(int x, int y) => x + y;
            int result = sum(5, 6);

            static bool isOdd(int x) => x % 2 == 0;
            int[] numbers = new[] { 1, 2, 3 };
            IEnumerable<int> oddNumbers = numbers.Where(isOdd);
        }
    }
}
