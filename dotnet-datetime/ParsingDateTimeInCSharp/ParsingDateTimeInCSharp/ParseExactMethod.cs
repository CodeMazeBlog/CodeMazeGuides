using System.Globalization;

namespace ParsingDateTimeInCSharp
{
    public static class ParseExactMethod
    {
        public static DateTime ParseExactWithStringAndStringAndFormatProviderInputParameters(string dateString, string format, string culture)
            => DateTime.ParseExact(dateString, format, new CultureInfo(culture));

        public static DateTime ParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string format, string culture, DateTimeStyles dateTimeStyles)
            => DateTime.ParseExact(dateString, format, new CultureInfo(culture), dateTimeStyles);

        public static DateTime ParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string format, string culture, DateTimeStyles dateTimeStyles)
            => DateTime.ParseExact(dateString.AsSpan(), format.AsSpan(), new CultureInfo(culture), dateTimeStyles);
      
        public static Dictionary<string, DateTime> ParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(Dictionary<string,string> dateStrings, string[] formats, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles)
        {
            var result = new Dictionary<string, DateTime>();

            try
            {
                foreach (string format in formats)
                {
                    var dateString = dateStrings[format];
                    result.Add(dateString, DateTime.ParseExact(dateString, formats, cultureInfo, dateTimeStyles));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public static Dictionary<string, DateTime> ParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(Dictionary<string, string> dateStrings, string[] formats, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles)
        {
            var result = new Dictionary<string, DateTime>();

            try
            {
                foreach (string format in formats)
                {
                    var dateString = dateStrings[format];
                    result.Add(dateString, DateTime.ParseExact(dateString.AsSpan(), formats, cultureInfo, dateTimeStyles));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
