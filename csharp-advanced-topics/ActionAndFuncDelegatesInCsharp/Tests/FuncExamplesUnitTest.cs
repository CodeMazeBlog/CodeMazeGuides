using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    [TestClass]
    public class FuncExamplesUnitTest
    {
        readonly StringWriter output;

        public FuncExamplesUnitTest()
        {
            output = new StringWriter();
            Console.SetOut(output);
        }

        [TestMethod]
        public void WhenCallingFuncWithAnonymouseMethod_ThenExpectedResult()
        {
            FuncExamples.FuncWithAnonymouseMethod();
            StringAssert.Contains(output.ToString(), "Hello David");
        }

        [TestMethod]
        public void WhenCallingFuncWithExpressionLambda_ThenExpectedResult()
        {
            FuncExamples.FuncWithExpressionLambda();
            StringAssert.Contains(output.ToString(), "15");
        }

        [TestMethod]
        public void WhenCallingFuncWithStatementLambda_ThenExpectedResult()
        {
            FuncExamples.FuncWithStatementLambda();
            StringAssert.Contains(output.ToString(), "30");
        }
    }
}