namespace AnyAndExistsMethodsInCSharp.Tests
{
    public class NumbersHelperUnitTests
    {

        [Fact]
        public void WhenProvidingAnEmptyCollection_ThenReturnTrue()
        {
            var numbers = new int[0];

            Assert.True(NumbersHelper.CheckIfArrayIsEmpty(numbers));
        }

        [Fact]
        public void WhenProvidingACollectionWithPositiveNumbers_ThenReturnTrue()
        {
            var numbers = new List<int>() { -10, 0, 1 };

            Assert.True(NumbersHelper.CheckIfListContainsPositiveNumbersAny(numbers));
        }

        [Fact]
        public void WhenProvidingAListWithNoPositiveNumbers_ThenReturnFalse()
        {
            var numbers = new List<int>() { -10, 0, -1 };

            Assert.False(NumbersHelper.CheckIfListContainsPositiveNumbersAny(numbers));
        }
    }
}