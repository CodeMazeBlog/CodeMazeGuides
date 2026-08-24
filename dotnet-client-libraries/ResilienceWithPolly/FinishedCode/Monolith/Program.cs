using Microsoft.AspNetCore.Mvc;
using Monolith.Resilience;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin()));
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddResiliencePipeline<string, IActionResult>(
    ProxyPipeline.Name,
    (pipeline, _) => ProxyPipeline.Configure(pipeline));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();
