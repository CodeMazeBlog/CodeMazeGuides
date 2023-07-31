using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ActionandFuncDelegatesTest
{
    [TestClass]
    public class ActionandFuncDelegatesTest
    {
        [TestMethod]
        public void When_PrintMessage_Then_PrintGivenMessage()
        {
            // Arrange
            string expectedMessage = "Testing Action delegate";
            string actualMessage = null;

            // Act
            Action<string> actionDelegate = Program.PrintMessage;
            actionDelegate(expectedMessage);

            Assert.AreEqual(null, actualMessage);
        }

        [TestMethod]
        public void When_CalculateSquare_Then_ReturnSquareOfInputNumber()
        {
            // Arrange
            int inputNumber = 5;
            int expectedSquare = 25;

            // Act
            Func<int, int> funcDelegate = Program.CalculateSquare;
            int actualSquare = funcDelegate(inputNumber);

            // Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }
    }
}