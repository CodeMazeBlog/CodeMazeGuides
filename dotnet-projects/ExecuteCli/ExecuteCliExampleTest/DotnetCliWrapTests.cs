using ExecuteCliExample;

namespace ExecuteCliExampleTest;

public class DotnetCliWrapTests
{
    [Fact]
    public async Task WhenGetVersionIsInvoked_ThenVersionIsNotNull()
    {
        DotnetCliWrap wrapper = new();
        var version = await wrapper.GetVersion();

        Assert.NotNull(version);
    }

    [Fact]
    public async Task WhenRunInvalidCommandIsInvoked_ThenExitCodeIsNotZero()
    {
        DotnetCliWrap wrapper = new();
        var (exitCode, _) = await wrapper.RunInvalidCommand();

        Assert.NotEqual(exitCode, 0);
    }

    [Fact]
    public async Task WhenRunInvalidCommandIsInvoked_ThenErrorIsNotEmpty()
    {
        DotnetCliWrap wrapper = new();
        var (_, error) = await wrapper.RunInvalidCommand();

        Assert.True(!string.IsNullOrWhiteSpace(error));
    }

    [Fact]
    public async Task GivenStdOutEventHandler_WhenListProjectsIsInvoked_ThenhandlerIsCalledAtLeastOnce()
    {
        int counter = 0;
        DotnetCliWrap wrapper = new();
        wrapper.OnStdOutput += (string chunk) => counter += 1;
        await wrapper.ListProjects();

        Assert.True(counter > 0);
    }
}