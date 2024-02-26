

namespace AwaitInLoopsInCsharp.Tests
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

            foreach (var task in processingTasks)
            {
                Assert.IsTrue(task.IsCompletedSuccessfully, $"Task failed: {task.Exception?.ToString()}");
            }
        }
    }
}
