
namespace ActionFuncDelegates.Tests
{
    public class ActionDelegatesTests
    {
        [Fact]
        public void GivenActionDelegate_WhenCallingActionDelegate_ThenCorrectOutputsArePrinted()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegate();

                // Assert
                var consoleOutput = sw.ToString();
                Assert.Contains("Add Inputs: 30", consoleOutput);
                Assert.Contains("Subtract Inputs: 10", consoleOutput);
            }
        }

        [Fact]
        public void GivenActionDelegateWithAnonymous_WhenCallingActionDelegateWithAnonymous_ThenCorrectOutputsArePrinted()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegateWithAnonymous();

                // Assert
                var consoleOutput = sw.ToString();
                Assert.Contains("Subtract = 20", consoleOutput);
            }
        }

        [Fact]
        public void GivenActionDelegateWithLambda_WhenCallingActionDelegateWithLambda_ThenCorrectResultIsPrinted()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegateWithLambda();

                // Assert
                var consoleOutput = sw.ToString();
                Assert.Contains("Result: 10", consoleOutput);
            }
        }
    }
}
