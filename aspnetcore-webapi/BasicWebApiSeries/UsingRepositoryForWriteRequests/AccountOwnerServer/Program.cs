using AccountOwnerServer.Errors;
using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// NLog is registered as a logging provider, so ILogger<T> reaches the file targets in
// nlog.config as well as ILoggerManager. NLog finds nlog.config in the output directory
// on its own; there is nothing to load by hand.
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddAutoMapper(typeof(Program));

// Exceptions are handled here, once, instead of in a try/catch inside every action.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// UseForwardedHeaders goes first: every component after it has to see the client's
// scheme and address, not the proxy's, or an HTTPS redirect behind a proxy loops.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
