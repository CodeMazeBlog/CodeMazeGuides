namespace Tests
{
    [TestFixture]
    public class AwaitInLoopTests
    {
        [Test]
        public async Task WhenResultAsync_ThenProcessNumbersAsync()
        {
            // Arrange
            var expectedNumbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            // Act
            var result = await AwaitInLoops.ResultAsync(10);

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedNumbers, result);
        }
    }
}
