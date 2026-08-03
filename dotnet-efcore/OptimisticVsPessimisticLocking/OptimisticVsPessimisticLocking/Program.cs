using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using OptimisticVsPessimisticLocking;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamples();
builder.Services.AddSwaggerGen(opt => opt.ExampleFilters());
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

var user = "sa";
var password = "$trongPassword";
var portNumber = 1433;

// https://medium.com/codenx/integration-testing-using-testcontainers-in-net-8-520e8911d081
var container = new ContainerBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPortBinding(portNumber, true)
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("SQLCMDUSER", user)
                .WithEnvironment("SQLCMDPASSWORD", password)
                .WithEnvironment("MSSQL_SA_PASSWORD", password)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(portNumber))
                .Build();

await container.StartAsync();

var host = container.Hostname;
var port = container.GetMappedPublicPort(portNumber);

var connectionString =
    $"Server={host},{port};Database=master;User Id={user};Password={password};TrustServerCertificate=True";

builder.Services
    .AddDbContext<ApplicationDbContext>((sp, contextBuilder) => contextBuilder.UseSqlServer(connectionString), contextLifetime: ServiceLifetime.Scoped);

var app = builder.Build();

app.Lifetime.ApplicationStopped.Register(() =>
{
    container.StopAsync().GetAwaiter().GetResult();
    container.DisposeAsync().GetAwaiter().GetResult();
});

using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

await app.RunAsync();
