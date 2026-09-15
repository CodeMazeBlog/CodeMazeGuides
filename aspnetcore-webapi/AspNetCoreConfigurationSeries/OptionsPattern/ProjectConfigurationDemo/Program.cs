using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TitleConfiguration>("HomePage",
    builder.Configuration.GetSection("Pages:HomePage"));
builder.Services.Configure<TitleConfiguration>("ProductPage",
    builder.Configuration.GetSection("Pages:ProductPage"));

builder.Services.TryAddSingleton<ITitleColorService, TitleColorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
