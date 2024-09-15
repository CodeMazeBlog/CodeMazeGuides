using MediatR;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.ServiceManager;

namespace VerticalSliceArchitecture.Features.Games
{
    public class RemoveGameFromConsole
    {
        public class RemoveGameCommand : IRequest
        {
            public int ConsoleId { get; set; }
            public int GameId { get; set; }
        }

        public class Handler : IRequestHandler<RemoveGameCommand>
        {
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            public async Task Handle(RemoveGameCommand request, CancellationToken cancellationToken)
            {
                var console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console is null)
                    throw new NoConsoleExistsException(request.ConsoleId);

                var game = await _serviceManager.Game.GetGameAsync(request.ConsoleId, request.GameId);

                if (game is null)
                    throw new NoGameExistsException(request.ConsoleId, request.GameId);

                _serviceManager.Game.DeleteGame(game);

                await _serviceManager.SaveAsync();

                return;
            }
        }
    }
}
