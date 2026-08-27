namespace Tests;

public class ConversionTests
{
    [Fact]
    public async Task GivenATaskAndAValue_WhenWeConvertBetweenTaskAndValueTask_ThenBothDirectionsCarryTheSameResult()
    {
        Task<int> existingTask = Task.FromResult(42);

        ValueTask<int> fromTask = new ValueTask<int>(existingTask);
        ValueTask<int> fromValue = new ValueTask<int>(42);

        Task<int> backToTask = fromValue.AsTask();

        Assert.Equal(42, await fromTask);
        Assert.Equal(42, await backToTask);
    }
}
