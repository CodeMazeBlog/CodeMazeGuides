var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBrighter().AutoFromAssemblies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/ping", (
    [FromServices] IAmACommandProcessor commandProcessor) =>
{
    commandProcessor.Send(new PingCommand());
    return Results.Ok();
})
.WithName("ping")
.WithOpenApi();

app.MapGet("/ping-async", async (
    [FromServices] IAmACommandProcessor commandProcessor) =>
{
    await commandProcessor.SendAsync(new PingAsyncCommand());
    return Results.Ok();
})
.WithName("ping-async")
.WithOpenApi();


app.Run();
