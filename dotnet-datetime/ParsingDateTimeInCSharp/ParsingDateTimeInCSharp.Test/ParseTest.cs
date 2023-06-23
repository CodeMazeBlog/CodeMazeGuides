using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class ParseTest
    {
        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "1/15/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 1, 15, 14, 21, 37);
            var actualDate = ParseMethod.ParseWithStringInputParameter(dateString);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var actualDate = ParseMethod.ParseWithStringAndFormatProviderInputParameters(dateString, "fr-FR");

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            var dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var actualDate = ParseMethod.ParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(dateString, "fr-FR", DateTimeStyles.None);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var actualDate = ParseMethod.ParseWithSpanAndFormatProviderInputParameters(dateString, "fr-FR");

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTimeOffset date = new(2023, 12, 1, 14, 21, 37, TimeSpan.FromHours(-3));
            DateTimeOffset utcDate = date.UtcDateTime;
            var dateString = "2023/12/01T14:21:37-3:00";
            var expectedDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate.DateTime, pacificZone);

            DateTimeOffset auxActualDate = ParseMethod.ParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(dateString, "fr-FR", DateTimeStyles.AssumeLocal);
            var actualDate = TimeZoneInfo.ConvertTimeFromUtc(auxActualDate.UtcDateTime, pacificZone);

            Assert.Equal(expectedDate, actualDate);
        }
    }
}