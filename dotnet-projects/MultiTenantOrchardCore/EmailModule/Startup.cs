using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EmailModule;

public class Startup
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/Email",
            async context => { await context.Response.WriteAsync("Welcome to Email module"); });
    }
}