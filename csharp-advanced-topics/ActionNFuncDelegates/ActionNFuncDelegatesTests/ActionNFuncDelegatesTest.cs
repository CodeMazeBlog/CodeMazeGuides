using ActionNFuncDelegates.Delegates;
using ActionNFuncDelegates.Interfaces;

namespace ActionNFuncDelegatesTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GivenANumber_WhenFuncDelegateInvoked_ThenReturnCorrectSquare()
        {
            // Arrange
            IFunctionDelegate<int, int> squareDelegate = new FunctionDelegate<int, int>(SquareWrapper.Square);

            // Act
            int result = squareDelegate.Execute(5);

            // Assert
            Assert.AreEqual(25, result);
        }
    }
}