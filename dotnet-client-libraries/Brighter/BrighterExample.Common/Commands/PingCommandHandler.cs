namespace BrighterExample.Common.Commands;

public class PingCommandHandler : RequestHandler<PingCommand>
{
    public override PingCommand Handle(PingCommand command)
    {
        Console.WriteLine("[PingCommandHandler] >> Pong");

        return base.Handle(command);
    }
}
