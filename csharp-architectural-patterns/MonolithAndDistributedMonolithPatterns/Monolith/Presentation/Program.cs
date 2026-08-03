using Monolith.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MusicRepository>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();