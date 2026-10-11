using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ItemContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Items")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ItemContext>();
    context.Database.EnsureCreated();

    if (!context.Items.Any())
    {
        context.Items.AddRange(
            new Item { Name = "Keyboard" },
            new Item { Name = "Mouse" },
            new Item { Name = "Monitor" });
        context.SaveChanges();
    }
}

app.MapControllers();

app.MapGet("/items", () => FetchItems());

app.Run();

static async IAsyncEnumerable<int> FetchItems()
{
    for (var i = 1; i <= 10; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}
