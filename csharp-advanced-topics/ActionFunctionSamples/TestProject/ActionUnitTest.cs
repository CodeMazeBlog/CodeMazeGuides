using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class ActionUnitTest
    {
        [TestMethod]
        public void WhenShowExample_ThenCorrectOutput()
        {
            ActionSample.MyMethods.ShowActionExamples();
        }
    }
}