namespace SwitchCaseExpression
{
    public static class Program
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

        static void Main(string[] args)
        {
            SubMultipleCaseResults(22);
            SubMultipleCaseResultsWithWhen(100);
            SubMultipleCaseWithExtension(22);
            SubMultipleCaseWithListValues(22);
            SubMultipleCaseWithNewVersion(22);
        }

        public static void SubMultipleCaseResults(int switchTemp)
        {
            var resultstring = string.Empty;

            switch (switchTemp)
            {
                case 20:
                case 22:
                case 24:
                    resultstring = "It is a pleasant day";
                    break;
                case 30:
                    resultstring = "It is very hot today";
                    break;
                default:
                    resultstring = "No weather report today";
                    break;
            }

            Console.WriteLine(resultstring);
        }

        public static void SubMultipleCaseResultsWithWhen(int value)
        {
            switch (value)
            {
                case int n when (n >= 50 && n <= 150):
                    Console.WriteLine("The value is between 50 and 150");
                    break;
                case int n when (n >= 150 && n <= 200):
                    Console.WriteLine("The value is between 150 and 200");
                    break;
                default:
                    Console.WriteLine("The number is not within the given range.");
                    break;
            }
        }
        public static void SubMultipleCaseWithExtension(int tempValue)
        {
            var result = tempValue switch
            {
                var x when x.In(20, 22, 24) => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report.",
            };

            Console.WriteLine($"{result} - with extension method");
        }

        public static void SubMultipleCaseWithListValues(int tempValue)
        {
            var templist = new List<int> { 20, 22, 24 };

            var newresult = tempValue switch
            {
                var x when templist.Contains(x) => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report",
            };

            Console.WriteLine($"{newresult} - result when using a list");
        }

        public static void SubMultipleCaseWithNewVersion(int tempValue)
        {
            var resultText = tempValue switch
            {
                20 or 22 or 24 => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                > 35 => "Heat wave condition",
                _ => "No weather report.",
            };

            Console.WriteLine($"{resultText} - result is for C# 9.0 syntax");
        }
    }
}
