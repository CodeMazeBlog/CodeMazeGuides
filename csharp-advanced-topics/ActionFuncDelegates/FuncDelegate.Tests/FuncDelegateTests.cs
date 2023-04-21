namespace FuncDelegate.Tests
{
    [TestClass]
    public class FuncDelegateTests
    {
        [TestMethod]
        public void GivenTwoIntegers_WhenMultiplicationIsPerformed_ThenResultShouldBeCorrect()
        {
            // Arrange
            var x = 5;
            var y = 4;
            var expected = 20;
            Func<int, int, int> testFunc = FuncDelegate.Multiplication;

            // Act
            var result = testFunc(x, y);

            // Assert
            Assert.AreEqual(expected, result, "Multiplication method did not return the expected result.");
        }
    }
}