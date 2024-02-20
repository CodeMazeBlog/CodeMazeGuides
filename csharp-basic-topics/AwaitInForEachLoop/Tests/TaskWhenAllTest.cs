
using AwaitInForEachLoop;

namespace Tests
{
    [TestFixture]
    public class TaskWhenAllInLoopTests
    {
        [Test]
        public async Task GivenResultAsync_ThenProcessNumbersAsync()
        {
            // Arrange
            var expectedNumbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            // Act
            var result = await TaskWhenAllInLoop.ResultAsync();

            // Assert
            Assert.IsNotNull(result);

            CollectionAssert.AreEqual(expectedNumbers, result);
        }
    }
}

