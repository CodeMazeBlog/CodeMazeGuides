using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class TryParseExactTest
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
        public void GivenAStringRepresentationOfDateTimeAndAStringFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "15-01-2023";
            var format = "dd-MM-yyyy";
            DateTime expectedDate = new(2023, 01, 15);
            var success = TryParseExactMethod.TryParseExactWithStringAndStringAndFormatProviderAndDateTimeStylesInputParameters(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndASpanFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "15-01-2023";
            var format = "dd-MM-yyyy";
            DateTime expectedDate = new(2023, 01, 15);
            var success = TryParseExactMethod.TryParseExactWithSpanAndSpanAndFormatProviderAndDateTimeStylesInputParameters(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTimeAnStringArrayFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var resultKeyValuePair = TryParseExactMethod.TryParseExactWithStringAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(_dateStringsByFormat, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

            Assert.All(
                resultKeyValuePair,
                result =>
                {
                    Assert.True(result.Value.Item1);
                    Assert.Equal(expected, result.Value.Item2);
                });
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndAStringArrayFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            var resultKeyValuePair = TryParseExactMethod.TryParseExactWithSpanAndStringArrayAndFormatProviderAndDateTimeStylesInputParameters(_dateStringsByFormat, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime expected = new(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

            Assert.All(
                resultKeyValuePair,
                result =>
                {
                    Assert.True(result.Value.Item1);
                    Assert.Equal(expected, result.Value.Item2);
                });
        }
    }
}
