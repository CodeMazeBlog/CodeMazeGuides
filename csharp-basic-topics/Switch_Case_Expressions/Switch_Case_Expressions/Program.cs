namespace multipleswitchcase
{

    public static class Program
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

        static void Main(string[] args)
        {            
            subMultipleCaseResults();
            subMultipleCaseWithExtension();
        }
      
        static void subMultipleCaseResults()
        {
            var switchTemp = 65;
            var Value = 100;
            var secondValue = 200;
            var resultstring = string.Empty;
            switch (switchTemp)
            {
                case 60:
                case 65:
                case 70:
                    resultstring = "It is a pleasant day.";
                    break;
                case 85:
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
                (xi >=60  && xi<= 65)||
                (xi <= 70 )=> "It is a pleasant day",
                85 => "It is hot today",
                95 => "It is very hot today",
                _ => "No weather report",
            };
            Console.WriteLine(resultValue);
        }

        static void subMultipleCaseWithExtension()
        {
            var tempValue = 70;
            var templist = new List<int> { 60, 65, 70 };
            var result = tempValue
            switch
            {
                var x when x.In(60, 65, 70) => "It is a pleasant day",
                80 => "It is hot today",
                95 => "It is very hot today",
                _ => "No weather report.",
            };
            Console.WriteLine($"{result} is with extension method");
            var newresult = tempValue
            switch
            {
                80 => "It is hot today",
                95 => "It is very hot today",
                _ when templist.Contains(tempValue) => "The weather is pleasant",
                _ => "No weather report",
            };
            Console.WriteLine($"{newresult} - result when using a list");


            var resultText = tempValue
            switch
            {
                60 or 65 or 70 => "Pleasant weather today",
                80 => "It is quite hot today",
                85 => "It is very hot today",
                >90 => "Heat wave condition",
                _ => "No weather report.    ",
            };
            Console.WriteLine($"{resultText} result is for C# 9.0 syntax");
        }
    }
}
