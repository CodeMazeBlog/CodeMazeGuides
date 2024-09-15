namespace BrighterExample.Common.Commands;

public class PingAsyncCommandHandler : RequestHandlerAsync<PingAsyncCommand>
{
    public override async Task<PingAsyncCommand> HandleAsync(
        PingAsyncCommand command,
        CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        Console.WriteLine("[PingAsyncCommandHandler] >> Pong Async!");

        return await base.HandleAsync(command, cancellationToken);
    }
}
