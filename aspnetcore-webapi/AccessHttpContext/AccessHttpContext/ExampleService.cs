namespace AccessHttpContext;

public class ExampleService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public ExampleService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Task WriteToResponse(string input)
    {
        return _contextAccessor.HttpContext?.Response.WriteAsync(input)
               ?? Task.CompletedTask;
    }
}