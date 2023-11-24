using AutoMapper;
using MediatR;
using VerticalSliceArchitecture.Domain;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.ServiceManager;

namespace VerticalSliceArchitecture.Features.Games
{
    public class AddGameToConsole
    {
        //Input
        public class AddGameCommand : IRequest<GameResult>
        {
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        //Output
        public class GameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
            public int ConsoleId { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<AddGameCommand, GameResult>
        {
            private readonly IServiceManager _serviceManager;
            private readonly IMapper _mapper;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
            {
                var console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                    throw new NoConsoleExistsException(request.ConsoleId);

                var game = new Game()
                {
                    Name = request.Name,
                    Publisher = request.Publisher,
                    ConsoleId = request.ConsoleId
                };

                _serviceManager.Game.AddGameToConsole(request.ConsoleId, game);

                await _serviceManager.SaveAsync();

                var result = _mapper.Map<GameResult>(game);

                return result;
            }
        }
    }
}
