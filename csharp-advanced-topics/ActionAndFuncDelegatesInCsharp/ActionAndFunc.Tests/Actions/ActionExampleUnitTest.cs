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
        [InlineData(2, 2, "Sum result(with parameters): 4")]
        [InlineData(5, 2, "Sum result(with parameters): 7")]
        [InlineData(-2, 2, "Sum result(with parameters): 0")]
        public void WhenExecuteActionDelegate_RunWithParams_ShouldPrintSum(int numberInput1, int numberInput2, string resultExpected)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _actionExample.RunWithParams(numberInput1, numberInput2);

                sw.ToString().Should().Contain(resultExpected);
            }
        }

        [Theory]
        [InlineData("Sum result(no parameters): 10")]
        public void WhenExecuteActionDelegate_RunWithoutParams_ShouldPrintSum(string resultExpected)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _actionExample.RunWithoutParams();

                sw.ToString().Should().Contain(resultExpected);
            }
        }
    }
}
