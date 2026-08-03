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
            var success = TryParseMethod.TryParseWithStringInputParameter(dateString, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var success = TryParseMethod.TryParseWithStringAndFormatProviderInputParameters(dateString, "en-GB", out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenAStringRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            var dateString = "2023/1/15 14:21:37-03:00";
            DateTimeOffset expectedDate = new(2023, 1, 15, 14, 21, 37, TimeSpan.FromHours(-3));
            var success = TryParseMethod.TryParseWithStringAndFormatProviderAndDateTimeStylesInputParameters(dateString, "en-GB", DateTimeStyles.AdjustToUniversal, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTime_ThenReturnsValidDateTime()
        {
            var dateString = "1/15/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var success = TryParseMethod.TryParseWithSpanInputParameter(dateString, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProvider_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var success = TryParseMethod.TryParseWithSpanAndFormatProviderInputParameters(dateString, "en-GB", out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTime_WhenTryParseToDateTimeWithProviderAndStyle_ThenReturnsValidDateTime()
        {
            var dateString = "15/1/2023";
            DateTime expectedDate = new(2023, 1, 15);
            var success = TryParseMethod.TryParseWithSpanAndFormatProviderAndDateTimeStylesInputParameters(dateString, "en-GB", DateTimeStyles.None, out var actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }
    }
}
