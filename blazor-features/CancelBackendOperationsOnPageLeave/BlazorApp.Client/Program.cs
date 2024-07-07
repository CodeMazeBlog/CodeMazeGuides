using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new(sp.GetRequiredService<NavigationManager>().BaseUri) });

await builder.Build().RunAsync();
