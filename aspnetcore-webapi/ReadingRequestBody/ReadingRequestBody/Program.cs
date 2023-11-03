using Microsoft.AspNetCore.Server.Kestrel.Core;
using ReadingRequestBody.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ReadRequestBodyActionFilter>();
});

var app = builder.Build();

app.UseMiddleware<RequestBodyMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
