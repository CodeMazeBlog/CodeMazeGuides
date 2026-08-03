using System.Reactive.Subjects;
using System.Text.Json.Serialization;
using Monolith.ShoppingCartApi;
using Monolith.ShoppingCartApi.BackgroundWorkers;
using Monolith.ShoppingCartApi.Coordinators;
using Monolith.ShoppingCartApi.Services;
using Monolith.ShoppingCartApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Shopping Cart  Services Registration 
builder.Services.AddSingleton<IPaymentProcessor, PaymentProcessor>();
builder.Services.AddSingleton<IStockValidator, StockValidator>();
builder.Services.AddSingleton<IReceiptGenerator, ReceiptGenerator>();
builder.Services.AddSingleton<ITaxCalculator, TaxCalculator>();

//Observable Registartions
builder.Services.AddSingleton<ReplaySubject<QueueItem>>();
builder.Services.AddSingleton<IObservable<QueueItem>>(x => x.GetRequiredService<ReplaySubject<QueueItem>>());
builder.Services.AddSingleton<IObserver<QueueItem>>(x => x.GetRequiredService<ReplaySubject<QueueItem>>());

//Coordinators Registraion
builder.Services.AddSingleton<ICheckoutCoordinator, CheckoutCoordinatorV1>();
//builder.Services.AddSingleton<ICheckoutCoordinator, CheckoutCoordinatorV2>();
//builder.Services.AddSingleton<ICheckoutCoordinator, CheckoutCoordinatorV3>();
//builder.Services.AddSingleton<ICheckoutCoordinator, CheckoutCoordinatorV4>();

//BackgroundWorkers Registration
builder.Services.AddHostedService<ObserverBackgroundWorker>();
builder.Services.AddHostedService<ChannelBackgroundWorker>();

//Channel Registrations
builder.Services.AddSingleton<ICheckoutProcessingChannel, CheckoutProcessingChannel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayRequestDuration();        
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
