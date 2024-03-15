using APIKeyAuthentication.CustomAttribute;
using APIKeyAuthentication.EndpointFilter;
using APIKeyAuthentication.Interface;
using APIKeyAuthentication.PolicyBased;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace APIKeyAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiKeyPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
                    policy.Requirements.Add(new ApiKeyRequirement());
                });
            });

            builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
            builder.Services.AddScoped<ApiKeyAuthFilter>();
            builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // IMPORTANT: When uncommenting line number 53, please ensure that you have added the using directive "using APIKeyAuthentication.CustomMiddleware;"
            //app.UseMiddleware<ApiKeyMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("api/product", () =>
            {
                return Results.Ok();
            }).AddEndpointFilter<ApiKeyEndpointFilter>();

            app.Run();
        }
    }
}