using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;
using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Processors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFulfillPostlaTickets, PostalFulfillmentProcessor>();
builder.Services.AddTransient<IFulfillBarcodeTickets, BarcodeFulfillmentProcessor>();
builder.Services.AddTransient<IFulfillSmartcardTickets, SmartcardFulfillmentProcessor>();

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