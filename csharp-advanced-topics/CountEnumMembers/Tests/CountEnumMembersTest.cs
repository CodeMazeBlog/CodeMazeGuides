using CountEnumMembers;
using Xunit;

namespace Tests
{
    public class CountEnumMembersTest
    {
        [Fact]
        public void WhenGetNamesMethodIsCalled_ThenTotalNumberOfItemsIsReturned()
        {
            var getnames = Enum.GetNames<Months>().Length;
            Assert.Equal(12, getnames);
        }

        [Fact]
        public void WhenGetValuesMethodIsCalled_ThenTotalNumberOfValuesIsReturned()
        {
            var getvalues = Enum.GetValues<Months>().Length;
            Assert.Equal(12, getvalues);
        }

        [Fact]
        public void WhenGetValuesDistinctMethodIsCalled_ThenTotalNumberOfDistinctValuesIsReturned()
        {
            var distinct_values = Enum.GetValues(typeof(Seasons)).Cast<Seasons>().Distinct().Count();
            Assert.Equal(3, distinct_values);
        }
    }
}