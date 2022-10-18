using ActionAndFuncDelegate.Functions;
using FluentAssertions;

namespace ActionAndFunc.Tests.Functions
{
    public class FuncExampleTests
    {
        private readonly FuncExample _funcExample;

        public FuncExampleTests()
        {
            _funcExample = new FuncExample();
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(5, 2, 7)]
        [InlineData(-2, 2, 0)]
        public void WhenExecuteFuncDelegate_RunWithParams_ShouldReturnSum(int numberInput1, int numberInput2, int resultExpected)
        {
            int result = _funcExample.RunWithParams(numberInput1, numberInput2);

            result.Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10)]
        public void WhenExecuteFuncDelegate_RunWithoutParams_ShouldReturnSum(int resultExpected)
        {
            int result = _funcExample.RunWithoutParams();

            result.Should().Be(resultExpected);
        }
    }
}
