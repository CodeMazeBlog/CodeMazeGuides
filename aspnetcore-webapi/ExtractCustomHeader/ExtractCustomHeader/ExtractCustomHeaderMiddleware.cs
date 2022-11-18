using Microsoft.Extensions.Primitives;

namespace ExtractCustomHeader
{
    public class ExtractCustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public ExtractCustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            const string HEADER_KEY_NAME = "MiddlewareHeaderKey";
            context.Request.Headers.TryGetValue(HEADER_KEY_NAME, out StringValues headerValue);

            if (context.Items.ContainsKey(HEADER_KEY_NAME))
            {
                context.Items[HEADER_KEY_NAME] = headerValue;
            }
            else
            {
                context.Items.Add(HEADER_KEY_NAME, $"{headerValue}-received");
            }

            await _next(context);
        }
    }
}
