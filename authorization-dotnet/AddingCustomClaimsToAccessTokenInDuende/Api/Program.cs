using System.Security.Claims;
using Duende.IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.Audience = "paymentsapi";
        options.MapInboundClaims = false;
        options.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/discounts", (ClaimsPrincipal user) => new
    {
        Tenant = user.FindFirstValue("tenant"),
        Discount = user.FindFirstValue("payments.discount")
    })
    .RequireAuthorization(policy => policy.RequireRole("admin"));

app.Run();
