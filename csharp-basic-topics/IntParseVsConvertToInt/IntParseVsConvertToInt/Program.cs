
namespace IntParseVsConvertToInt
{
    public class Program
    {
        public static void IntParseMethod(string inputString)
        {
            try
            {
                int outputInteger = int.Parse(inputString);
                Console.WriteLine(outputInteger);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error");
            }
        }

        public static void ConvertToInt32Method(string inputString)
        {
            int outputInteger = Convert.ToInt32(inputString);
            Console.WriteLine(outputInteger);
        }

        public static void IntTryParseMethod(string inputString)
        {
            int outputInteger;
            bool success = int.TryParse(inputString, out outputInteger);
            if (success)
            {
                Console.WriteLine("Conversion successful.Converted value: " + outputInteger);
            }
            else
            {
                Console.WriteLine("Conversion failed.");
            }

        }

        public static void Main(string[] args)
        {
            string inputString = " 123 ";
            string? inputNullString = null;

            IntParseMethod(inputString);
            IntParseMethod(inputNullString);
            
            Console.WriteLine();
            
            ConvertToInt32Method(inputString);
            ConvertToInt32Method(inputNullString);
            
            Console.WriteLine();
            
            IntTryParseMethod(inputString);
            IntTryParseMethod(inputNullString);

        }
    }
}