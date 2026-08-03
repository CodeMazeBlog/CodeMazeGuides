namespace Tests
{
    public class DateTimeComparisonTests
    {
        [Fact]
        public void GivenDateTime_WhenComparedUsingRelationalOperators_ThenReturnBool()
        {
            var firstDate = new DateTime(2023, 5, 1);
            var secondDate = new DateTime(2023, 5, 2);

            Assert.True(firstDate < secondDate);

            Assert.False(firstDate > secondDate);

            Assert.False(firstDate == secondDate);
        }

        [Fact]
        public void GivenDateTime_WhenComparedUsingCompareTo_ThenReturnInt()
        {
            var firstDate = new DateTime(2023, 5, 1);
            var date2 = new DateTime(2023, 5, 2);

            Assert.True(firstDate.CompareTo(date2) < 0);

            Assert.False(firstDate.CompareTo(date2) > 0);

            Assert.False(firstDate.CompareTo(date2) == 0);
        }

        [Fact]
        public void GivenDateTime_WhenComparedUsingEquals_ThenReturnBool()
        {
            var firstDate = new DateTime(2023, 5, 1);
            var secondDate = new DateTime(2023, 5, 1);

            Assert.True(firstDate.Equals(secondDate));

            Assert.True(firstDate == secondDate);
        }

        [Fact]
        public void GivenDateTime_WhenComparedUsingCompare_ThenReturnInt()
        {
            var firstDate = new DateTime(2023, 5, 1);
            var secondDate = new DateTime(2023, 5, 2);

            Assert.True(DateTime.Compare(firstDate, secondDate) < 0);

            Assert.False(DateTime.Compare(firstDate, secondDate) > 0);

            Assert.False(DateTime.Compare(firstDate, secondDate) == 0);
        }
    }
}