var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBrighter().AutoFromAssemblies(Assembly.GetAssembly(typeof(PingCommand)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/ping", (IAmACommandProcessor commandProcessor) =>
    {
        commandProcessor.Send(new PingCommand());

        return Results.Ok();
    }
)
.WithOpenApi();

app.MapGet("/ping-async", async (IAmACommandProcessor commandProcessor) =>
    {
        await commandProcessor.SendAsync(new PingAsyncCommand());

        return Results.Ok();
    }
)
.WithOpenApi();

app.Run();

public partial class Program { }
