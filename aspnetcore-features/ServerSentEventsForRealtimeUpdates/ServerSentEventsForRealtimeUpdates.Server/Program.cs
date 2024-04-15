using Microsoft.Net.Http.Headers;
using ServerSentEventsForRealtimeUpdates.Server;

const string myCors = "client";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(myCors,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddScoped<ICounterService, CounterService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/sse", async Task (HttpContext ctx, ICounterService service, CancellationToken token) =>
{
    ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");

    var count = service.GetStartValue();

    while (count >= 0 && !token.IsCancellationRequested)
    {
        await service.CountdownDelay();

        await ctx.Response.WriteAsync($"data: {count}\n\n", cancellationToken: token);
        await ctx.Response.Body.FlushAsync(cancellationToken: token);

        count--;
    }

    await ctx.Response.CompleteAsync();
});

app.UseCors(myCors);

app.Run();

public partial class Program{}