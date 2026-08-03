using RegisterServicesForEnvironments.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IProductService, ProductDevelopmentService>();
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddScoped<IProductService, ProductLiveService>();
}

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }