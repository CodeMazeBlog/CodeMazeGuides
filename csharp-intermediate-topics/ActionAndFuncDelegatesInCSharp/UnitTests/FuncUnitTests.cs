namespace UnitTests;

using Xunit;

public class FuncUnitTests
{
    [Fact]
    public async Task GivenExceptionIsThrown_WhenTaskReturningFuncIsAwaited_ThenTheExceptionIsCaughtByOuterTryCatchBlock()
    {
        // Arrange
        Func<int, Task> awaitableFunc = async (milliseconds) =>
        {
            await Task.Delay(milliseconds);
            throw new Exception("I will not break your application.");
        };

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() => awaitableFunc(1000));

        //Assert
        Assert.NotNull(exception);
    }
}
