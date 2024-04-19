var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("TestClient", (sp, httpClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var timeoutSeconds = configuration.GetValue<int>("TestClient:TimeOutSeconds");

    httpClient.BaseAddress = new Uri("http://localhost:5000");
    httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
