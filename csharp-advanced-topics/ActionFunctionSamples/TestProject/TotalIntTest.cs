using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TotalIntTest
    {
        [TestMethod]
        public void WhenShowExamples_ThenCorrectOutputs()
        {
            new FunctionUnitTest().WhenShowExample_ThenCorrectOutput();
            new ActionUnitTest().WhenShowExample_ThenCorrectOutput();
        }
    }
}