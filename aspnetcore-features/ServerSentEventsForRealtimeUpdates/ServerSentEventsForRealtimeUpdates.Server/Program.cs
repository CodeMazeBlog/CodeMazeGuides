
using Microsoft.Net.Http.Headers;

const string myCors = "client";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(myCors,
        policy =>
        {
            policy.WithOrigins("http://localhost:63342")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/sse",async Task (HttpContext ctx, CancellationToken token) =>
{
    ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");
    
    var count = 10;
    while (count >= 0)
    {
        await Task.Delay(1000, token);
        await ctx.Response.WriteAsync($"data: {count}\n\n", cancellationToken: token);
        await ctx.Response.Body.FlushAsync(cancellationToken: token);
        count--;
    }

    await ctx.Response.CompleteAsync();
});
app.UseCors(myCors);
app.Run();

public partial class Program{}