using ExpressionBodiedMembersInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void WhenCalculateAreaMethodCalled_AreaIsReturned()
        {
            var square = new Square(2);
            Assert.AreEqual(4, square.CalculateArea());
        }

        [TestMethod]
        public void WhenAreaPropertyIsGet_AreaIsReturned()
        {
            var square = new SquareRefactored(4);
            Assert.AreEqual(16, square.Area);
        }
    }
}
