namespace BrighterExample.Tests;

public class BrighterExampleTests
{
    private readonly IAmACommandProcessor _processor;

    public BrighterExampleTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _processor = factory.Services.GetRequiredService<IAmACommandProcessor>();
    }

    [Fact]
    public void GivenPingCommand_WhenSent_ThenShouldNotThrow()
    {
        var command = new PingCommand();

        var result = Record.Exception(() => _processor.Send(command));

        Assert.Null(result);
    }

    [Fact]
    public async Task GivenPingAsyncCommand_WhenSent_ThenShouldNotThrow()
    {
        var command = new PingAsyncCommand();

        var result = await Record.ExceptionAsync(() => _processor.SendAsync(command));

        Assert.Null(result);
    }
}
