namespace UsingResultPatternInNETWebAPI.Exceptions;

public class DefaultExceptionHandler : IExceptionHandler
{
    private readonly ILogger<DefaultExceptionHandler> _logger;

    public DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError("an error occurred while processing your request: {Message}", 
            exception.Message);

        var problemDetails = new ProblemDetails
        {
            Detail = exception.Message
        };

        switch (exception)
        {
            case RecordNotFoundException:
                problemDetails.Status = (int) HttpStatusCode.NotFound;
                problemDetails.Title = exception.GetType().Name;
                break;
            case ValidationException:
                problemDetails.Status = (int) HttpStatusCode.BadRequest;
                problemDetails.Title = exception.GetType().Name;
                break;
            default:
                problemDetails.Status = (int) HttpStatusCode.InternalServerError;
                problemDetails.Title = "Internal Server Error";
                break;
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext
            .Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}