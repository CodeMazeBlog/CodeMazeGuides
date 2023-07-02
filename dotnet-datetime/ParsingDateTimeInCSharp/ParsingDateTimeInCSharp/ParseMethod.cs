using System.Globalization;

namespace ParsingDateTimeInCSharp
{
    public static class ParseMethod
    {
        public static DateTime ParseWithStringInputParameter(string dateString)
            => DateTime.Parse(dateString);

        public static DateTime ParseWithStringAndFormatProviderInputParameters(string dateString, string culture)
            => DateTime.Parse(dateString, new CultureInfo(culture));


        public static DateTime ParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string culture, DateTimeStyles dateTimeStyles)
            => DateTime.Parse(dateString, new CultureInfo(culture), dateTimeStyles);

        public static DateTime ParseWithSpanAndFormatProviderInputParameters(string dateString, string culture)
            => DateTime.Parse(dateString.AsSpan(), new CultureInfo(culture));

        public static DateTime ParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(string dateString, string culture, DateTimeStyles dateTimeStyles)
            => DateTime.Parse(dateString.AsSpan(), new CultureInfo(culture), dateTimeStyles);
    }
}
