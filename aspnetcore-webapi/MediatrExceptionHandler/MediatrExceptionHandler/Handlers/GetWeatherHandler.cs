using MediatR;
using MediatrExceptionHandler.Common;

namespace MediatrExceptionHandler.Handlers
{
    public class GetWeatherHandler : IRequestHandler<SomeRequest, SomeResponse>
    {
        public async Task<SomeResponse> Handle(SomeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
