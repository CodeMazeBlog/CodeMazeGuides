using System;
using System.Globalization;

namespace ParseAndTryParseInCSharp
{
    public class Program
    {
        public static void Main(string[] args) { }

        public static int IntParse(string value)
        {
            int number;
            try
            {
                number = int.Parse(value);
            }
            catch (Exception)
            {
                throw;
            }

            return number;
        }

        public static int IntParse(string value, IFormatProvider provider)
        {
            int number;
            try
            {
                number = int.Parse(value, provider);
            }
            catch (Exception)
            {
                throw;
            }

            return number;
        }

        public static int IntParse(string value, NumberStyles style)
        {
            int number;
            try
            {
                number = int.Parse(value, style);
            }
            catch (Exception)
            {
                throw;
            }

            return number;
        }

        public static int IntParse(string value, NumberStyles style, IFormatProvider provider)
        {
            int number;
            try
            {
                number = int.Parse(value, style, provider);
            }
            catch (Exception)
            {
                throw;
            }

            return number;
        }

        public static int IntParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider)
        {
            int number;
            try
            {
                number = int.Parse(value, style, provider);
            }
            catch (Exception)
            {
                throw;
            }

            return number;
        }

        public static bool IntTryParse(string value, out int result)
        {
            return int.TryParse(value, out result);
        }

        public static bool IntTryParse(string value, NumberStyles style, IFormatProvider provider, out int result)
        {
            return int.TryParse(value, style, provider, out result);
        }

        public static bool IntTryParse(ReadOnlySpan<char> value, out int result)
        {
            return int.TryParse(value, out result);
        }

        public static bool IntTryParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider, out int result)
        {
            return int.TryParse(value, style, provider, out result);
        }
    }
}
