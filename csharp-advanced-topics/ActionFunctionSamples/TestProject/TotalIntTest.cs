using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class TotalIntTest
    {
        [TestMethod]
        public void WhenShowExamples_ThenCorrectOutputs()
        {
            FunctionSample.FuncMethods.ShowFunctionExamples();

            ActionSample.ActionMethods.ShowActionExamples();
        }
    }
}