using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncActionDelegatesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FuncDelegate()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ActionDelegate()
        {
            Assert.IsTrue(true);
        }
    }
}