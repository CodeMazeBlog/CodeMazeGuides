using CustomAuthorizeAttribute.Authorization.Requirements;
using CustomAuthorizeAttribute.Authorization.Requirements.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, SessionHandler>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o => { });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SessionPolicy", policy =>
    {
        policy.Requirements.Add(new SessionRequirement("X-Session-Id"));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
