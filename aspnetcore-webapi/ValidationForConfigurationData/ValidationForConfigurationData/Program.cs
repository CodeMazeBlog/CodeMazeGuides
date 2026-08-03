using Microsoft.Extensions.Options;
using ValidationForConfigurationData.Settings;
using ValidationForConfigurationData.Settings.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSingleton<IValidateOptions<NotificationOptions>, ValidateNotificationOptions>()
    .AddOptionsWithValidateOnStart<NotificationOptions>();

builder.Services.AddOptions<NotificationOptions>()
    .BindConfiguration(nameof(NotificationOptions));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/options", (IOptions<NotificationOptions> options) =>
{
    return Results.Ok(options.Value);
})
.WithOpenApi();

app.Run();

public partial class Program { }
