using Action_Func;
using Xunit;

namespace ActionFunc.Test
{
    public class ActionTests
    {
        private readonly StringWriter consoleOutput;

        public ActionTests()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [Fact]
        public void WhenGivenTwoNumbersToCalculate_ThenPrintsCorrectArithmeticResults()
        {
            // Arrange
            var firstNum = 10;
            var secondNum = 5;

            // Act
            ActionExample.Calculate(firstNum, secondNum);

            // Assert
            var expectedOutput = $"Sum of the {firstNum} and {secondNum} is: {firstNum + secondNum}" +
                                 Environment.NewLine +
                                 $"Subtract of the {firstNum} from {secondNum} is: {firstNum - secondNum}" +
                                 Environment.NewLine +
                                 $"Product of the {firstNum} and {secondNum} is: {firstNum * secondNum}" +
                                 Environment.NewLine +
                                 $"Division of the {firstNum} and {secondNum} is {firstNum / secondNum}" +
                                 Environment.NewLine;

            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }
    }
}
