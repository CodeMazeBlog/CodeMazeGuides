using MediatR;

namespace MediatrExceptionHandler.Common
{
    public class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : SomeResponse { }

    public class SomeRequest : BaseRequest<SomeResponse> { }
}
