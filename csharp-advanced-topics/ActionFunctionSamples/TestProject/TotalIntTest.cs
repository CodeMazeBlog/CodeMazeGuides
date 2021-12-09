using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TotalIntTest
    {
        [TestMethod]
        public void WhenShowExamples_ThenCorrectOutputs()
        {
            FunctionSample.MyMethods.ShowFunctionExamples();

            ActionSample.MyMethods.ShowActionExamples();
        }
    }
}