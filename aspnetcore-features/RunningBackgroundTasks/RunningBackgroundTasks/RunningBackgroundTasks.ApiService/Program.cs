using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.ApiService.Services;
using RunningBackgroundTasks.ApiService.Services.Abstractions;
using RunningBackgroundTasks.ApiService.Services.One_off;
using RunningBackgroundTasks.ApiService.Services.Periodic;
using RunningBackgroundTasks.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<ApplicationDbContext>("clientsDb");

builder.AddServiceDefaults();

builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
});
builder.Services.AddProblemDetails();

builder.Services.AddTransient<IWorker, Worker>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddTransient<IPeriodicTimer, CustomPeriodicTimer>();

// builder.Services.AddHostedService<InitializationHostedService>();
// builder.Services.AddHostedService<InitializationBackgroundService>();
builder.Services.AddHostedService<InitializationHostedLifecycleService>();

// builder.Services.AddHostedService<PeriodicHostedService>();
// builder.Services.AddHostedService<PeriodicBackgroundService>();
builder.Services.AddHostedService<PeriodicHostedLifecycleService>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapGet("/clients/active", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => x.IsActive).AsNoTracking();
});

app.MapGet("/clients/archived", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => !x.IsActive).AsNoTracking();
});

app.MapDefaultEndpoints();

app.Run();
