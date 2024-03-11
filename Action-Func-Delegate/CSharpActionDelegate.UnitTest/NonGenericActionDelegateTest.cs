using CSharp_Action_Delegate;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CSharpActionDelegate.UnitTest
{
    [TestClass]
    public class NonGenericActionDelegateTest
    {
        [TestMethod]
        public void ProcessBmi_ReturnsCorrectBmi()
        {
            double expectedBmi = 24.49;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                NonGenericActionDelegate nonGenericActionDelegate = new NonGenericActionDelegate();
                nonGenericActionDelegate.ProcessBmi();
                string consoleOutputText = consoleOutput.GetOutput();
                string[] lines = consoleOutputText.Split(Environment.NewLine);
                string bmiOutputLine = lines[0];
                string[] parts = bmiOutputLine.Split(" : ");

                string bmiValueStr = parts[1].Trim('.');
                double actualBmi;
                bool parseSuccess = double.TryParse(bmiValueStr, out actualBmi);

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }
            // Restore the original Console.Out
            Console.SetOut(oldConsoleOut); 
        }
    }
}