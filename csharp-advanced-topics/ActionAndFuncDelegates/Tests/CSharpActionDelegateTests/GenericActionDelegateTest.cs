using CSharp_Action_Delegate;

namespace CSharpActionDelegateTests
{
    [TestClass]
    public class GenericActionDelegateTest
    {
        [TestMethod]
        public void ProcessBmi_WithValidInput_ReturnsCorrectBmi()
        {
            // Arrange
            double height = 175d;
            double weight = 75d;
            double expectedBmi = 24.49;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                GenericActionDelegate genericActionDelegate = new GenericActionDelegate();
                genericActionDelegate.ProcessBmi(height, weight);
                string consoleOutputText = consoleOutput.GetOutput();
                string[] lines = consoleOutputText.Split(Environment.NewLine);
                string bmiOutputLine = lines[0];
                string[] parts = bmiOutputLine.Split(" : ");
                string bmiValueStr = parts[1].Trim('.');
                double actualBmi;
                bool parseSuccess = double.TryParse(bmiValueStr, out actualBmi);

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in the correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }
            Console.SetOut(oldConsoleOut); // Restore the original Console.Out
        }

        [TestMethod]
        public void ProcessBmi_WithZeroHeight_ReturnsZeroBmi()
        {
            // Arrange
            double height = 0d;
            double weight = 75d;

            // Act
            var oldConsoleOut = Console.Out; 
            using (var consoleOutput = new ConsoleOutput()) 
            {
                GenericActionDelegate genericActionDelegate = new GenericActionDelegate();
                genericActionDelegate.ProcessBmi(height, weight); 
                string consoleOutputText = consoleOutput.GetOutput();
                string bmiOutputLine = consoleOutputText.Trim(); 
                string expectedOutput = "The BMI is : 0.00.";

                // Assert
                Assert.AreEqual(expectedOutput, bmiOutputLine, "BMI output is not as expected");
            }
            Console.SetOut(oldConsoleOut);
        }

        [TestMethod]
        public void ProcessBmi_WithZeroWeight_ReturnsZeroBmi()
        {
            // Arrange
            double height = 175d;
            double weight = 0d;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                GenericActionDelegate genericActionDelegate = new GenericActionDelegate();
                genericActionDelegate.ProcessBmi(height, weight);
                string consoleOutputText = consoleOutput.GetOutput();
                string bmiOutputLine = consoleOutputText.Trim();
                string expectedOutput = "The BMI is : 0.00.";

                // Assert
                Assert.AreEqual(expectedOutput, bmiOutputLine, "BMI output is not as expected");
            }
            Console.SetOut(oldConsoleOut);
        }
    }
}
