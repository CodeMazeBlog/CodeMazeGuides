namespace CSharpActionDelegateTests
{
    using CSharp_Action_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GenericActionDelegateTest
    {
        [TestMethod]
        public void WhenGenericAction_ThenActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var height = 175d;
            var weight = 75d;
            var expectedBmi = 24.49;
            var genericActionDelegate = new GenericActionDelegate();
            var processBmiWithGenericAction = genericActionDelegate.ProcessBmi;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                processBmiWithGenericAction(height, weight);
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
        public void GivenGenericAction_WhenZeroHeight_ThenActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var height = 0d;
            var weight = 75d;
            var genericActionDelegate = new GenericActionDelegate();
            var processBmiWithGenericAction = genericActionDelegate.ProcessBmi;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                processBmiWithGenericAction(height, weight);
                var consoleOutputText = consoleOutput.GetOutput();
                var bmiOutputLine = consoleOutputText.Trim();
                var expectedOutput = "The BMI is : 0.00.";

                // Assert
                Assert.AreEqual(expectedOutput, bmiOutputLine, "BMI output is not as expected");
            }
            Console.SetOut(oldConsoleOut);
        }

        [TestMethod]
        public void GivenGenericAction_WhenZeroWeight_ThenActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var height = 175d;
            var weight = 0d;
            var genericActionDelegate = new GenericActionDelegate();
            var processBmiWithGenericAction = genericActionDelegate.ProcessBmi;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                processBmiWithGenericAction(height, weight);
                var consoleOutputText = consoleOutput.GetOutput();
                var bmiOutputLine = consoleOutputText.Trim();
                var expectedOutput = "The BMI is : 0.00.";

                // Assert
                Assert.AreEqual(expectedOutput, bmiOutputLine, "BMI output is not as expected");
            }
            Console.SetOut(oldConsoleOut);
        }
    }
}
