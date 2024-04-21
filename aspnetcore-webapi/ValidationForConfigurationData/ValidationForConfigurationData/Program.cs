using Microsoft.Extensions.Options;
using ValidationForConfigurationData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddSingleton<IValidateOptions<NotificationSettings>, ValidateNotificationSettings>()
	.AddOptionsWithValidateOnStart<NotificationSettings>();

builder.Services.AddOptions<NotificationSettings>()
	.BindConfiguration(nameof(NotificationSettings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/settings", (IOptions<NotificationSettings> options) =>
{
	return Results.Ok(options.Value);
})
.WithOpenApi();

app.Run();

public partial class Program { }
