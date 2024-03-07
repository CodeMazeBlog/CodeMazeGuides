using CountEnumMembers;

namespace Tests
{
    public class CountEnumMembersTest
    {
        [Fact]
        public void WhenGetNamesMethodIsCalled_ThenTotalNumberOfItemsIsReturned()
        {
            var getnames = Enum.GetNames(typeof(Months)).Length;
            Assert.Equal(12, getnames);
        }

        [Fact]
        public void WhenGetValuesMethodIsCalled_ThenTotalNumberOfValuesIsReturned()
        {
            var getvalues = Enum.GetValues(typeof(Months)).Length;
            Assert.Equal(12, getvalues);
        }
    }
}