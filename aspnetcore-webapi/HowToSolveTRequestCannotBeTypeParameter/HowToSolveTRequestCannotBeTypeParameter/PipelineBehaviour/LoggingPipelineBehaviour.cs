using MediatR;

namespace HowToSolveTRequestCannotBeTypeParameter.PipelineBehaviour;

public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Handling {RequestType} - {RequestData}",
            typeof(TRequest).Name, request);

        var response = await next();

        _logger.LogInformation(
            "Handled {RequestType} - Response: {ResponseData}",
            typeof(TRequest).Name, response);

        return response;
    }
}
