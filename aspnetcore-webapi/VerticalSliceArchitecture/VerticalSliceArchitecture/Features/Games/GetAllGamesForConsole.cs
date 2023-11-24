using AutoMapper;
using MediatR;
using VerticalSliceArchitecture.Features.Games.Exceptions;
using VerticalSliceArchitecture.ServiceManager;

namespace VerticalSliceArchitecture.Features.Games
{
    public class GetAllGamesForConsole
    {
        public class GetGamesQuery : IRequest<IEnumerable<GameResult>>
        {
            public int ConsoleId { get; set; }
        }

        public class GameResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Publisher { get; set; }
        }

        public class Handler : IRequestHandler<GetGamesQuery, IEnumerable<GameResult>>
        {
            private readonly IServiceManager _serviceManager;
            private readonly IMapper _mapper;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GameResult>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
            {
                var console = await _serviceManager.Console.GetConsoleByIdAsync(request.ConsoleId);

                if (console == null)
                    throw new NoConsoleExistsException(request.ConsoleId);

                var games = await _serviceManager.Game.GetAllGamesAsync(console.Id);

                var result = _mapper.Map<IEnumerable<GameResult>>(games);

                return result;
            }
        }
    }
}
