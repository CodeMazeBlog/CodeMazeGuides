using MediatR.Pipeline;
using MediatrExceptionHandler.Common;
using System.Diagnostics;

namespace MediatrExceptionHandler
{
    public class GlobalExceptionMiddleware<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
          where TRequest : BaseRequest<TResponse>
          where TResponse : SomeResponse, new()
          where TException : Exception
    {
        private readonly ILogger<GlobalExceptionMiddleware<TRequest, TResponse, TException>> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {

            var ex = exception.Demystify();

            _logger.LogError(ex, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));

            var response = new TResponse
            {
                Message = "A server error ocurred"
            };

            state.SetHandled(response);

            return Task.CompletedTask;
        }
    }
}
