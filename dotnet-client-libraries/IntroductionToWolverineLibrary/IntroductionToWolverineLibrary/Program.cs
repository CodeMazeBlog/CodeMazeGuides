using IntroductionToWolverineLibrary.Models;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Host.UseWolverine( x =>
{
    x.PublishAllMessages().ToLocalQueue("local-queue");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/order", async (Order newOrder, IMessageBus bus) => await bus.InvokeAsync(newOrder))
    .WithName("NewBookOrder")
    .WithOpenApi();

app.MapPost("/orderReply", async (Order newOrder, IMessageBus bus) => 
    await bus.InvokeAsync<string>(newOrder))
    .WithName("NewBookOrderReply")
    .WithOpenApi();

app.MapPost("/bookReview", async (BookReview review, IMessageBus bus) =>
{
    await bus.PublishAsync(review);

    return Results.Ok("Book review submitted successfully.");
})
.WithName("BookReviewEndpoint")
.WithOpenApi();


app.MapControllers();

app.Run();