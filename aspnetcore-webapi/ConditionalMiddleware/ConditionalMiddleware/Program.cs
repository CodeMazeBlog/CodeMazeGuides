using ConditionalMiddleware;

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

app.Map("/api", appBuilder =>
{
    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
});

//// Apply middleware only when the request is a GET request
//app.MapWhen(context => context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase), appBuilder =>
//{
//    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
