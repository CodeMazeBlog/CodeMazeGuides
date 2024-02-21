namespace BrighterExample.Common;

public class PingCommand() : Command(Guid.NewGuid()) { }

internal class PingCommandHandler : RequestHandler<PingCommand>
{
  public override PingCommand Handle(PingCommand command)
  {
    Console.WriteLine("------------------ [PingCommandHandler] ------------------");
    Console.WriteLine("Pong");
    Console.WriteLine("----------------------------------------------------------");
    return base.Handle(command);
  }
}
