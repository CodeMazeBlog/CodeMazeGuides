namespace BrighterExample;

public class PingAsyncCommand() : Command(Guid.NewGuid())
{

}

internal class PingAsyncHandler(
    [FromServices] ILogger<PingAsyncHandler> logger
) : RequestHandlerAsync<PingAsyncCommand>
{
    [RequestLoggingAsync(step: 1, timing: HandlerTiming.Before)]
    public override async Task<PingAsyncCommand> HandleAsync(PingAsyncCommand command, CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        logger.LogInformation("[{handler}]: Pong", nameof(PingAsyncHandler));
        return await base.HandleAsync(command, cancellationToken);
    }
}