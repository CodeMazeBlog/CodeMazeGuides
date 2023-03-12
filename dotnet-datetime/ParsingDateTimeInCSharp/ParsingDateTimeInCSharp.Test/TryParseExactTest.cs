using System.Globalization;

namespace ParsingDateTimeInCSharp.Test
{
    public class TryParseExactTest
    {
        [Fact]
        public void GivenAStringRepresentationOfDateTimeAndAStringFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            string dateString = "15-01-2023";
            string format = "dd-MM-yyyy";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime expectedDate = new DateTime(2023, 01, 15);
            DateTime actualDate;
            bool success = DateTime.TryParseExact(dateString, format, provider, styles, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndASpanFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
        {
            ReadOnlySpan<char> dateSpan = "15-01-2023";
            ReadOnlySpan<char> formatSpan = "dd-MM-yyyy";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime expectedDate = new DateTime(2023, 01, 15);
            DateTime actualDate;
            bool success = DateTime.TryParseExact(dateSpan, formatSpan, provider, styles, out actualDate);

            Assert.True(success);
            Assert.Equal(expectedDate, actualDate);
        }
        
        [Fact]
        public void GivenAStringRepresentationOfDateTimeAnStringArrayFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
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
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" },
            };

            foreach (var format in formats)
            {
                string dateString = dateStringsByFormat[format];
                DateTime result;
                bool success = DateTime.TryParseExact(dateString, format, culture, styles, out result);
                DateTime expected = new DateTime(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

                Assert.True(success);
                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void GivenASpanRepresentationOfDateTimeAndAStringArrayFormat_WhenTryParseExactToDateTime_ThenReturnsValidDateTime()
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
                { "dd/MM/yyyy HH:mm:ss", "15/01/2023 14:12:12" },
            };

            foreach (var format in formats)
            {
                string dateString = dateStringsByFormat[format];
                DateTime result;
                bool success = DateTime.TryParseExact(dateString.AsSpan(), format, culture, styles, out result);
                DateTime expected = new DateTime(2023, 1, 15, 14, 12, 12, DateTimeKind.Utc);

                Assert.True(success);
                Assert.Equal(expected, result);
            }
        }
    }
}
