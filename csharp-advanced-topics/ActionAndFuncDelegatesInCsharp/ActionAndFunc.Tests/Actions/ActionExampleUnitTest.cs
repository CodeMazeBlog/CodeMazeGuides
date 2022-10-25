using ActionAndFuncDelegate.Actions;
using FluentAssertions;

namespace ActionAndFunc.Tests.Actions
{
    public class ActionExampleUnitTest
    {
        private readonly ActionExample _actionExample;

        public ActionExampleUnitTest()
        {
            _actionExample = new ActionExample();
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(5, 2, 7)]
        [InlineData(-2, 2, 0)]
        public void WhenExecuteActionDelegate_RunWithParams_ThenReturnSum(int numberInput1, int numberInput2, int resultExpected)
        {
            _actionExample.RunWithParams(numberInput1, numberInput2);

            _actionExample.sumResult.Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(10)]
        public void WhenExecuteActionDelegate_RunWithoutParams_ThenReturnSum(int resultExpected)
        {
            _actionExample.RunWithoutParams();

            _actionExample.sumResult.Should().Be(resultExpected);
        }
    }
}
