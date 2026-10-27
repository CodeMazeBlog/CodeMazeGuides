using WebApiBestPractices.Api.Extensions;
using WebApiBestPractices.Api.Handlers;
using WebApiBestPractices.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureOutputCache();
builder.Services.ConfigureRateLimiting(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;
})
.AddXmlSerializerFormatters();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(ServiceExtensions.CorsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseOutputCache();

app.MapControllers();

// The same data through a Minimal API endpoint, for comparison.
app.MapGet("/api/minimal/owners", async (IOwnerService ownerService, CancellationToken cancellationToken) =>
    TypedResults.Ok(await ownerService.GetAllAsync(cancellationToken)));

app.Run();
