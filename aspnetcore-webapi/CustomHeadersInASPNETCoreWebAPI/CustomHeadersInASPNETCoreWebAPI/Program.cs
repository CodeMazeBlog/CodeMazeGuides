var builder = WebApplication.CreateBuilder(args);

var myCorsPolicy = "MyCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myCorsPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
            .WithExposedHeaders("x-my-custom-header");
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(myCorsPolicy);

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("x-my-custom-header", "middleware response");

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
