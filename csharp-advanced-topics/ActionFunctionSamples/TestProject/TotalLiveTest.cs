using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TotalLiveTest
    {
        [TestMethod]
        public void WhenShowExamples_ThenCorrectOutputs()
        {
            FunctionSample.MyMethods.ShowFunctionExamples();

            ActionSample.MyMethods.ShowActionExamples();
        }
    }
}