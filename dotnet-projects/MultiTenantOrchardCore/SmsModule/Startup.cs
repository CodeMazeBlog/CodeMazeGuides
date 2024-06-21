using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SmsModule;

public class Startup
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/Sms",
            async context => { await context.Response.WriteAsync("Welcome to SMS module"); });
    }
}