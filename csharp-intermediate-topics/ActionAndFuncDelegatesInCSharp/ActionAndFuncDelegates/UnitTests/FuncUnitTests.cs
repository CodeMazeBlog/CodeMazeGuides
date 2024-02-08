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
            await Task.Delay(milliseconds); // Simulate some async work
            throw new Exception("I will not break your application."); // simulate exception
        };

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() => awaitableFunc(1000));

        //Assert
        Assert.NotNull(exception);
    }
}
