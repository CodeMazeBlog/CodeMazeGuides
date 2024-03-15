namespace CSharpActionDelegateTests
{
    using CSharp_Action_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NonGenericActionDelegateTest
    {
        [TestMethod]
        public void WhenNonGenericAction_ThenActionDelegateExecutesTheReferencedMethod()
        {
            var expectedBmi = 24.49;
            var nonGenericActionDelegate = new NonGenericActionDelegate();
            var processBmiWithNonGenericAction = nonGenericActionDelegate.ProcessBmi;

            // Act
            var oldConsoleOut = Console.Out;
            using (var consoleOutput = new ConsoleOutput())
            {
                processBmiWithNonGenericAction();
                var consoleOutputText = consoleOutput.GetOutput();
                var lines = consoleOutputText.Split(Environment.NewLine);
                var bmiOutputLine = lines[0];
                var parts = bmiOutputLine.Split(" : ");

                var bmiValueStr = parts[1].Trim('.');
                double actualBmi;
                var parseSuccess = double.TryParse(bmiValueStr, out actualBmi);

                // Assert
                Assert.IsTrue(parseSuccess, "BMI value is not in correct format");
                Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
            }

            Console.SetOut(oldConsoleOut);
        }
    }
}