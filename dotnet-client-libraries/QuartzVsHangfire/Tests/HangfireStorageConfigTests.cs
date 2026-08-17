using Hangfire;
using QuartzVsHangfire.HangfireSample;

namespace Tests;

[Collection("HangfireStorage")]
public class HangfireStorageConfigTests
{
    [Fact]
    public void WhenUseInMemory_ThenReturnsAConfiguredJobStorage()
    {
        var storage = HangfireStorageConfig.UseInMemory();

        Assert.NotNull(storage);
        Assert.Same(JobStorage.Current, storage);
    }
}
