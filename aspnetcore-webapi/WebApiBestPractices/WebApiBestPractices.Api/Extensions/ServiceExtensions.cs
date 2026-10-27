using System.Text;
using System.Threading.RateLimiting;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebApiBestPractices.Api.Filters;
using WebApiBestPractices.Api.Security;
using WebApiBestPractices.Application.Services;
using WebApiBestPractices.Domain.Contracts;
using WebApiBestPractices.Infrastructure.Repositories;

namespace WebApiBestPractices.Api.Extensions;

public static class ServiceExtensions
{
    public const string CorsPolicy = "CorsPolicy";
    public const string OwnersCachePolicy = "Owners";
    public const string OwnersCacheTag = "owners";
    public const string PerClientRateLimit = "PerClient";

    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration) =>
        services.AddCors(options =>
            options.AddPolicy(CorsPolicy, policy => policy
                .WithOrigins(configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [])
                .AllowAnyMethod()
                .AllowAnyHeader()));

    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IOwnerRepository, InMemoryOwnerRepository>();
        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<ValidateOwnerExistsFilter>();
        services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
        services.AddScoped<AccountService>();
        services.AddScoped<OwnerIdProtector>();
        services.AddDataProtection();
        services.AddHybridCache();
    }

    public static void ConfigureVersioning(this IServiceCollection services) =>
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("api-version"));
        })
        .AddMvc();

    public static void ConfigureOutputCache(this IServiceCollection services) =>
        services.AddOutputCache(options =>
            options.AddPolicy(OwnersCachePolicy, policy => policy
                .Expire(TimeSpan.FromSeconds(30))
                .SetVaryByHeader("Accept")
                .Tag(OwnersCacheTag)));

    public static void ConfigureRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        var permitLimit = configuration.GetValue("RateLimiting:PermitLimit", 100);

        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            options.AddPolicy(PerClientRateLimit, httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.Identity?.Name
                        ?? httpContext.Connection.RemoteIpAddress?.ToString()
                        ?? "anonymous",
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = permitLimit,
                        Window = TimeSpan.FromMinutes(1),
                        QueueLimit = 0
                    }));
        });
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"]
            ?? throw new InvalidOperationException("JwtSettings:SecretKey is not configured.");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["ValidIssuer"],
                    ValidAudience = jwtSettings["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }
}
