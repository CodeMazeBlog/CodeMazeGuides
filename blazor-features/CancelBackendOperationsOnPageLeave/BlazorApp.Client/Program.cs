var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(sp.GetRequiredService<NavigationManager>().BaseUri) });

await builder.Build().RunAsync();
