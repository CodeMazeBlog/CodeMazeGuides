using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        readonly StringWriter ActualReturnConsoleText;

        public ActionAndFuncDelegatesUnitTest()
        {
            ActualReturnConsoleText = new StringWriter();
            Console.SetOut(ActualReturnConsoleText);
        }


        [TestMethod]
        public void GivenNoInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButConsoleMsg()
        {
            string expectedConsoleText = "Console text printed";
            Action printConsoleText = MethodService.GetConsoleText;
            printConsoleText(); // No Output expected,only message will be displayed
            Assert.AreEqual(ActualReturnConsoleText.ToString().Trim(), expectedConsoleText);

        }
        [TestMethod]
        public void GivenOneInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButUserDefinedConsoleMsg()
        {
            string expectedConsoleText = "User Defined Text - Testing Action Delegate";
            Action<string> printUserDefinedText = MethodService.GetUserDefinedText;
            printUserDefinedText("Testing Action Delegate"); // No Output expected,only message will be displayed
            Assert.AreEqual(ActualReturnConsoleText.ToString().Trim(), expectedConsoleText);
        }
        [TestMethod]
        public void GivenTwoInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButUserDefinedMsg()
        {
            string expectedConsoleText = "User Defined Numbers -  1 2 3 4 5";
            Action<int, int> PrintUserDefinedNumbers = MethodService.GetUserDefinedNumbers;
            PrintUserDefinedNumbers(1,5); // No Output expected,only message will be displayed
            Assert.AreEqual(ActualReturnConsoleText.ToString().Trim(), expectedConsoleText);
        }
        [TestMethod]
        public void GivenNoInputParameters_WhenInvokingFuncDelegate_ThenExpectedRandomNumberOutputInteger()
        {

            int notExpectedOutputFromMethod = 105;
            Func<int> PrintRandomNumber = MethodService.GetRandomNumber;
            int min = 1;
            int max = 100;
            int outputResult = PrintRandomNumber();
            Assert.IsTrue(outputResult >= min && outputResult <= max);
            Assert.AreNotEqual(outputResult, notExpectedOutputFromMethod);
        }
        [TestMethod]
        public void GivenThreeInputParameters_WhenInvokingFuncDelegate_ThenExpectedAllStringConcatenatedOutput()
        {
            string expectedOutputFromMethod = "First-Second-Third";
            Func<string, string, string, string> PrintReturnNames = MethodService.GetNamesReturn;
            string outputResult = PrintReturnNames("First", "Second", "Third");
            Assert.AreEqual(outputResult, expectedOutputFromMethod);
        }
    }
}