namespace ActionAndFuncDelegatesInCSharp.Test
{
    [TestClass]
    internal class CalculationSumTests
    {
        // Func delegate
        private Func<int, int, int> CalculateSum = (int x, int y) => x + y;

        [TestMethod]
        public void CalculateSum_ValidInput_ReturnsSum()
        {
            // Arrange - Setting up the test
            int expectedSum = 30;

            // Act - Invoking the Func delegate
            int result = CalculateSum(10, 20);

            // Assert - Verifying the result matches the expected sum
            Assert.AreEqual(expectedSum, result);
        }
    }
}
