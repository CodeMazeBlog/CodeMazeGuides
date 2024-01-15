using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks.Dataflow;

namespace ActionFuncDelegatesUnitTest
{
    [TestClass]
    public class ActionFuncDelegatesTest
    {
        [TestMethod]
        public void WhenDelegateGetValue_ThenShowValue()
        {
            var result = DelegatesTypes.Program.number;
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void WhenDelegateGetInvalidValue_ThenShowValue()
        {
            var result = DelegatesTypes.Program.number;
            Assert.AreNotEqual(10, result);
        }    
    }
}