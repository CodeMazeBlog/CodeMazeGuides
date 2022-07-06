using ActionAndFuncDelegatesInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncDelegateInCSharp_MSTest
{
    [TestClass]
    public class RunExamplesUnitTest
    {

        [TestMethod]
        public void WhenRunningFirstMethod_ThenExecutionOK()
        {
            RunExamples rEx = new RunExamples();

            rEx.RunFirstMethodExample();
        }


        [TestMethod]
        public void WhenRunningSecondMethod_ThenExecutionOK()
        {
            RunExamples rEx = new RunExamples();

            rEx.RunSecondMethodExample();
        }


        [TestMethod]
        public void WhenRunningThirdMethod_ThenReturnMsgIsHelloWorldFromThirdMethod()
        {
            RunExamples rEx = new RunExamples();

            var msg = rEx.RunThirdMethodExample();

            Assert.AreEqual(msg, "hello from third method!");
        }


        [TestMethod]
        public void WhenRunningFourthMethod_ThenReturnMsgIsAsExpected()
        {
            RunExamples rEx = new RunExamples();

            var msg = rEx.RunFourthMethodExample();

            Assert.AreEqual(msg, "Fourth Method says: Hello Henry Johnson. You live in NY. You are 32 old.");
        }

    }
}