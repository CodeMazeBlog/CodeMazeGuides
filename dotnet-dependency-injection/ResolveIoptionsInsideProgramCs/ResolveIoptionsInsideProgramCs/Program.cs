using ResolveIoptionsInsideProgramCs.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.RegisterAndResolveOptionsThroughServiceImplementationFactoryDelegate();

var app = builder.Build();

app.MapControllers();
app.Run();