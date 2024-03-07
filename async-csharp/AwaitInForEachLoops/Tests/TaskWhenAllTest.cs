using AwaitInForEachLoop;

namespace Tests
{
    [TestFixture]
    public class TaskWhenAllInLoopTests
    {
        [Test]
        public async Task WhenResultAsync_ThenCompleteProcessingTasks()
        {
            // Act
            var result = await TaskWhenAllInLoop.ResultAsync();

            var processingTasks = result.Select(async task => await task.ConfigureAwait(false));
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.Count);

            // Check if all tasks are in a completed state (successful or faulted)
            Assert.IsTrue(result.All(task => task.IsCompleted));
        }
    }
}



