using System;
using Xunit;

namespace Tests
{
    public class DateOnlyTests
    {
        [Fact]
        public void CanCreateDateOnly()
        {
            // Arrange/Act.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Assert.
            Assert.Equal(2022, dateOnly.Year);
            Assert.Equal(1, dateOnly.Month);
            Assert.Equal(1, dateOnly.Day);
        }

        [Fact]
        public void CanAddDays()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);            

            // Act.
            var newDate = dateOnly.AddDays(1);

            // Assert.
            Assert.Equal(dateOnly.Day + 1, newDate.Day);
        }

        [Fact]
        public void CanAddMonths()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var newDate = dateOnly.AddMonths(1);

            // Assert.
            Assert.Equal(dateOnly.Month + 1, newDate.Month);
        }

        [Fact]
        public void CanAddYears()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var newDate = dateOnly.AddYears(1);

            // Assert.
            Assert.Equal(dateOnly.Year + 1, newDate.Year);
        }

        [Fact]
        public void CanParse()
        {
            // Arrange.
            var someDate = "2022/01/01";
            bool parsed;

            // Act.
            parsed = DateOnly.TryParse(someDate, out DateOnly result);

            // Assert.
            Assert.True(parsed);
        }

        [Fact]
        public void CanConvertFromDateTime()
        {
            // Arrange.
            var dateTime = new DateTime(2022, 1, 1, 11, 30, 0);

            // Act.
            var dateOnly = DateOnly.FromDateTime(dateTime);

            // Assert.
            Assert.Equal(2022, dateOnly.Year);
            Assert.Equal(1, dateOnly.Month);
            Assert.Equal(1, dateOnly.Day);
        }

        [Fact]
        public void CanUseLessThanOperator()
        {
            // Arrange.
            var before = new DateOnly(2022, 1, 1);
            var after = new DateOnly(2022, 1, 2);

            // Act.
            var isLessThan = before < after;

            // Assert.
            Assert.True(isLessThan);
        }

        [Fact]
        public void CanUseGreaterThanOperator()
        {
            // Arrange.
            var before = new DateOnly(2022, 1, 1);
            var after = new DateOnly(2022, 1, 2);

            // Act.
            var isAfter = after > before;

            // Assert.
            Assert.True(isAfter);
        }
        [Fact]
        public void CanParseExactWithAKnownFormat()
        {
            // Arrange.
            var text = "2022-01-01";

            // Act.
            var date = DateOnly.ParseExact(text, "yyyy-MM-dd");

            // Assert.
            Assert.Equal(new DateOnly(2022, 1, 1), date);
        }

        [Fact]
        public void CanConvertToDateTimeWithATimeOnly()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);
            var timeOnly = new TimeOnly(11, 30);

            // Act.
            var combined = dateOnly.ToDateTime(timeOnly);

            // Assert.
            Assert.Equal(new DateTime(2022, 1, 1, 11, 30, 0), combined);
            Assert.Equal(DateTimeKind.Unspecified, combined.Kind);
        }

        [Fact]
        public void CanConvertToDateTimeAtMidnight()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var midnight = dateOnly.ToDateTime(TimeOnly.MinValue);

            // Assert.
            Assert.Equal(new DateTime(2022, 1, 1, 0, 0, 0), midnight);
            Assert.Equal(DateTimeKind.Unspecified, midnight.Kind);
        }

        [Fact]
        public void CanConvertToDateTimeWithAKnownKind()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);
            var timeOnly = new TimeOnly(11, 30);

            // Act.
            var utc = dateOnly.ToDateTime(timeOnly, DateTimeKind.Utc);

            // Assert.
            Assert.Equal(DateTimeKind.Utc, utc.Kind);
            Assert.Equal(new DateTime(2022, 1, 1, 11, 30, 0, DateTimeKind.Utc), utc);
        }

        [Fact]
        public void CanGetTodaysDateFromDateTimeNow()
        {
            // Arrange.
            var now = DateTime.Now;

            // Act.
            var today = DateOnly.FromDateTime(now);

            // Assert. CI runs at an arbitrary instant, so we assert consistency, not a value.
            Assert.Equal(now.Year, today.Year);
            Assert.Equal(now.Month, today.Month);
            Assert.Equal(now.Day, today.Day);
        }

        [Fact]
        public void CanRoundTripThroughDayNumber()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var dayNumber = dateOnly.DayNumber;
            var roundTripped = DateOnly.FromDayNumber(dayNumber);

            // Assert.
            Assert.Equal(dateOnly, roundTripped);
            Assert.Equal(1, dateOnly.DayNumber - new DateOnly(2021, 12, 31).DayNumber);
        }

    }
}