using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    [TestClass]
    public class DelegateExampleUnitTest
    {
        readonly StringWriter output;

        public DelegateExampleUnitTest()
        {
            output = new StringWriter();
            Console.SetOut(output);
        }

        [TestMethod]
        public void WhenCallingFuncWithAnonymouseMethod_ThenExpectedResult()
        {
            DelegateExample.SendMailDelegate();
            StringAssert.Contains(output.ToString(), "Message has been sent successfully!");
        }
    }
}