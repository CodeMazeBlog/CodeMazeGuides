using ConvertDateTimeToIso8601String;
using ReflectionMagic;
using System;
using System.IO;
using Xunit;

namespace ConvertDateTimeToIso8601StringTests
{
    public class ConvertDateTimeToIso8601StringUnitTest : IDisposable
    {
        readonly DateTime localTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Local);
        readonly DateTime utcTime = new DateTime(2022, 1, 13, 16, 25, 35, 125, DateTimeKind.Utc);

        private readonly TimeZoneInfo _originalLocalTimeZone;

        public ConvertDateTimeToIso8601StringUnitTest()
        {
            // Mock local TimeZone
            _originalLocalTimeZone = TimeZoneInfo.Local;
            SetLocalTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time"));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedBySortableFormat_ThenVerifyIso8601Output()
        {
            Assert.Equal("2022-01-13T16:25:35", localTime.ToString("s"));

            Assert.Equal("2022-01-13T16:25:35", utcTime.ToString("s"));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedByRoundTripFormat_ThenVerifyIso8601Output()
        {
            Assert.Equal("2022-01-13T16:25:35.1250000+06:00", localTime.ToString("o"));

            Assert.Equal("2022-01-13T16:25:35.1250000Z", utcTime.ToString("o"));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedByToUniversalIso8601String_ThenVerifyIso8601Output()
        {
            Assert.Equal("2022-01-13T10:25:35Z", localTime.ToUniversalIso8601());

            Assert.Equal("2022-01-13T16:25:35Z", utcTime.ToUniversalIso8601());
        }

        [Theory]
        [InlineData("yyyy-MM-dd", "2022-01-13")]
        [InlineData("yyyyMMdd", "20220113")]
        [InlineData("yyyy-MM", "2022-01")]
        [InlineData("--MM-dd", "--01-13")]
        [InlineData("--MMdd", "--0113")]
        [InlineData("THH:mm:ss.fff", "T16:25:35.125")]
        [InlineData("THH:mm:ss", "T16:25:35")]
        [InlineData("THH:mm", "T16:25")]
        [InlineData("THH", "T16")]
        [InlineData("THHmmssfff", "T162535125")]
        [InlineData("yyyyMMddTHHmmssK", "20220113T162535+06:00")]
        [InlineData("yyyyMMddTHHmm", "20220113T1625")]
        [InlineData("yyyy-MM-ddTHH:mmZ", "2022-01-13T16:25Z")]
        [InlineData("yyyyMMddTHHmmsszzz", "20220113T162535+06:00")]
        [InlineData("yyyyMMddTHHmmsszz", "20220113T162535+06")]
        public void GivenADateTime_WhenConvertedByCustomFormats_ThenVerifyIso8601Output(string format, string expectedOutput)
        {
            Assert.Equal(expectedOutput, localTime.ToString(format));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedByTimeZoneLiteral_ThenVerifyIso8601Output()
        {
            var format = "yyyy-MM-ddTHH:mm:ssK";
            var unspecified = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Unspecified);
            var utc = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Utc);
            var local = new DateTime(2022, 1, 13, 16, 25, 30, DateTimeKind.Local);

            Assert.Equal("2022-01-13T16:25:30", unspecified.ToString(format));
            Assert.Equal("2022-01-13T16:25:30Z", utc.ToString(format));
            Assert.Equal("2022-01-13T16:25:30+06:00", local.ToString(format));
            Assert.Equal("2022-01-13T16:25:30+06", local.ToString("yyyy-MM-ddTHH:mm:sszz"));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedByToIso8601WeekDateString_ThenVerifyIso8601Output()
        {
            Assert.Equal("2022-W03", localTime.ToShortIso8601WeekDateString());
            Assert.Equal("2022W03", localTime.ToShortIso8601WeekDateString(useSeparator: false));

            Assert.Equal("2022-W03-4", localTime.ToExtendedIso8601WeekDateString());
            Assert.Equal("2022W034", localTime.ToExtendedIso8601WeekDateString(useSeparator: false));
        }

        [Fact]
        public void GivenADateTime_WhenConvertedByToIso8601OrdinalDateString_ThenVerifyIso8601Output()
        {
            Assert.Equal("2022-013", localTime.ToIso8601OrdinalDateString());
            Assert.Equal("2022013", localTime.ToIso8601OrdinalDateString(useSeparator: false));
        }

        private static void SetLocalTimeZone(TimeZoneInfo timeZoneInfo)
        {
            typeof(TimeZoneInfo).AsDynamicType().s_cachedData._localTimeZone = timeZoneInfo;
        }

        public void Dispose()
        {
            SetLocalTimeZone(_originalLocalTimeZone);
            GC.SuppressFinalize(this);
        }
    }
}