namespace BrighterExample.Common;

public class PingAsyncCommand() : Command(Guid.NewGuid()) { }

internal class PingAsyncCommandHandler : RequestHandlerAsync<PingAsyncCommand>
{
  public override async Task<PingAsyncCommand> HandleAsync(
    PingAsyncCommand command,
    CancellationToken cancellationToken = default
  )
  {
    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
    Console.WriteLine("------------------ [PingAsyncCommandHandler] ------------------");
    Console.WriteLine("Pong Async!");
    Console.WriteLine("---------------------------------------------------------------");
    return await base.HandleAsync(command, cancellationToken);
  }
}
