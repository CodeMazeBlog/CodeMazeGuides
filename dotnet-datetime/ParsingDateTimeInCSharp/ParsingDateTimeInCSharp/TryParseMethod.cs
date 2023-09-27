using System.Globalization;

namespace ParsingDateTimeInCSharp
{
    public static class TryParseMethod
    {
        public static bool TryParseWithStringInputParameter(string dateString, out DateTime parsedDate)
            => DateTime.TryParse(dateString, out parsedDate);

        public static bool TryParseWithStringAndFormatProviderInputParameters(string dateString, string culture, out DateTime parsedDate)
            => DateTime.TryParse(dateString, new CultureInfo(culture), out parsedDate);

        public static bool TryParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string culture, DateTimeStyles dateTimeStyles, out DateTime parsedDate)
            => DateTime.TryParse(dateString, new CultureInfo(culture), dateTimeStyles, out parsedDate);

        public static bool TryParseWithSpanInputParameter(string dateString, out DateTime parsedDate)
            => DateTime.TryParse(dateString.AsSpan(), out parsedDate);

        public static bool TryParseWithSpanAndFormatProviderInputParameters(string dateString, string culture, out DateTime parsedDate)
            => DateTime.TryParse(dateString.AsSpan(), new CultureInfo(culture), out parsedDate);

        public static bool TryParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string culture, DateTimeStyles dateTimeStyles, out DateTime parsedDate)
            => DateTime.TryParse(dateString.AsSpan(), new CultureInfo(culture), dateTimeStyles, out parsedDate);
    }
}
