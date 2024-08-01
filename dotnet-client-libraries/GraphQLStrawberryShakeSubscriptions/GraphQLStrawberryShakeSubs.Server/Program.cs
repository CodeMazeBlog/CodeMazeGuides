using GraphQLStrawberryShakeSubs.Server;
using GraphQLStrawberryShakeSubs.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=shipping.db");
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscriptions>()
    .AddInMemorySubscriptions();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    Seed.Initialize(context);
}

app.UseWebSockets();
app.MapGraphQL();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program { }
