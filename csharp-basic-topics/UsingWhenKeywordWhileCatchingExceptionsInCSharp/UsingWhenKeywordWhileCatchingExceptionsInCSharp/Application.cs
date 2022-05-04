using System.Globalization;

namespace UsingWhenKeywordWhileCatchingExceptionsInCSharp
{
    public class Application
    {
        public static void Interface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome!\n\n ");

            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPlease enter your 8-digit special number\n");
                ConvertToInt(Console.ReadLine()!);

                Console.WriteLine("Would you like to part of a lottery? True or False\n");
                ConvertToBool(Console.ReadLine()!);

                Console.WriteLine("Please enter date of birth (Format => Friday, April 10, 2009)");
                ConvertToDateTime(Console.ReadLine()!);

                Console.WriteLine("Please enter your guid password");
                ConvertToGuid(Console.ReadLine()!);
            }

            catch (FormatException F) when (F.Message.Contains("Input string was not in a correct format"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(F.Message);
                Console.Write("\nSpecial number error");
                Console.ForegroundColor = ConsoleColor.White;
                throw;

            }
            catch (FormatException F) when (F.Message.Contains("not recognized as a valid Boolean"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(F.Message);
                Console.Write("\nLottery participant error");
                Console.ForegroundColor = ConsoleColor.White;
                throw;

            }
            catch (FormatException F) when (F.Message.Contains("not recognized as a valid DateTime"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(F.Message);
                Console.Write("\nDate of birth error");
                Console.ForegroundColor = ConsoleColor.White;
                throw;

            }
            catch (FormatException F) when (F.Message.Contains("Format string can be only"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(F.Message);
                Console.Write("\nGuid error");
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
            catch
            {
                throw;
            }
        }

        public static int ConvertToInt(string num)
        {
            int specialNum = Convert.ToInt32(num);
            return specialNum;
        }
        public static Guid ConvertToGuid(string num)
        {
            return Guid.Parse(num.Trim());
        }
        public static DateTime ConvertToDateTime(string num)
        {
            var cultureInfo = new CultureInfo("en-US");
            return DateTime.ParseExact(num.Trim()!, "D", cultureInfo);
        }
        public static bool ConvertToBool(string num)
        {
            return Boolean.Parse(num);
        }
    }

}
