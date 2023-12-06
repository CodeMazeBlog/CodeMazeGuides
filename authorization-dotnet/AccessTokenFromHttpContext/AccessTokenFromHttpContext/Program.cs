using AccessTokenFromHttpContext.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options => 
                 { 
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                 })
                .AddJwtBearer(options => 
                { 
                    // Configure JWT bearer token options
                });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseMiddleware<AccessTokenMiddleware>();

app.UseAuthentication();

app.MapControllers();

app.Run();
