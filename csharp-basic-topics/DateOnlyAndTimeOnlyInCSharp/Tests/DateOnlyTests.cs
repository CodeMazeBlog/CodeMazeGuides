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
            Assert.Equal("1/01/2022", dateOnly.ToString());
        }

        [Fact]
        public void CanAddDays()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);            

            // Act.
            var newDate = dateOnly.AddDays(1);

            // Assert.
            Assert.Equal("2/01/2022", newDate.ToString());
        }

        [Fact]
        public void CanAddMonths()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var newDate = dateOnly.AddMonths(1);

            // Assert.
            Assert.Equal("1/02/2022", newDate.ToString());
        }

        [Fact]
        public void CanAddYears()
        {
            // Arrange.
            var dateOnly = new DateOnly(2022, 1, 1);

            // Act.
            var newDate = dateOnly.AddYears(1);

            // Assert.
            Assert.Equal("1/01/2023", newDate.ToString());
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
            Assert.Equal("1/01/2022", dateOnly.ToString());
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
    }
}