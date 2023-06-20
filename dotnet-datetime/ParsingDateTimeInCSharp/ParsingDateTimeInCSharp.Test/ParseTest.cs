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
            var actualDate = DateTime.Parse(dateString);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var provider = new CultureInfo("fr-FR");
            var actualDate = DateTime.Parse(dateString, provider);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            var dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var provider = new CultureInfo("fr-FR");
            var style = DateTimeStyles.None;
            var actualDate = DateTime.Parse(dateString, provider, style);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateSpan = "1/12/2023 2:21:37 PM".AsSpan();
            DateTime expectedDate = new(2023, 12, 1, 14, 21, 37);
            var provider = new CultureInfo("fr-FR");
            var actualDate = DateTime.Parse(dateSpan, provider);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            var pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTimeOffset date = new(2023, 12, 1, 14, 21, 37, TimeSpan.FromHours(-3));
            DateTimeOffset utcDate = date.UtcDateTime;
            var dateString = "2023/12/01T14:21:37-3:00";
            var dateSpan = dateString.AsSpan();
            var provider = new CultureInfo("fr-FR");
            var expectedDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate.DateTime, pacificZone);
            var style = DateTimeStyles.AssumeLocal;
            DateTimeOffset auxActualDate = DateTime.Parse(dateSpan, provider, style);
            var actualDate = TimeZoneInfo.ConvertTimeFromUtc(auxActualDate.UtcDateTime, pacificZone);

            Assert.Equal(expectedDate, actualDate);
        }
    }
}