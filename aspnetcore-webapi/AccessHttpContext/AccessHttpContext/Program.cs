using AccessHttpContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ExampleService>();

var app = builder.Build();

app.UseRouting();

app.MapGroup("controllers").MapControllers();

app.MapGroup("minimal")
    .MapGet("/", context => context.Response.WriteAsync("Hello from minimal API"));

app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/middleware"),
    innerApp => innerApp.UseMiddleware<ExampleMiddleware>()
);

app.MapGroup("razors").MapRazorPages();

app.MapGet(
    "/service",
    (ExampleService service) => service.WriteToResponse("Hello from custom service")
);

app.Run();

public partial class Program { }