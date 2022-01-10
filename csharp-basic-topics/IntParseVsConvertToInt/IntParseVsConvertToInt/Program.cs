
namespace IntParseVsConvertToInt
{
    public class Program
    {
        public static void IntParseMethod(string inputString)
        {
            try
            {
                var outputInteger = int.Parse(inputString);
                Console.WriteLine(outputInteger);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("The int.Parse() method throws ArgumentNullException.");
            }
        }

        public static void ConvertToInt32Method(string inputString)
        {
            var outputInteger = Convert.ToInt32(inputString);
            Console.WriteLine(outputInteger);
        }

        public static void IntTryParseMethod(string inputString)
        {
            if (int.TryParse(inputString, out var outputInteger))
                Console.WriteLine($"Output value: {outputInteger}");
            else
                Console.WriteLine("The conversion failed.");
        }

        public static void Main(string[] args)
        {
            var inputString = " 123 ";
            string inputNullString = null;

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