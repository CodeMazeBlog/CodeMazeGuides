using PizzaShop.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = context.HttpContext.Request.Path;

        if (context.Exception is not null && builder.Environment.IsDevelopment())
            context.ProblemDetails.Extensions["exception"] = context.Exception.Message;
    };
});
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapPizzaEndpoints();

app.Run();
