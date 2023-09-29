using ActionDelegates;

namespace ActionAndFuncDelegatesUnitTests
{
    [TestClass]
    public class ActionDelegatesUnitTest
    {
        readonly StringWriter resultTextWriter;

        public ActionDelegatesUnitTest()
        {
            resultTextWriter = new StringWriter();
            Console.SetOut(resultTextWriter);
        }

        [TestMethod]
        public void GivenNoInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButConsoleMsg()
        {
            string expectedConsoleText = "Console text printed";
            Action printConsoleText = ActionHandler.GetConsoleText;

            printConsoleText(); // No Output expected,only message will be displayed

            Assert.AreEqual(resultTextWriter.ToString().Trim(), expectedConsoleText);

        }

        [TestMethod]
        public void GivenOneInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButUserDefinedConsoleMsg()
        {
            string expectedConsoleText = "User Defined Text - Testing Action Delegate";
            Action<string> printUserDefinedText = ActionHandler.GetUserDefinedText;

            printUserDefinedText("Testing Action Delegate"); // No Output expected,only message will be displayed

            Assert.AreEqual(resultTextWriter.ToString().Trim(), expectedConsoleText);
        }

        [TestMethod]
        public void GivenTwoInputParameters_WhenInvokingActionDelegate_ThenExpectedNoOutputButUserDefinedMsg()
        {
            string expectedConsoleText = "User Defined Numbers -  1 2 3 4 5";
            Action<int, int> PrintUserDefinedNumbers = ActionHandler.GetUserDefinedNumbers;

            PrintUserDefinedNumbers(1, 5); // No Output expected,only message will be displayed

            Assert.AreEqual(resultTextWriter.ToString().Trim(), expectedConsoleText);
        }
    }
}