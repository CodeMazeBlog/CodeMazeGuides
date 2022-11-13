using Microsoft.Extensions.Primitives;

namespace ExtractCustomHeader
{
    public class EctractCustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public EctractCustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            const string HEADER_KEY_NAME = "MiddlewareHeaderKey";
            context.Request.Headers.TryGetValue(HEADER_KEY_NAME, out StringValues headerValue);
            Console.WriteLine(headerValue);

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
