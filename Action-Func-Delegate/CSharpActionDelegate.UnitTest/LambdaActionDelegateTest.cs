using CSharp_Action_Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpActionDelegate.UnitTest
{
    [TestClass]
    internal class LambdaActionDelegateTest
    {
        [TestMethod]
        public void BmiWithNonGenericAction_ReturnsCorrectBmi()
        {
            // Arrange
            double expectedBmi = 24.49; // Expected BMI for height: 175cm, weight: 75kg

            // Act
            var oldConsoleOut = Console.Out; // Store the original Console.Out
            using (var consoleOutput = new ConsoleOutput()) // Redirect Console.Out for testing
            {
                LambdaActionDelegate actionDelegate = new LambdaActionDelegate();
                actionDelegate.BmiWithNonGenericAction(); // Call the method under test
                string consoleOutputText = consoleOutput.GetOutput(); // Get the output from Console.Out
                string[] lines = consoleOutputText.Split(Environment.NewLine); // Split lines
                string bmiOutputLine = lines[0]; // Get the first line which should contain BMI
                string[] parts = bmiOutputLine.Split(" : "); // Split line into parts
                string bmiValueStr = parts[1].Trim('.'); // Get the value part and trim whitespace
                double actualBmi;
                bool parseSuccess = double.TryParse(bmiValueStr, out actualBmi); // Parse the BMI value

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in the correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }
            Console.SetOut(oldConsoleOut); // Restore the original Console.Out
        }

        [TestMethod]
        public void BmiWithGenericAction_ReturnsCorrectBmi()
        {
            // Arrange
            double height = 175d;
            double weight = 75d;
            double expectedBmi = 24.49; // Expected BMI for height: 175cm, weight: 75kg

            // Act
            var oldConsoleOut = Console.Out; // Store the original Console.Out
            using (var consoleOutput = new ConsoleOutput()) // Redirect Console.Out for testing
            {
                LambdaActionDelegate actionDelegate = new LambdaActionDelegate();
                actionDelegate.BmiWithGenericAction(height, weight); // Call the method under test
                string consoleOutputText = consoleOutput.GetOutput(); // Get the output from Console.Out
                string[] lines = consoleOutputText.Split(Environment.NewLine); // Split lines
                string bmiOutputLine = lines[0]; // Get the first line which should contain BMI
                string[] parts = bmiOutputLine.Split(" : "); // Split line into parts
                string bmiValueStr = parts[1].Trim('.'); // Get the value part and trim whitespace
                double actualBmi;
                bool parseSuccess = double.TryParse(bmiValueStr, out actualBmi); // Parse the BMI value

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in the correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }

            Console.SetOut(oldConsoleOut); // Restore the original Console.Out
        }
    }
}
