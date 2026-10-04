using Microsoft.EntityFrameworkCore;
using Newsroom.Api;
using Newsroom.Core;
using Newsroom.Core.Ports.Driven;
using Newsroom.Core.Ports.Driving;
using Newsroom.Notifications;
using Newsroom.Persistence;

var builder = WebApplication.CreateBuilder(args);

// The core, behind its driving port
builder.Services.AddScoped<IArticleService, ArticleService>();

// One driven adapter per driven port
builder.Services.AddDbContext<NewsroomDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Newsroom")));
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ISubscriberNotifier, LoggingSubscriberNotifier>();

builder.Services.AddProblemDetails();
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NewsroomDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapArticleEndpoints();

app.Run();
