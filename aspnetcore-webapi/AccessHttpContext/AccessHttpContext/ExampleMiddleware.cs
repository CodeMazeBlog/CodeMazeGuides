namespace AccessHttpContext;

public class ExampleMiddleware
{
    private readonly RequestDelegate _next;

    public ExampleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync(context.Request.Path);
    }
}