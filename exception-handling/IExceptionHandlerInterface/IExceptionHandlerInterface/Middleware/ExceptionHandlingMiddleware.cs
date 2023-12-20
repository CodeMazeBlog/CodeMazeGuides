using Microsoft.AspNetCore.Diagnostics;

namespace IExceptionHandlerInterface.Middleware;

public class ExceptionHandlingMiddleware : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}