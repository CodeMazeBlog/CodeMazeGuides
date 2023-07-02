using System.Globalization;

namespace ParsingDateTimeInCSharp
{
    public static class TryParseExactMethod
    {
        public static bool TryParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string format, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles, out DateTime parsedDate)
            => DateTime.TryParseExact(dateString, format, cultureInfo, dateTimeStyles, out parsedDate);

        public static bool TryParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string format, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles, out DateTime parsedDate)
            => DateTime.TryParseExact(dateString.AsSpan(), format.AsSpan(), cultureInfo, dateTimeStyles, out parsedDate);

        public static Dictionary<string, (bool, DateTime)> TryParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(Dictionary<string, string> dateStrings, string[] formats, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles)
        {
            var result = new Dictionary<string, (bool, DateTime)>();

            foreach (var format in formats)
            {
                var dateString = dateStrings[format];
                result.Add(dateString, (DateTime.TryParseExact(dateString, formats, cultureInfo, dateTimeStyles, out var parsedDate), parsedDate));
            }

            return result;
        }

        public static Dictionary<string, (bool, DateTime)> TryParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(Dictionary<string, string> dateStrings, string[] formats, CultureInfo cultureInfo, DateTimeStyles dateTimeStyles)
        {
            var result = new Dictionary<string, (bool, DateTime)>();

            foreach (var format in formats)
            {
                var dateSpan = dateStrings[format].AsSpan();
                result.Add(dateStrings[format], (DateTime.TryParseExact(dateSpan, formats, cultureInfo, dateTimeStyles, out var parsedDate), parsedDate));
            }

            return result;
        }
    }
}
