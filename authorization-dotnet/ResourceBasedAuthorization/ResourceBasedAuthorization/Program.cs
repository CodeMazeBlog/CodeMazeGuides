using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthorization.AuthorizationHandlers;
using ResourceBasedAuthorization.AuthorizationRequirements;
using ResourceBasedAuthorization.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BlogPostsRepository>();

builder.Services.AddTransient<IAuthorizationHandler, UserIsAuthorAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationHandler, BlogPostCrudOperationsAuthorizationHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserIsAuthorPolicy", policy => policy.Requirements.Add(new UserIsAuthorRequirement()));
});

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
