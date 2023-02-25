using ActionAndFuncDelegates;

namespace Tests
{
    public class DisplayResultsTests
    {
        private readonly List<int> numbers = new() { 1, 2, 3, 4, 5 };
        private readonly StringWriter output = new();
        private readonly string _expectedTopOutput = "5";
        private readonly string _expectedBottomOutput = "1";

        public DisplayResultsTests()
        {
            Console.SetOut(output);
        }

        internal void Dispose()
        {
            output.Dispose();
            GC.SuppressFinalize(this);
        }

        public string[] PrintedOutputToArray()
        {
            var printedString = output.ToString();
            return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void GivenAListOfNumbers_WhenTopIsInvoked_ThenDisplayTheLargestNumber()
        {
            Action<List<int>> action = DisplayResults.Top;
            action(numbers);

            var equalityArray = PrintedOutputToArray();

            Assert.Equal(_expectedTopOutput, equalityArray[0]);
        }

        [Fact]
        public void GivenAListOfNumbers_WhenBottomIsInvoked_ThenDisplayTheSmallestNumber()
        {
            Action<List<int>> action = DisplayResults.Bottom;
            action(numbers);

            var equalityArray = PrintedOutputToArray();

            Assert.Equal(_expectedBottomOutput, equalityArray[0]);
        }
    }
}