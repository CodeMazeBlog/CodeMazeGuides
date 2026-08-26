var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin()));
builder.Services.AddHttpClient();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();
