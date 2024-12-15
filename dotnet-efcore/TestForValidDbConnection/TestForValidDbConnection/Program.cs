using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TestForValidDbConnection;

var builder = WebApplication.CreateBuilder(args);

var user = "sa";
var password = "$trongPassword";
var portNumber = 1433;

// https://medium.com/codenx/integration-testing-using-testcontainers-in-net-8-520e8911d081
var container = new ContainerBuilder()
                .WithName("SqlServerTestContainerDb")
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPortBinding(portNumber, true)
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("SQLCMDUSER", user)
                .WithEnvironment("SQLCMDPASSWORD", password)
                .WithEnvironment("MSSQL_SA_PASSWORD", password)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(portNumber))
                .WithReuse(true)
                .Build();

await container.StartAsync();

var host = container.Hostname;
var port = container.GetMappedPublicPort(portNumber);

var connectionString =
    $"Server={host},{port};Database=master;User Id={user};Password={password};TrustServerCertificate=True";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString),
    contextLifetime: ServiceLifetime.Scoped);

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>("Database Health", failureStatus: HealthStatus.Unhealthy);

var app = builder.Build();

app.Lifetime.ApplicationStopped.Register(() =>
{
    container.StopAsync().GetAwaiter().GetResult();
    container.DisposeAsync().GetAwaiter().GetResult();
});

app.UseHttpsRedirection();
app.MapHealthChecks("/health");

app.MapGet("/can-connect", async (ApplicationDbContext applicationDbContext, CancellationToken cancellationToken) =>
{
    var canConnect = await applicationDbContext.Database.CanConnectAsync(cancellationToken);

    return canConnect
        ? Results.Ok("Connected successfully")
        : Results.Problem("Cannot connect", statusCode: StatusCodes.Status503ServiceUnavailable);
});

await app.RunAsync();