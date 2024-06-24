using DotNet.Testcontainers.Builders;
using EfCoreInterceptors;
using EfCoreInterceptors.DbContextInterceptors;
using EfCoreInterceptors.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

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
    .AddSingleton<TimeProvider>(TimeProvider.System)
    .AddSingleton<IEmailService, EmailService>()
    .AddScoped<ConnectionInterceptor>()
    .AddScoped<ValidateEntitiesStateInterceptor>()
    .AddScoped<AuditableEntitiesInterceptor>()
    .AddScoped<TransactionInterceptor>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, contextBuilder) =>
{
    contextBuilder
        .UseSqlServer(connectionString)
        .AddInterceptors(
            sp.GetRequiredService<ConnectionInterceptor>(),
            sp.GetRequiredService<ValidateEntitiesStateInterceptor>(),
            sp.GetRequiredService<AuditableEntitiesInterceptor>(),
            sp.GetRequiredService<TransactionInterceptor>());
}, contextLifetime: ServiceLifetime.Scoped);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapPost("/register-user", async (AddUserRequest addUserRequest,
                                     IEmailService emailService,
                                     ApplicationDbContext dbContext,
                                     CancellationToken cancellationToken) =>
{
    var user = new User { Name = addUserRequest.Name, Email = addUserRequest.Email };

    using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

    try
    {
        dbContext.Users.Add(user);

        await dbContext.SaveChangesAsync(cancellationToken);

        var emailSent = await emailService.SendWelcomeEmailAsync(user.Id, user.Name, user.Email);
        if (!emailSent)
            throw new Exception("Failed to send welcome email");

        await transaction.CommitAsync(cancellationToken);

        return Results.Ok();
    }
    catch (Exception)
    {
        await transaction.RollbackAsync(cancellationToken);

        return Results.Problem(detail: "Registration failed!", statusCode: StatusCodes.Status500InternalServerError);
    }
})
.WithOpenApi();

app.Run();