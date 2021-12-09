using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class FunctionUnitTest
    {
        [TestMethod]
        public void WhenShowExample_ThenCorrectOutput()
        {
            FunctionSample.FuncMethods.ShowFunctionExamples();
        }
    }
}