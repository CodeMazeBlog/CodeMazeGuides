using ExecuteCliExample;

namespace ExecuteCliExampleTest;

public class DotnetNativeWrapperTests
{
    [Fact]
    public async Task WhenGetVersionIsInvoked_ThenVersionIsNotNull()
    {
        DotnetNativeWrapper wrapper = new();
        var version = await wrapper.GetVersion();

        Assert.NotNull(version);
    }

    [Fact]
    public async Task WhenRunInvalidCommandIsInvoked_ThenExitCodeIsNotZero()
    {
        DotnetNativeWrapper wrapper = new();
        var (exitCode, _) = await wrapper.RunInvalidCommand();

        Assert.NotEqual(exitCode, 0);
    }

    [Fact]
    public async Task WhenRunInvalidCommandIsInvoked_ThenErrorIsNotEmpty()
    {
        DotnetNativeWrapper wrapper = new();
        var (_, error) = await wrapper.RunInvalidCommand();

        Assert.True(!string.IsNullOrWhiteSpace(error));
    }

    [Fact]
    public async Task WhenGetInfoIsInvoked_ThenNonEmptyDotnetSdkInfoIsReturned()
    {
        DotnetNativeWrapper wrapper = new();
        var info = await wrapper.GetInfo();

        Assert.True(!string.IsNullOrWhiteSpace(info));
    }

    [Fact]
    public async Task GivenStdOutEventHandler_WhenListProjectsIsInvoked_ThenhandlerIsCalledAtLeastOnce()
    {
        int counter = 0;
        DotnetNativeWrapper wrapper = new();
        wrapper.OnStdOutput += (string chunk) => counter +=1;
        await wrapper.ListProjects();

        Assert.True(counter > 0);
    }

}