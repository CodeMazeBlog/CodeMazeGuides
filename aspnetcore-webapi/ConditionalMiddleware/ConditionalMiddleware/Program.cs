using ConditionalMiddleware;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseMiddleware<DevelopmentLoggingMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//To have a look
app.MapWhen(context => context.Request.Method == "PUT", appBuilder =>
{
    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
});


//app.UseWhen(context => context.Request.Headers.ContainsKey("X-Custom-Header") &&
//context.Request.Method == "POST" && context.Request.Query.ContainsKey("active"), appBuilder =>
//{
//    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
