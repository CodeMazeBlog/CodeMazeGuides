using FuncDelegates;

namespace ActionAndFuncDelegatesUnitTests
{
    [TestClass]
    public class FuncDelegatesUnitTest
    {
        readonly StringWriter resultTextWriter;

        public FuncDelegatesUnitTest()
        {
            resultTextWriter = new StringWriter();
            Console.SetOut(resultTextWriter);
        }

        [TestMethod]
        public void GivenNoInputParameters_WhenInvokingFuncDelegate_ThenExpectedRandomNumberOutputInteger()
        {
            int notExpectedOutputFromMethod = 105;
            int min = 1;
            int max = 100;
            Func<int> PrintRandomNumber = FuncHandler.GetRandomNumber;

            int outputResult = PrintRandomNumber(); // Integer output expected

            Assert.IsTrue(outputResult >= min && outputResult <= max);
            Assert.AreNotEqual(outputResult, notExpectedOutputFromMethod);
        }

        [TestMethod]
        public void GivenThreeInputParameters_WhenInvokingFuncDelegate_ThenExpectedAllStringConcatenatedOutput()
        {
            string expectedOutputFromMethod = "First-Second-Third";
            Func<string, string, string, string> PrintReturnNames = FuncHandler.GetNamesReturn;

            string outputResult = PrintReturnNames("First", "Second", "Third"); // Concatenated string expected

            Assert.AreEqual(outputResult, expectedOutputFromMethod);
        }
    }
}