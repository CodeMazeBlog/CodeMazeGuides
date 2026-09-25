using EventTicketing.Api;
using EventTicketing.Application;
using EventTicketing.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Ticketing")!);

builder.Services.AddProblemDetails();
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapEventEndpoints();

app.Run();
