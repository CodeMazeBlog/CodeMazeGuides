using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class TryParseTest
    {
        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "1/15/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var success = DateTime.TryParse(dateString, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var provider = new CultureInfo("en-GB");
            var success = DateTime.TryParse(dateString, provider, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            var dateString = "2023/1/15 14:21:37-03:00";
            DateTimeOffset expectedDate = new(2023, 1, 15, 14, 21, 37, TimeSpan.FromHours(-3));
            var provider = new CultureInfo("en-GB");
            var styles = DateTimeStyles.AdjustToUniversal;
            var success = DateTime.TryParse(dateString, provider, styles, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTime_ThenReturnsValidDateTime()
        {
            var dateSpan = "1/15/2023".AsSpan();
            DateTime expectedDate = new(2023, 1, 15);
            var success = DateTime.TryParse(dateSpan, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var provider = new CultureInfo("en-GB");
            var success = DateTime.TryParse(dateString, provider, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var provider = new CultureInfo("en-GB");
            var styles = DateTimeStyles.None;
            var success = DateTime.TryParse(dateString, provider, styles, out DateTime actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }
    }
}
