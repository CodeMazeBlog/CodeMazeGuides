using BlazorApp.Client.Pages;
using BlazorApp.Components;
using BlazorApp.Components.Pages;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.MapGet("/api/weather", async (CancellationToken cancellationToken) =>
{
    Console.WriteLine("Delay started");
    // Simulate asynchronous loading
    await Task.Delay(5000, cancellationToken);
    Console.WriteLine("Delay ended");
    
    var startDate = DateOnly.FromDateTime(DateTime.Now);
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot" };
    return Enumerable.Range(1, 5).Select(index => new Weather.WeatherForecast
    {
        Date = startDate.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = summaries[Random.Shared.Next(summaries.Length)]
    }).ToArray();
});

app.Run();