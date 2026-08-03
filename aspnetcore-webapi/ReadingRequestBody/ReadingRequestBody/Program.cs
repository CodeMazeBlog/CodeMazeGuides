using Microsoft.OpenApi.Models;
using ReadingRequestBody.SwaggerUtils;
using ReadingRequestBody.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(typeof(ILogger), typeof(Logger<RequestBodyMiddleware>));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ReadRequestBodyActionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reading Request Body", Version = "v1" });
    c.OperationFilter<RawTextRequestOperationFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestBodyMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
