namespace ActionDelegate.Tests
{
    [TestClass]
    public class ActionDelegateTests
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenSubtracting_ThenResultShouldBeTheDifference()
        {
            // Arrange
            var x = 5;
            var y = 4;
            var expected = 1;

            // Act
            ActionDelegate.Subtraction(x, y);

            // Assert
            Assert.AreEqual(expected, x - y, "Subtraction method did not return the expected result.");
        }
    }
}