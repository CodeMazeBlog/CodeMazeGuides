using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegates;
namespace DelegateTests
{
    [TestClass]
    public class DelegateUnitTests
    {
        [TestMethod]
        public void TestCalcProduct()
        {
            int first = 20;
            int second = 20;
            int expected = 400;
            int actual = Program.CalcProduct(first, second);
            Assert.AreEqual(expected, actual);
        }
    }
}
