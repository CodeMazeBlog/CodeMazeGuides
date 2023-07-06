namespace TaskCompletedVsReturnInCSharpTests
{
    public class TaskCompletedClassAndReturnClassTests
    {
        [Fact]
        public void WhenCallingUseTaskCompletedMethodAsync_ThenUseTaskCompleted()
        {
            TaskCompletedClass taskCompletedClass = new TaskCompletedClass();

            Task result = taskCompletedClass.UseTaskCompletedMethodAsync();

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public async Task WhenCallingUseReturnMethodAsync_ThenUseReturn()
        {
            ReturnClass returnClass = new ReturnClass();

            var result = await returnClass.UseReturnMethodAsync();

            Assert.Equal(20, result);
        }
    }
}