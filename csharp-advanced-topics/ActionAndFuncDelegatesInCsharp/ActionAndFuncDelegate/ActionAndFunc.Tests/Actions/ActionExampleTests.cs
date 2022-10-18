using ActionAndFuncDelegate.Actions;
using FluentAssertions;

namespace ActionAndFunc.Tests.Actions
{
    public class ActionExampleTests
    {
        private readonly ActionExample _actionExample;

        public ActionExampleTests()
        {
            _actionExample = new ActionExample();
        }

        [Theory]
        [InlineData(2, 2, "Sum result(with parameters): 4\r\n")]
        [InlineData(5, 2, "Sum result(with parameters): 7\r\n")]
        [InlineData(-2, 2, "Sum result(with parameters): 0\r\n")]
        public void WhenExecuteActionDelegate_RunWithParams_ShouldPrintSum(int numberInput1, int numberInput2, string resultExpected)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _actionExample.RunWithParams(numberInput1, numberInput2);

                sw.ToString().Should().Be(resultExpected);
            }
        }

        [Theory]
        [InlineData("Sum result(no parameters): 10\r\n")]
        public void WhenExecuteActionDelegate_RunWithoutParams_ShouldPrintSum(string resultExpected)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _actionExample.RunWithoutParams();

                sw.ToString().Should().Be(resultExpected);
            }
        }
    }
}
