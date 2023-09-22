using MediatR.Pipeline;
using System.Diagnostics;
using System.Net;

namespace MediatrExceptionHandler
{
    public class GlobalRequestExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
          where TResponse : BaseResponse, new()
          where TException : Exception
    {
        private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GlobalRequestExceptionHandler(
           ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger,
           IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var ex = exception.Demystify();

            _logger.LogError(ex, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));

            // Set the HTTP status code to 500 (Internal Server Error) in the HttpContext
            _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new TResponse
            {
                Message = "A server error ocurred",
            };

            state.SetHandled(response);

            return Task.CompletedTask;
        }
    }
}
