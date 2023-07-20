namespace TaskCompletedVsTaskFromResultVsReturnInCSharpTests;

public class TaskCompletedClassVsTaskFromResultClassVsReturnClassTests
{
    [Fact]
    public void WhenCallingUseTaskCompletedMethodAsync_ThenUseTaskCompleted()
    {
        var taskCompletedClass = new TaskCompletedClass();

        var result = taskCompletedClass.UseTaskCompletedMethodAsync();

        Assert.True(result.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task WhenCallingUseTaskFromResultMethodAsync_ThenUseFromResult()
    {
        var taskFromResultClass = new TaskFromResultClass();

        var result =  taskFromResultClass.UseTaskFromResultMethodAsync();
        var message = await result;

        Assert.Equal("Hello, world!", message);
    }

    [Fact]
    public async Task WhenCallingUseReturnMethodAsync_ThenUseReturn()
    {
        var returnClass = new ReturnClass();

        var result = await returnClass.UseReturnMethodAsync();

        Assert.Equal(20, result);
    }
}