using System;
using System.Linq;

namespace ConvertStringToBoolean
{
    public class Program
    {
        public static void Main()
        {
            ToBooleanMethod();

            ParseMethod();

            TryParseMethod();
        }

        public static void ToBooleanMethod()
        {

            String[] validString = { null, "true", "True", "    true   ", "false", "False", "    false" };

            String[] invalidString = { "", String.Empty, "t", "    yes   ", "-1", "0", "1" };


            var values = validString.Concat(invalidString);

            foreach (var value in values)
            {
                try
                {
                    Console.WriteLine($"Converted '{value}' to {Convert.ToBoolean(value)}.\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to convert '{value}' to a Boolean.\n");
                }
            }

        }

        public static void ParseMethod()
        {

            String[] validString = { "true", "True", "    true   ", "false", "False", "    false" };

            String[] invalidString = {null, "", String.Empty, "t", "    yes   ", "-1", "0", "1" };

            var values = validString.Concat(invalidString);


            foreach (var value in values)
            {
                try
                {
                    Console.WriteLine($"Converted '{value}' to {bool.Parse(value)}.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Unable to convert '{value}' to a Boolean.\n");
                }
            }

        }


        public static void TryParseMethod()
        {
            String[] validString = { "true", "True", "    true   ", "false", "False", "    false" };

            String[] invalidString = { null, "", String.Empty, "t", "    yes   ", "-1", "0", "1" };

            var values = validString.Concat(invalidString);

            foreach (var value in values)
            {
                bool booleanValue;

                if (bool.TryParse(value, out booleanValue))
                {
                    Console.WriteLine($"Conversion successful: '{value}' to {booleanValue}.\n");
                }
                else
                {
                    Console.WriteLine($"Conversion Failed: '{value}' to {booleanValue}.\n");
                }

            }

        }
    }

}
