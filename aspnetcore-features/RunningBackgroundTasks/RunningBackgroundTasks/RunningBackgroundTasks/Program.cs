using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services;
using RunningBackgroundTasks.Services.Abstractions;
using RunningBackgroundTasks.Services.One_off;
using RunningBackgroundTasks.Services.Periodic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<HostOptions>(options =>
{
    options.ServicesStartConcurrently = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("Clients"));

builder.Services.AddTransient<IWorker, Worker>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddTransient<IPeriodicTimer, DailyPeriodicTimer>();
builder.Services.AddHostedService<InitializationHostedLifecycleService>();
builder.Services.AddHostedService<PeriodicHostedLifecycleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/clients/active", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => x.IsActive).AsNoTracking();
});

app.MapGet("/clients/archived", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => !x.IsActive).AsNoTracking();
});

app.Run();
