using MediatR.Pipeline;
using MediatrExceptionHandler.Common;
using System.Diagnostics;

namespace MediatrExceptionHandler
{
    public class GlobalRequestExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>

          where TRequest : BaseRequest<TResponse>
          where TResponse : WeatherResponse, new()
          where TException : Exception

    {
        private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> _logger;

        public GlobalRequestExceptionHandler(ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger)
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
