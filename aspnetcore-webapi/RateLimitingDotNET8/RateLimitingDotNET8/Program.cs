using RateLimitingDotNET8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettings(builder.Configuration);

RateLimiters.FixedRateLimiter(builder);

RateLimiters.SlidingRateLimiter(builder);

RateLimiters.TokenBucketRateLimiter(builder);

RateLimiters.ConcurrencyRateLimiter(builder);

RateLimiters.AuthorizationRateLimiter(builder);

// RateLimiters.ChainedRateLimiter(builder);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.UseRateLimiter();

RateLimiters.MinimalApiRateLimiting(app);

app.MapControllers();

app.Run();

public partial class Program { }