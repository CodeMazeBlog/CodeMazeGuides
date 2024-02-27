

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
            var processingTasks = await TaskWhenAllInLoop.ResultAsync();

            // Assert
            Assert.IsNotNull(processingTasks);
            Assert.AreEqual(9, processingTasks.Count);

            // Check if all tasks are in a completed state (successful or faulted)
            Assert.IsTrue(processingTasks.All(task => task.IsCompleted));
        }
    }
}



