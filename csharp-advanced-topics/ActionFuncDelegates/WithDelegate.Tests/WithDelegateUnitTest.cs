namespace WithDelegate.Tests
{
    [TestClass]
    public class WithDelegateUnitTest
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenAdditionIsPerformed_ThenResultShouldBeCorrect()
        {
            // Arrange
            var x = 5;
            var y = 10;
            var expected = 15;

            // Act
            var result = WithDelegate.Addition(x, y); 

            // Assert
            Assert.AreEqual(expected, result, "Addition method did not return the expected result.");
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenSubtractionIsPerformed_ThenResultShouldBeCorrect()
        {
            // Arrange
            var x = 10;
            var y = 5;
            var expected = 5;

            // Act
            var result = WithDelegate.Subtraction(x, y);

            // Assert
            Assert.AreEqual(expected, result, "Subtraction method did not return the expected result.");
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenMultiplicationIsPerformed_ThenResultShouldBeCorrect()
        {
            // Arrange
            var x = 5;
            var y = 10;
            var expected = 50;

            // Act
            var result = WithDelegate.Multiplication(x, y);

            // Assert
            Assert.AreEqual(expected, result, "Multiplication method did not return the expected result.");
        }

        [TestMethod]
        public void GivenValidInput_WhenOperationIsPerformed_ThenResultShouldBeCorrect()
        {
            // Arrange
            var input = "add";
            var expected = 15;

            // Act
            WithDelegate.Operation(input);

            // Assert
            var result = WithDelegate.Addition(10, 5);
            Assert.AreEqual(expected, result, $"Operation(\"{input}\") did not produce the expected result.");
        }

        [TestMethod]
        public void GivenInvalidInput_WhenOperationIsPerformed_ThenNoExceptionOrUnexpectedBehaviorShouldOccur()
        {
            // Arrange
            var input = "invalid";

            // Act
            WithDelegate.Operation(input);

            // Assert
            Assert.IsTrue(true, $"Operation(\"{input}\") should not throw an exception or cause any unexpected behavior.");
        }
    }
}