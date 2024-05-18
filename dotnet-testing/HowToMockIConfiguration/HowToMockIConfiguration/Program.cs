using HowToMockIConfiguration.Services;
using HowToMockIConfiguration.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinanceService, FinanceService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/finance/total", (double hours, IFinanceService service) =>
{
    return service.CalculateTotalAmount(hours);
})
.WithOpenApi();

app.Run();
