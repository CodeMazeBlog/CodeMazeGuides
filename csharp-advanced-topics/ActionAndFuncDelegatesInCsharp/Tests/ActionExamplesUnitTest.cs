using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    [TestClass]
    public class ActionExamplesUnitTest
    {
        private readonly StringWriter output;

        public ActionExamplesUnitTest()
        {
            output = new StringWriter();
            Console.SetOut(output);
        }

        [TestMethod]
        public void WhenCallingActionWithAnonymouseMethod_ThenExpectedResult()
        {
            ActionExamples.ActionWithAnonymouseMethod();
            StringAssert.Contains(output.ToString(), "Hello David");
        }

        [TestMethod]
        public void WhenCallingActionWithExpressionLambda_ThenExpectedResult()
        {
            ActionExamples.ActionWithExpressionLambda();
            StringAssert.Contains(output.ToString(), "7");
        }

        [TestMethod]
        public void WhenCallingActionWithStatementLambda_ThenExpectedResult()
        {
            ActionExamples.ActionWithStatementLambda();
            StringAssert.Contains(output.ToString(), "30");
        }
    }
}