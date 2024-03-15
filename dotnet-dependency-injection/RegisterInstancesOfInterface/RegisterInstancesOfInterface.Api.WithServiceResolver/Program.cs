using RegisterInstancesOfInterface.Api.WithServiceResolver.Processors;
using RegisterInstancesOfInterface.Api.WithServiceResolver.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<PostalFulfillmentProcessor>();
builder.Services.AddTransient<BarcodeFulfillmentProcessor>();
builder.Services.AddTransient<SmartcardFulfillmentProcessor>();

builder.Services.AddTransient<FulfillmentProcessorResolver>(serviceProvider => key =>
{
    switch (key)
    {
        case "barcode": 
            return serviceProvider.GetService<BarcodeFulfillmentProcessor>(); 
        case "postal": 
            return serviceProvider.GetService<PostalFulfillmentProcessor>(); 
        case "smartcard": 
            return serviceProvider.GetService<SmartcardFulfillmentProcessor>(); 
        default: 
            throw new KeyNotFoundException();
    }
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