using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class ParseExactTest
    {

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringFormatWithProvider_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023 10:12:12";
            var format = "dd/M/yyyy hh:mm:ss";
            var provider = new CultureInfo("fr-FR");
            DateTime expectedDate = new(2023, 1, 15, 10, 12, 12);
            var actualDate = DateTime.ParseExact(dateString, format, provider);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "2023-01-15T14:12:12.0000000Z";
            var format = "o";
            var provider = new CultureInfo("fr-FR");
            var style = DateTimeStyles.RoundtripKind;
            DateTime expectedDate = new(2023, 1, 15, 14, 12, 12);
            var actualDate = DateTime.ParseExact(dateString, format, provider, style);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndASpanFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateSpan = "2023-01-15T14:12:12.0000000Z".AsSpan();
            var format = "o".AsSpan();
            var provider = new CultureInfo("fr-FR");
            var style = DateTimeStyles.RoundtripKind;
            DateTime expectDate = new(2023, 1, 15, 14, 12, 12);

            var actualDate = DateTime.ParseExact(dateSpan, format, provider, style);

            // Assert
            Assert.Equal(expectDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringArrayFormatWithProviderAndStyle_WhenParseExactToDateTime_ThenReturnsValidDateTime()
        {
            string[] formats = { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            var culture = CultureInfo.InvariantCulture;
            var styles = DateTimeStyles.None;
            var dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
            };

            foreach (var format in formats)
            {
                var dateString = dateStringsByFormat[format];
                var result = DateTime.ParseExact(dateString, formats, culture, styles);
                DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndAStringArrayFormat_WhenParseExactToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            string[] formats = { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "yyyy-MM-dd'T'HH:mm:ss'Z'", "yyyyMMdd'T'HH:mm:ss.fff'Z'", "yyyyMMdd'T'HH:mm:ss'Z'", "dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
            var culture = CultureInfo.InvariantCulture;
            var styles = DateTimeStyles.None;
            var dateStringsByFormat = new Dictionary<string, string>
            {
                { "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", "2023-01-15T14:12:12.000Z" },
                { "yyyy-MM-dd'T'HH:mm:ss'Z'", "2023-01-15T14:12:12Z" },
                { "yyyyMMdd'T'HH:mm:ss.fff'Z'", "20230115T14:12:12.000Z" },
                { "yyyyMMdd'T'HH:mm:ss'Z'", "20230115T14:12:12Z" },
                { "dd-MM-yyyy HH:mm:ss", "15-01-2023 14:12:12" },
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" }
            };

            foreach (var format in formats)
            {
                var dateString = dateStringsByFormat[format];
                var result = DateTime.ParseExact(dateString.AsSpan(), formats, culture, styles);
                DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

                Assert.Equal(expected, result);
            }
        }
    }
}
