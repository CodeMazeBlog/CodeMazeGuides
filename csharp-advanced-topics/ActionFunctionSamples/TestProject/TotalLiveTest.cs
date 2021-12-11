using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TotalLiveTest
    {
        [TestMethod]
        public void WhenShowExamples_ThenCorrectOutputs()
        {
            new TotalIntTest().WhenShowExamples_ThenCorrectOutputs();
        }
    }
}