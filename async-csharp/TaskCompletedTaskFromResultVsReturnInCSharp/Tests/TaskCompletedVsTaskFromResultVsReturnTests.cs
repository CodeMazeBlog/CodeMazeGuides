namespace TaskCompletedVsTaskFromResultVsReturnInCSharpTests;

public class TaskCompletedVsTaskFromResultVsReturnTests
{
    [Fact]
    public void WhenCallingUseTaskCompletedAsync_ThenUseTaskCompleted()
    {
        var taskCompletedClass = new TaskCompletedHandler();

        var result = taskCompletedClass.UseTaskCompletedAsync();

        Assert.True(result.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task WhenCallingUseTaskFromResultAsync_ThenUseFromResult()
    {
        var taskFromResultClass = new TaskFromResultHandler();

        var message =  await taskFromResultClass.UseTaskFromResultAsync();

        Assert.Equal("Hello, world!", message);
    }

    [Fact]
    public async Task WhenCallingUseReturnAsync_ThenUseReturn()
    {
        var returnClass = new ReturnHandler();

        var result = await returnClass.UseReturnAsync();

        Assert.Equal(20, result);
    }
}