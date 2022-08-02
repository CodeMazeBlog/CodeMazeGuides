using System.Globalization;

namespace UsingWhenInExceptionHandlingInCsharp
{
    public class Application
    {
        public static void Interface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome!{Environment.NewLine}{Environment.NewLine} ");

            try
            {                
                Console.WriteLine($"{Environment.NewLine}Please enter your special number{Environment.NewLine}");
                ConvertToInt(Console.ReadLine()!);

                Console.WriteLine($"Would you like to part of a lottery? True or False{Environment.NewLine}");
                ConvertToBool(Console.ReadLine()!);

                Console.WriteLine("Please enter date of birth (Format => Friday, April 10, 2009)");
                ConvertToDateTime(Console.ReadLine()!);

                Console.WriteLine("Please enter your guid password");
                ConvertToGuid(Console.ReadLine()!);
            }
            catch (FormatException ex) when (ex.Message.Contains("Input string was not in a correct format"))
            {                
                Console.WriteLine(ex.Message);
                Console.Write("Special number error");
                throw;
            }
            catch (FormatException ex) when (ex.Message.Contains("not recognized as a valid Boolean"))
            {
                
                Console.WriteLine(ex.Message);
                Console.Write("Lottery participant error");
                throw;
            }
            catch (FormatException ex) when (ex.Message.Contains("not recognized as a valid DateTime"))
            {                
                Console.WriteLine(ex.Message);
                Console.Write("Date of birth error");                
                throw;
            }
            catch (FormatException ex) when (ex.Message.Contains("Format string can be only"))
            {
                
                Console.WriteLine(ex.Message);
                Console.Write("Guid error");                
                throw;
            }
            catch
            {
                throw;
            }
        }

        public static void InterfaceTwo()
        {
            try 
            { 
                Console.WriteLine($"{Environment.NewLine}Please enter your 8-digit special number");
                ConvertToInt(Console.ReadLine()!); 
                
                Console.WriteLine($"Would you like to part of a lottery? True or False{Environment.NewLine}"); 
                ConvertToBool(Console.ReadLine()!);
            } 
            catch (FormatException ex) when (ex.Message.Contains("correct format") || ex.Message.Contains("valid Boolean")) 
            {
                Console.WriteLine(ex.Message); 
                Console.Write("Error!!"); 
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
            return bool.Parse(num);
        }
    }
}