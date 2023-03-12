using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class TryParseTest
    {
        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTime_ThenReturnsValidDateTime()
        {
            string dateString = "1/15/2023";
            DateTime expectedDate = new DateTime(2023, 1, 15);
            DateTime actualDate;
            bool success = DateTime.TryParse(dateString, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            string dateString = "15/1/2023";
            DateTime expectedDate = new DateTime(2023, 1, 15);
            IFormatProvider provider = new CultureInfo("en-GB");
            DateTime actualDate;
            bool success = DateTime.TryParse(dateString, provider, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            string dateString = "2023/1/15 14:21:37-03:00";
            DateTimeOffset expectedDate = new DateTimeOffset(2023, 1, 15, 14, 21, 37, TimeSpan.FromHours(-3));
            IFormatProvider provider = new CultureInfo("en-GB");
            DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;
            DateTime actualDate;
            bool success = DateTime.TryParse(dateString, provider, styles, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTime_ThenReturnsValidDateTime()
        {
            ReadOnlySpan<char> dateSpan = "1/15/2023".AsSpan();
            DateTime expectedDate = new DateTime(2023, 1, 15);
            DateTime actualDate;
            bool success = DateTime.TryParse(dateSpan, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            string dateString = "15/1/2023";
            DateTime expectedDate = new DateTime(2023, 1, 15);
            IFormatProvider provider = new CultureInfo("en-GB");
            DateTime actualDate;
            bool success = DateTime.TryParse(dateString, provider, out actualDate);

            Assert.True(success);
            Assert.Equal(new DateTime(2023, 1, 15), actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            string dateString = "15/1/2023";
            DateTime expectedDate = new DateTime(2023, 1, 15);
            IFormatProvider provider = new CultureInfo("en-GB");
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime actualDate;
            bool success = DateTime.TryParse(dateString, provider, styles, out actualDate);

            Assert.True(success);
            Assert.Equal(new DateTime(2023, 1, 15), actualDate);
        }
    }
}
