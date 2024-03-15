namespace CSharpActionDelegateTests
{
    using CSharp_Action_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    internal class LambdaActionDelegateTest
    {
        [TestMethod]
        public void WhenNonGenericAction_ThenActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var expectedBmi = 24.49;
            var actionDelegate = new LambdaActionDelegate();

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                actionDelegate.BmiWithNonGenericAction();
                var consoleOutputText = consoleOutput.GetOutput();
                var lines = consoleOutputText.Split(Environment.NewLine);
                var bmiOutputLine = lines[0];
                var parts = bmiOutputLine.Split(" : ");
                var bmiValueStr = parts[1].Trim('.');
                double actualBmi;
                var parseSuccess = double.TryParse(bmiValueStr, out actualBmi);

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in the correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }
            Console.SetOut(oldConsoleOut);
        }

        [TestMethod]
        public void WhenGenericAction_ThenActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var height = 175d;
            var weight = 75d;
            var expectedBmi = 24.49;
            var actionDelegate = new LambdaActionDelegate();

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                actionDelegate.BmiWithGenericAction(height, weight);
                var consoleOutputText = consoleOutput.GetOutput();
                var lines = consoleOutputText.Split(Environment.NewLine);
                var bmiOutputLine = lines[0];
                var parts = bmiOutputLine.Split(" : ");
                var bmiValueStr = parts[1].Trim('.');
                double actualBmi;
                var parseSuccess = double.TryParse(bmiValueStr, out actualBmi);

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in the correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }

            Console.SetOut(oldConsoleOut);
        }
    }
}
