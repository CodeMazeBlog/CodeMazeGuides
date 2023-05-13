namespace ActionFuncDelegates
{
    public class Program
    {
        public delegate string FormatString(string s);

        public readonly FormatString Format = s => s.Trim();

        public static string DoSomething(FormatString format)
        {
            var s = "a string";

            return format(s);
        }

        static void Main()
        {
            // Action delegate
            var doSomething = () => Console.WriteLine("action");
            doSomething();

            Action<string> print = Console.WriteLine;
            print("hello world");

            Action<int, int> printSum = (x, y) => Console.WriteLine(x + y);
            printSum(3, 4);

            // Func delegate
            Func<string> getString = () => "hardcoded string";
            var s = getString();

            Func<int, int, int> sum = (x, y) => x + y;
            var result = sum(5, 6);

            Func<int, bool> isOdd = x => x % 2 == 0;
            var numbers = new[] { 1, 2, 3 };
            var oddNumbers = numbers.Where(isOdd);
        }
    }
}
