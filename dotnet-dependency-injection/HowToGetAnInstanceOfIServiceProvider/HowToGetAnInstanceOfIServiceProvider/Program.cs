using HowToGetAnInstanceOfIServiceProvider.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddHostedService<ExampleBackgroundService>();
builder.Services.AddScoped<IExampleService>(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IHostEnvironment>();

    return config.IsDevelopment() ? new DevelopmentExampleService() : new ExampleService();
});

var serviceProvider = builder.Services.BuildServiceProvider();
var serviceInstance1 = serviceProvider.GetService<IExampleService>();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var serviceInstance2 = serviceScope.ServiceProvider.GetRequiredService<IExampleService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
await app.RunAsync();