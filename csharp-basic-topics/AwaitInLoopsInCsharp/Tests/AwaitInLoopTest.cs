
namespace AwaitInLoopsInCsharp.Tests
{
    [TestFixture]
    public class AwaitInLoopTests
    {
        [Test]
        public async Task WhenResultAsync_ThenReturnProcessedNumbers()
        {
            // Arrange
            var expectedNumbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            // Act
            var result = await AwaitInLoop.ResultAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<int>>(result);
            CollectionAssert.AreEqual(expectedNumbers, result);
        }
    }
}
