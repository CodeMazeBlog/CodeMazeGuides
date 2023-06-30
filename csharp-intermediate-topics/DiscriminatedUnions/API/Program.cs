using API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IOrdersService, OrdersService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();