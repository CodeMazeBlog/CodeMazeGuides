
namespace IntParseVsConvertToInt
{
    public class Program
    {
        public static void IntParseMethod(string s)
        {
            try
            {
                int i = int.Parse(s);
                Console.WriteLine(i);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error");
            }
        }

        public static void ConvertToInt32Method(string s)
        {
            int i = Convert.ToInt32(s);
            Console.WriteLine(i);
        }

        public static void IntTryParseMethod(string s)
        {
            int i;
            bool success = int.TryParse(s, out i);
            if (success)
            {
                Console.WriteLine("Conversion successful.Converted value: " + i);
            }
            else
            {
                Console.WriteLine("Conversion failed.");
            }

        }

        public static void Main(string[] args)
        {
            string str = " 123 ";
            string? strNull = null;
            IntParseMethod(str);
            IntParseMethod(strNull);
            ConvertToInt32Method(str);
            ConvertToInt32Method(strNull);
            IntTryParseMethod(str);
            IntTryParseMethod(strNull);

        }
    }
}