namespace multipleswitchcase
{

    public static class Program
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

        static void Main(string[] args)
        {            
            SubMultipleCaseResults();
            SubMultipleCaseWithExtension();
        }
      
        static void SubMultipleCaseResults()
        {
            var switchTemp = 20;
            var Value = 100;
            var secondValue = 200;
            var resultstring = string.Empty;
            switch (switchTemp)
            {
                case 20:
                case 22:
                case 24:
                    resultstring = "It is a pleasant day.";
                    break;
                case 30:
                    resultstring = "It is very hot today";
                    break;
                default:
                    resultstring = "No weather report today.";
                    break;
            }
            Console.WriteLine(resultstring);
            switch (Value)
            {
                case int n when (n >= Value && secondValue <= 200):
                    Console.WriteLine("The value is between 100 and 200");
                    break;
                case int n when (n >= Value && secondValue <= 300):
                    Console.WriteLine("The value is between 100 and 300");
                    break;
            }
            var resultValue = switchTemp
            switch
            {
                var xi when 
                (xi >= 20  && xi <= 22) || (xi <= 25 ) => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report",
            };
            Console.WriteLine(resultValue);
        }

        static void SubMultipleCaseWithExtension()
        {
            var tempValue = 22;
            var templist = new List<int> { 20, 22, 24 };
            var result = tempValue
            switch
            {
                var x when x.In(20, 22, 24) => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report.",
            };
            Console.WriteLine($"{result} is with extension method");
            var newresult = tempValue
            switch
            {
                30 => "It is hot today",
                35 => "It is very hot today",
                _ when templist.Contains(tempValue) => "The weather is pleasant",
                _ => "No weather report",
            };
            Console.WriteLine($"{newresult} - result when using a list");
            var resultText = tempValue
            switch
            {
                20 or 22 or 24 => "Pleasant weather today",
                30 => "It is quite hot today",
                35 => "It is very hot today",
                > 35 => "Heat wave condition",
                _ => "No weather report.    ",
            };
            Console.WriteLine($"{resultText} result is for C# 9.0 syntax");
        }
    }
}
