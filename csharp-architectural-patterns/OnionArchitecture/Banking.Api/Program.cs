using Banking.Api;
using Banking.Infrastructure;
using Banking.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Banking")!);

builder.Services.AddProblemDetails();
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BankingDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapAccountEndpoints();

app.Run();
