using RateLimitingDotNET8;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettings(builder.Configuration);

RateLimiters.FixedRateLimiter(builder);

RateLimiters.SlidingRateLimiter(builder);

RateLimiters.TokenBucketRateLimiter(builder);

RateLimiters.ConcurrencyRateLimiter(builder);

RateLimiters.AuthorizationRateLimiter(builder);

RateLimiters.ChainedRateLimiter(builder);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

RateLimiters.MinimalApiRateLimiting(app);

app.Run();

public partial class Program { }