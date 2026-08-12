using IntroductionToWolverineLibrary.Models;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Host.UseWolverine( x =>
{
    x.PublishAllMessages().ToLocalQueue("local-queue");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/order", async (Order newOrder, IMessageBus bus) => await bus.InvokeAsync(newOrder))
    .WithName("NewBookOrder");

app.MapPost("/orderReply", async (Order newOrder, IMessageBus bus) =>
    await bus.InvokeAsync<string>(newOrder))
    .WithName("NewBookOrderReply");

app.MapPost("/bookReview", async (BookReview review, IMessageBus bus) =>
{
    await bus.PublishAsync(review);

    return Results.Ok("Book review submitted successfully.");
})
.WithName("BookReviewEndpoint");


app.MapControllers();

app.Run();
