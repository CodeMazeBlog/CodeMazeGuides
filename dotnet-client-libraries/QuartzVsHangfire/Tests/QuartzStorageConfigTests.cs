using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzStorageConfigTests
{
    [Fact]
    public async Task WhenCreateInMemoryScheduler_ThenReturnsAUsableScheduler()
    {
        var scheduler = await QuartzStorageConfig.CreateInMemorySchedulerAsync();

        Assert.NotNull(scheduler);
    }
}
