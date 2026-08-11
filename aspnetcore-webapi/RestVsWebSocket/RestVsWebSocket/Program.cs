var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.WebHost.UseUrls("http://localhost:5289"); // Client/Program.cs hardcodes this URL

var app = builder.Build();

app.MapOpenApi();
app.UseWebSockets();
app.MapControllers();

app.Run();
