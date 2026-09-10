using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.ConfigurationValidation;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptionsWithValidateOnStart<TitleConfiguration>()
    .Bind(builder.Configuration.GetSection("Pages:HomePage"))
    .ValidateDataAnnotations();

builder.Services.TryAddEnumerable(
    ServiceDescriptor.Singleton<IValidateOptions<TitleConfiguration>, TitleConfigurationValidation>());

builder.Services.TryAddSingleton<ITitleColorService, TitleColorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
