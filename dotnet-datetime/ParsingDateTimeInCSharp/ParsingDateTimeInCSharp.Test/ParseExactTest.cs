using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class ParseExactTest
    {
        private static readonly string[] _formats = { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
        private static readonly Dictionary<string, string> _dateStringsByFormat = new()
        {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
        };

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringFormatWithProvider_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023 10:12:12";
            var format = "dd/M/yyyy hh:mm:ss";
            DateTime expectedDate = new(2023, 1, 15, 10, 12, 12);
            var actualDate = ParseExactMethod.ParseExactWithStringAndStringAndFormatProviderInputParameters(dateString, format, "fr-FR");

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "2023-01-15T14:12:12.0000000Z";
            var format = "o";
            DateTime expectedDate = new(2023, 1, 15, 14, 12, 12);
            var actualDate = ParseExactMethod.ParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(dateString, format, "fr-FR", DateTimeStyles.RoundtripKind);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndASpanFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "2023-01-15T14:12:12.0000000Z";
            var format = "o";
            DateTime expectDate = new(2023, 1, 15, 14, 12, 12);
            var actualDate = ParseExactMethod.ParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(dateString, format, "fr-FR", DateTimeStyles.RoundtripKind);

            Assert.Equal(expectDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringArrayFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var resultKeyValuePair = ParseExactMethod.ParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(_dateStringsByFormat, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

            Assert.All(resultKeyValuePair, result => Assert.Equal(expected, result.Value));
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndAStringArrayFormat_WhenParseExactToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            var resultKeyValuePair = ParseExactMethod.ParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(_dateStringsByFormat, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

            Assert.All(resultKeyValuePair, result => Assert.Equal(expected, result.Value));
        }
    }
}
