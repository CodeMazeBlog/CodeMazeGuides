namespace ActionAndFuncDelegatesInCSharp
{
    internal class Program
    {
        private static double _circumference;

        static void Main(string[] args)
        {
            var areaDelegate = new Func<int, int, double>(Area);

            var circumferenceDelegate = new Action<int>(Circumference);
            circumferenceDelegate.Invoke(2);
        }

        public static double Area(int b, int h)
        {
            return (b * h) / 2.0;
        }

        public static void Circumference(int r)
        {
            _circumference = 2 * 3.14 * r;
        }
    }
}