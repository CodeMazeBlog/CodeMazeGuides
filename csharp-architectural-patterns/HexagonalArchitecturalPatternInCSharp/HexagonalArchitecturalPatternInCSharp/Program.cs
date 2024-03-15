using HexagonalArchitecturalPatternInCSharp;
using HexagonalArchitecturalPatternInCSharp.Controllers;
using HexagonalArchitecturalPatternInCSharp.Persistence;
using HexagonalArchitecturalPatternInCSharp.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence();
builder.Services.AddBusinessServices();
builder.Services.AddMessaging();

builder.Services.AddControllers().AddApplicationPart(typeof(WritingController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<WritingDbContext>();
dbContext.AddSeedData();

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