using CSharp_Action_Delegate;

namespace CSharpActionDelegateTests
{
    [TestClass]
    internal class LambdaActionDelegateTest
    {
        [TestMethod]
        public void BmiWithNonGenericAction_ReturnsCorrectBmi()
        {
            // Arrange
            double expectedBmi = 24.49; 

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                LambdaActionDelegate actionDelegate = new LambdaActionDelegate();
                actionDelegate.BmiWithNonGenericAction(); 
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
            Console.SetOut(oldConsoleOut); 
        }

        [TestMethod]
        public void BmiWithGenericAction_ReturnsCorrectBmi()
        {
            // Arrange
            double height = 175d;
            double weight = 75d;
            double expectedBmi = 24.49; 

            // Act
            var oldConsoleOut = Console.Out; 
            using (var consoleOutput = new ConsoleOutput()) 
            {
                LambdaActionDelegate actionDelegate = new LambdaActionDelegate();
                actionDelegate.BmiWithGenericAction(height, weight); 
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

            Console.SetOut(oldConsoleOut);
        }
    }
}
