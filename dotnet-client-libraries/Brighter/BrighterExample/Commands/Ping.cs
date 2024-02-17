namespace BrighterExample;

public class PingCommand() : Command(Guid.NewGuid())
{
}

internal class PingCommandHandler(
    [FromServices] ILogger<PingCommandHandler> logger
) : RequestHandler<PingCommand>
{
    [RequestLogging(step: 1, timing: HandlerTiming.Before)]
    public override PingCommand Handle(PingCommand command)
    {
        logger.LogInformation("[{handler}]: Pong", nameof(PingCommandHandler));
        return base.Handle(command);
    }
}
