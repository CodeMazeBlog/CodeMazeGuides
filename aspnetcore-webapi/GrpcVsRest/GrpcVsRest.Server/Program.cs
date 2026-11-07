using GrpcVsRest.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalog();

var app = builder.Build();

app.UseCatalog();

app.Run();
