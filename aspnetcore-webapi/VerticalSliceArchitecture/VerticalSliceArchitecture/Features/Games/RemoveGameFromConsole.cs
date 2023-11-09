using MediatR;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.ServiceManager;

namespace VerticalSliceArchitecture.Features.Games
{
    public class RemoveGameFromConsole
    {
        public class RemoveGameCommand : IRequest<Unit>
        {
            public int ConsoleId { get; set; }
            public int GameId { get; set; }
        }

        public class Handler : IRequestHandler<RemoveGameCommand, Unit>
        {
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            public async Task<Unit> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
            {
                var console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                    throw new NoConsoleExistsException(request.ConsoleId);

                var game = await _serviceManager.Game.GetGameAsync(request.ConsoleId, request.GameId);

                if (game == null)
                    throw new NoGameExistsException(request.ConsoleId, request.GameId);

                _serviceManager.Game.DeleteGame(game);

                await _serviceManager.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
