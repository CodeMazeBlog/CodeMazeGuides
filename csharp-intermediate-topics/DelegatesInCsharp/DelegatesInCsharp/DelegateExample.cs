namespace DelegatesInCsharp
{
    public static class DelegateExample
    {
        private const double HRA_Percentage = 0.4;
        public const string TEXT_IN_LOWER_CASE = "programming delegates in csharp";
        public const string TEXT_IN_UPPER_CASE = "PROGRAMMING DELEGATES IN CSHARP";

        public static double GetHra(double basic) => (double)(basic * HRA_Percentage);

        private static string ConvertToLower(string str) => str.ToLower();

        private static Func<double, double> func = new Func<double, double>(GetHra);

        internal delegate string MyDelegate(string str);

        public static string GetTextInLowercase(string str = TEXT_IN_UPPER_CASE)
        {
            var myDelegate = new MyDelegate(ConvertToLower);
            return myDelegate(TEXT_IN_UPPER_CASE);
        }
    }
}