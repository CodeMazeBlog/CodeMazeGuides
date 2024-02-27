using CountEnumMembers;

namespace Tests
{
    public class CountEnumMembersTest
    {
        [Fact]
        public void WhenGetValuesMethodIsCalled_ThenValuesMethodIsInvoked()
        {
            var months = Enum.GetValues(typeof(Months));
            var expectedResult = 12;
            var actualResult = Program.Values(months);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WhenGetNamesMethodIsCalled_ThenNamesMethodIsInvoked()
        {
            var months = Enum.GetNames(typeof(Months));
            var expectedResult = 12;
            var actualResult = Program.Names(months);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}