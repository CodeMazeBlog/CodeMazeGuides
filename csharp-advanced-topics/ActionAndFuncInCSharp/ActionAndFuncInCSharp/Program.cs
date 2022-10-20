var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCaching(options => { options.SizeLimit = 50 * 1024 * 1024; });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
