using AutoMapper;
using MediatR;
using VerticalSliceArchitecture.ServiceManager;

namespace VerticalSliceArchitecture.Features.Consoles
{
    public class GetAllConsoles
    {
        //Input
        public class GetConsolesQuery : IRequest<IEnumerable<ConsoleResult>> { }

        //Output
        public class ConsoleResult
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
        }

        //Handler
        public class Handler : IRequestHandler<GetConsolesQuery, IEnumerable<ConsoleResult>>
        {
            private readonly IServiceManager _serviceManager;
            private readonly IMapper _mapper;

            public Handler(IServiceManager serviceManager, IMapper mapper)
            {
                _serviceManager = serviceManager;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ConsoleResult>> Handle(GetConsolesQuery request, CancellationToken cancellationToken)
            {
                var consoles = await _serviceManager.Console.GetAllConsolesAsync();
                var results = _mapper.Map<IEnumerable<ConsoleResult>>(consoles);
                return results;
            }
        }
    }
}
