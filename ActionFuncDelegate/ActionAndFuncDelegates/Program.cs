namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = 15;
            var num2 = 10;

            var delegates = new ActionAndFucntionDelegate();
            var results = delegates.RunDelegate(num1, num2);

            Console.WriteLine($"Result of add: {results.AddResult}");
            Console.WriteLine($"Incremented number: {results.IncrementedNumber}");
        }
    }
}