using System;
using System.Collections.Generic;
using System.Globalization;

namespace ParseAndTryParseInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Parse(String)
            Console.WriteLine("---> Output for Parse(String)");
            string[] values = { "123", "+7654", " 3457 ", "$978", "2147483667678", null };

            foreach (string value in values)
            {
                IntParse(value);
            }

            //Parse(String, IFormatProvider)
            Console.WriteLine("---> Output for Parse(String, IFormatProvider)");
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.PositiveSign = "#";
            string num = "#1234";
            IntParse(num, culture); // 1234
            IntParse(num);          // Incorrect Format -> Input string was not in a correct format.


            //Parse(String, NumberStyles)
            Console.WriteLine("---> Output for Parse(String, NumberStyles)");
            IntParse("123", NumberStyles.None);
            IntParse("189.0", NumberStyles.AllowDecimalPoint);
            IntParse("678.8", NumberStyles.AllowDecimalPoint);
            IntParse("$345,789,890,876", NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands);
            IntParse("789E05", NumberStyles.AllowExponent);
            IntParse("78,908", NumberStyles.AllowThousands);

            //Parse(String, NumberStyles, IFormatProvider)
            Console.WriteLine("---> Output for Parse(String, NumberStyles, IFormatProvider)");
            IntParse("78,000", NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"));
            IntParse("78,000", NumberStyles.Float, new CultureInfo("en-US"));
            IntParse("78,000", NumberStyles.AllowThousands, new CultureInfo("en-GB"));
            IntParse("78.000", NumberStyles.Float, new CultureInfo("en-US"));
            IntParse("78,899.00", NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.InvariantInfo);

            //Parse(ReadOnlySpan<Char>, NumberStyles, IFormatProvider)
            Console.WriteLine("---> Output for Parse(ReadOnlySpan<Char>, NumberStyles, IFormatProvider)");
            IntParse("78,000".AsSpan(), NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"));
            IntParse("78,000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US"));
            IntParse("78,000".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("en-GB"));

            //TryParse(String, Int32)
            Console.WriteLine("---> Output for TryParse(String, Int32)");
            foreach (string value in values)
            {
                IntTryParse(value, out int result);
            }

            //TryParse(String, NumberStyles, IFormatProvider, Int32)
            Console.WriteLine("---> Output for TryParse(String, NumberStyles, IFormatProvider, Int32)");
            IntTryParse("78,000", NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"), out int number);
            IntTryParse("78,000", NumberStyles.Float, new CultureInfo("en-US"), out int numFloat);
            IntTryParse("78,000", NumberStyles.AllowThousands, new CultureInfo("en-GB"), out int numThousand);
            IntTryParse("78.000", NumberStyles.Float, new CultureInfo("en-US"), out int numDec);
            IntTryParse("78,899.00", NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.InvariantInfo, out int numDecThousand);

            //TryParse(ReadOnlySpan<Char>, Int32)
            Console.WriteLine("---> Output for TryParse(ReadOnlySpan<Char>, Int32)");
            foreach (string value in values)
            {
                IntTryParse(value.AsSpan(), out int convertedNum);
            }

            //TryParse(String, NumberStyles, IFormatProvider, Int32)
            Console.WriteLine("---> Output for TryParse(String, NumberStyles, IFormatProvider, Int32)");
            IntTryParse("78,000".AsSpan(), NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"), out int numSpan);
            IntTryParse("78,000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US"), out int numFloatSpan);
            IntTryParse("78,000".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("en-GB"), out int numThousandSpan);
            IntTryParse("78.000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US"), out int numDecSpan);
            IntTryParse("78,899.00".AsSpan(), NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.InvariantInfo, out int numDecThousandSpan);
        }

        public static int IntParse(string value)
        {
            int number = 0;

            try
            {
                number = int.Parse(value);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Incorrect Format -> {fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Overflow -> {oe.Message}");
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine($"Argument Null -> {ae.Message}");
            }

            return number;
        }

        public static int IntParse(string value, IFormatProvider format)
        {
            int number = 0;

            try
            {
                number = int.Parse(value, format);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Incorrect Format -> {fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Overflow -> {oe.Message}");
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine($"Argument Null -> {ae.Message}");
            }

            return number;
        }

        public static int IntParse(string value, NumberStyles style)
        {
            int number = 0;

            try
            {
                number = int.Parse(value, style);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Incorrect Format -> {fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Overflow -> {oe.Message}");
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine($"Argument Null -> {ae.Message}");
            }
            catch (ArgumentException a)
            {
                Console.WriteLine($"Bad Argument -> {a.Message}");
            }

            return number;
        }

        public static int IntParse(string value, NumberStyles style, IFormatProvider format)
        {
            int number = 0;

            try
            {
                number = int.Parse(value, style, format);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Incorrect Format -> {fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Overflow -> {oe.Message}");
            }

            return number;
        }

        public static int IntParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider format)
        {
            int number = 0;

            try
            {
                number = int.Parse(value, style, format);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Incorrect Format -> {fe.Message}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Overflow -> {oe.Message}");
            }

            return number;
        }

        public static bool IntTryParse(string value, out int result)
        {
            bool success = int.TryParse(value, out result);

            if (success)
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"Conversion Failed for {value}");

            return success;
        }

        public static bool IntTryParse(string value, NumberStyles style, IFormatProvider format, out int result)
        {
            bool success = int.TryParse(value, style, format, out result);

            if (success)
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"Conversion Failed for {value}");

            return success;
        }

        public static bool IntTryParse(ReadOnlySpan<char> value, out int result)
        {
            bool success = int.TryParse(value, out result);

            if (success)
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"Conversion Failed for {value}");

            return success;
        }

        public static bool IntTryParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider format, out int result)
        {
            bool success = int.TryParse(value, style, format, out result);

            if (success)
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"Conversion Failed for {value}");

            return success;
        }
    }
}
