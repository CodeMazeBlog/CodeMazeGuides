using ActionAndFuncDelegates;

namespace Tests
{
    public class GetResultsTests
    {
        private List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        private readonly int _expectedTopOutput = 5;
        private readonly int _expectedBottomOutput = 1;

        [Fact]
        public void GivenAListOfNumbers_WhenTopIsInvoked_ThenReturnTheLargestNumber()
        {
            Func<List<int>, int> func = GetResults.Top;
            var actual = func(numbers);

            Assert.Equal(_expectedTopOutput, actual);
        }

        [Fact]
        public void GivenAListOfNumbers_WhenBottomIsInvoked_ThenReturnTheSmallestNumber()
        {
            Func<List<int>, int> func = GetResults.Bottom;
            var actual = func(numbers);

            Assert.Equal(_expectedBottomOutput, actual);
        }
    }
}