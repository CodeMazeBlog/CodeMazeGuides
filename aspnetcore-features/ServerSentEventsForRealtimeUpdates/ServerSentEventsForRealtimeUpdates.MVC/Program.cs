using Microsoft.Net.Http.Headers;
using ServerSentEventsForRealtimeUpdates.MVC.Models.Flight;
using ServerSentEventsForRealtimeUpdates.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IFlightService, FlightService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/sse",async (HttpContext ctx, IFlightService service, CancellationToken token) =>
{
    ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");

    while (!token.IsCancellationRequested)
    {
        var flight = await service.GetFlightsInformation();
        await ctx.Response.WriteAsync($"data: {flight}\n\n", cancellationToken: token);
        await ctx.Response.Body.FlushAsync(cancellationToken: token);
    }
});

app.MapGet("/test",async (HttpContext ctx, IFlightService service, CancellationToken token) =>
{
    ctx.Response.Headers.Append(HeaderNames.ContentType, "text/event-stream");
    
    var flight = await service.GetFlightsInformation();
    await ctx.Response.WriteAsync($"data: {flight}\n\n", cancellationToken: token);
    await ctx.Response.Body.FlushAsync(cancellationToken: token);

});


app.Run();

public partial class Program(){}