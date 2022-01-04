namespace multipleswitchcase
{

    public static class Program
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);
        static void Main(string[] args)
        {
            //working of a switch case statement
            int x = 30;
            switch (x)
            {
                case 10:
                    Console.WriteLine("The value of x is 10");
                    break;
                case 20:
                    Console.WriteLine("The value of x is 20");
                    break;
                case 30:
                    Console.WriteLine("The value of x is 30");
                    break;
                default:
                    Console.WriteLine("Value is not known.");
                    break;
            }
            Console.ReadLine();
            //switch case relational and constant pattern example
            subSwitchCasePatterns();

            //Multiple switch cases with the same result.
            subMultipleCaseResults();

            //Multiple switch cases using extension method
            subMultipleCaseWithExtension();

        }
        static void subSwitchCasePatterns()
        {
            int x = 125;
            string mystring = "Rose";

            switch (x % 2)
            {
                case 0:
                    Console.WriteLine($"{x} is an even value");
                    break;
                case 1:
                    Console.WriteLine($"{x} is an odd value");
                    break;
            }
            //using string statements
            switch (mystring)
            {
                case "Jasmine":
                    Console.WriteLine("The flower is Jamine");
                    break;
                case "Rose":
                    Console.WriteLine("The flower is Rose");
                    break;
                case "Hibiscus":
                    Console.WriteLine("The flower is Hibiscus");
                    break;
                default:
                    Console.WriteLine("No flower selected");
                    break;
            }
        }
        static void subMultipleCaseResults()
        {
            var switchValue = 2;
            var Value = 5;
            var resultstring = string.Empty;
            switch (switchValue)
            {
                case 1:
                case 2:
                case 3:
                    resultstring = "one to three";
                    break;
                case 4:
                    resultstring = "four";
                    break;
                default:
                    resultstring = "The result is unknown.";
                    break;
            }
            Console.WriteLine(resultstring);


            // use of when keyword in switch case
            switch (Value)
            {
                case int n when (n >= 1 && n <= 3):
                    Console.WriteLine("The value is between 1 and 3");
                    break;
                case int n when (n >= 4 && n <= 6):
                    Console.WriteLine("The value is between 4 and 6");
                    break;
            }
            // different format for the switch case.
            var resultValue = Value
            switch
            {
                var xi
                when xi == 1 ||
                xi == 2 ||
                xi == 3 => "One to Three",
                4 => "Four",
                5 => "Five",
                _ => "unknown",
            };
            Console.WriteLine(resultValue);

        }

        static void subMultipleCaseWithExtension()
        {

            var swValue = 3;
            var result = swValue
            switch
            {
                var x when x.In(1, 2, 3) => "One to Three",
                4 => "Four",
                5 => "Five",
                _ => "unknown",
            };
            Console.WriteLine($"{result} is with extension method");

            var newresult = swValue
            switch
            {
                1 or 2 or 3 => "One to Three",
                4 => "Four",
                5 => "Five",
                _ => "Unknown",
            };
            Console.WriteLine($"{newresult} result is for C# 9.0 syntax");
        }
        
           
    }
}