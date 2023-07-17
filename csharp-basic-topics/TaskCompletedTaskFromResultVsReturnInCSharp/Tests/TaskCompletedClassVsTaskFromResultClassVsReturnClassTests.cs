namespace TaskCompletedVsTaskFromResultVsReturnInCSharpTests
{
    public class TaskCompletedClassVsTaskFromResultClassVsReturnClassTests
    {
        [Fact]
        public void WhenCallingUseTaskCompletedMethodAsync_ThenUseTaskCompleted()
        {
            TaskCompletedClass taskCompletedClass = new TaskCompletedClass();

            var result = taskCompletedClass.UseTaskCompletedMethodAsync();

            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public async Task WhenCallingUseTaskFromResultMethodAsync_ThenUseFromResult()
        {
            TaskFromResultClass taskFromResultClass = new TaskFromResultClass();

            var result =  taskFromResultClass.UseTaskFromResultMethodAsync();
            string message = await result;

            Assert.Equal("Hello, world!", message);
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