using EventTicketing.Data;
using EventTicketing.Features.Events;
using EventTicketing.Features.Reservations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicketingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Ticketing")));

builder.Services.AddScoped<GetEventAvailability.Handler>();
builder.Services.AddScoped<ReserveTickets.Handler>();

builder.Services.AddProblemDetails();
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();
    dbContext.Database.EnsureCreated();
}

var events = app.MapGroup("/api/events");

GetEventAvailability.MapEndpoint(events);
ReserveTickets.MapEndpoint(events);
ListAvailableEvents.MapEndpoint(events);

app.Run();
