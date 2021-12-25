using ExpressionBodiedMembersInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class StaffTests
    {
        [TestMethod]
        public void WhenReadingIndexedProperty_NameIsReturned()
        {
            var staff = new Staff();
            Assert.AreEqual("John", staff[0]);
        }

        [TestMethod]
        public void WhenSettingIndexedProperty_NewNameIsReturned()
        {
            var staff = new Staff();
            staff[0] = "Camille";
            Assert.AreEqual("Camille", staff[0]);
        }
    }
}
