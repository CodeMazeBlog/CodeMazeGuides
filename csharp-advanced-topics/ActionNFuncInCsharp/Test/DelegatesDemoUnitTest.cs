using DelegatesDemo.Delegates;
using DelegatesDemo.Interfaces;
using NUnit.Framework;

namespace DelegatesDemo.Test
{
    [TestFixture]
    public class DelegateDemoTest
    {
        [Test]
        public void Test_SquareDelegate()
        {
            // Arrange
            IFunctionDelegate<int, int> squareDelegate = new FunctionDelegate<int, int>(Square);

            // Act
            int result = squareDelegate.Execute(5);

            // Assert
            Assert.AreEqual(25, result);
        }

        // Define a Func delegate that represents a method with one parameter (int) and a return value (int)
        static int Square(int a)
        {
            return a * a;
        }
    }
}
