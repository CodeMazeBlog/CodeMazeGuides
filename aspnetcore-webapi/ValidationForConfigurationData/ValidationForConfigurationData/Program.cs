using Microsoft.Extensions.Options;
using ValidationForConfigurationData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<NotificationSettings>()
	.BindConfiguration(nameof(NotificationSettings))
	.ValidateDataAnnotations()
	.ValidateOnStart()
	.Validate(options =>
	{
		if (options.EnableEmail &&
			options.MaxNumberOfRetries > 5)
		{
			return false;
		}

		return true;
	});

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
