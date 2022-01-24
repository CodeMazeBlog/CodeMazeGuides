using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace Tests
{
    public class TimeOnlyTests
    {
        public TimeOnlyTests()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
        }

        [Fact]
        public void CanCreateTimeOnly()
        {
            // Arrange/Act.
            var timeOnly = new TimeOnly(11, 0);

            // Assert.
            Assert.Equal("11:00 AM", timeOnly.ToString());
        }

        [Fact]
        public void CanAddHours()
        {
            // Arrange.
            var timeOnly = new TimeOnly(11, 0);

            // Act.
            var newTime = timeOnly.AddHours(1);

            // Assert.
            Assert.Equal("12:00 PM", newTime.ToString());
        }

        [Fact]
        public void CanAddMonths()
        {
            // Arrange.
            var timeOnly = new TimeOnly(11, 0);

            // Act.
            var newTime = timeOnly.AddMinutes(1);

            // Assert.
            Assert.Equal("11:01 AM", newTime.ToString());
        }

        [Fact]
        public void CanGetInBetween()
        {
            // Arrange.
            var sevenAM = new TimeOnly(7, 0);
            var elevenAM = new TimeOnly(11, 0);
            var onePM = new TimeOnly(13, 0);

            // Act.
            var isBetween = elevenAM.IsBetween(sevenAM, onePM);

            // Assert.
            Assert.True(isBetween);
        }

        [Fact]
        public void CanConvertFromDateTime()
        {
            // Arrange.
            var dateTime = new DateTime(2022, 1, 1, 11, 30, 0);

            // Act.
            var timeOnly = TimeOnly.FromDateTime(dateTime);

            // Assert.
            Assert.Equal("11:30 AM", timeOnly.ToString());
        }

        [Fact]
        public void CanUseLessThanOperator()
        {
            // Arrange.
            var before = new TimeOnly(11, 0);
            var after = new TimeOnly(11, 30);

            // Act.
            var isLessThan = before < after;

            // Assert.
            Assert.True(isLessThan);
        }

        [Fact]
        public void CanUseGreaterThanOperator()
        {
            // Arrange.
            var before = new TimeOnly(11, 0);
            var after = new TimeOnly(11, 30);

            // Act.
            var isAfter = after > before;

            // Assert.
            Assert.True(isAfter);
        }
    }
}