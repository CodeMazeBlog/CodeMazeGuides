using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ClientsDbConnectionString"),
        options => options.EnableRetryOnFailure()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/clients/active", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => x.IsActive).AsEnumerable();
})
.WithName("GetActiveClients")
.WithOpenApi();

app.MapGet("/clients/archived", (ApplicationDbContext context) =>
{
    return context.Clients.Where(x => !x.IsActive).AsEnumerable();
})
.WithName("GetArchivedClients")
.WithOpenApi();

app.Run();
