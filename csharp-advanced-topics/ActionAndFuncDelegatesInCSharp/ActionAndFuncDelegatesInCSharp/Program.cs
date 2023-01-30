namespace ActionAndFuncDelegatesInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var areaDelegate = new Func<int, int, double>(Area);
            Console.WriteLine(areaDelegate.Invoke(3, 7));

            var displayDelegate = new Action<string>(Display);
            displayDelegate("Hello, World!");
        }

        public static double Area(int b, int h)
        {
            return (b * h) / 2.0;
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}