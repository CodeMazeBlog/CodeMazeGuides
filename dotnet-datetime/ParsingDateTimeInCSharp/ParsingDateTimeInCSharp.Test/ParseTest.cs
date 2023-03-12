using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class ParseTest
    {
        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTime_ThenReturnsValidDateTime()
        {
            string dateString = "1/15/2023 2:21:37 PM";
            DateTime expectedDate = new DateTime(2023, 1, 15, 14, 21, 37);
            DateTime actualDate = DateTime.Parse(dateString);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            string dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new DateTime(2023, 12, 1, 14, 21, 37);
            IFormatProvider provider = new CultureInfo("fr-FR");
            DateTime actualDate = DateTime.Parse(dateString, provider);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            string dateString = "1/12/2023 2:21:37 PM";
            DateTime expectedDate = new DateTime(2023, 12, 1, 14, 21, 37);
            IFormatProvider provider = new CultureInfo("fr-FR");
            DateTimeStyles style = DateTimeStyles.None;
            DateTime actualDate = DateTime.Parse(dateString, provider, style);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            ReadOnlySpan<char> dateSpan = "1/12/2023 2:21:37 PM".AsSpan();
            DateTime expectedDate = new DateTime(2023, 12, 1, 14, 21, 37);
            IFormatProvider provider = new CultureInfo("fr-FR");
            DateTime actualDate = DateTime.Parse(dateSpan, provider);

            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenParseToDateTimeWithProviderAnStyle_ThenReturnsValidDateTime()
        {
            TimeZoneInfo pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTimeOffset date = new DateTimeOffset(2023, 12, 1, 14, 21, 37, TimeSpan.FromHours(-3));
            DateTimeOffset utcDate = date.UtcDateTime;
            string dateString = "2023/12/01T14:21:37-3:00";
            ReadOnlySpan<char> dateSpan = dateString.AsSpan();
            IFormatProvider provider = new CultureInfo("fr-FR");
            DateTime expectedDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate.DateTime, pacificZone);
            DateTimeStyles style = DateTimeStyles.AssumeLocal;
            DateTimeOffset auxActualDate = DateTime.Parse(dateSpan, provider, style);
            DateTime actualDate = TimeZoneInfo.ConvertTimeFromUtc(auxActualDate.UtcDateTime, pacificZone); 

            Assert.Equal(expectedDate, actualDate);
        }
    }
}