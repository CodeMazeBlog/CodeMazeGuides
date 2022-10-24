using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.Controllers;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepositoryContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<RepositoryContext>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
