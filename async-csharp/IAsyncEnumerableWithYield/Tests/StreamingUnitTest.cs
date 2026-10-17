using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;

namespace Tests;

[TestClass]
public class StreamingUnitTest
{
    private static readonly string DatabasePath =
        Path.Combine(Path.GetTempPath(), $"items-{Guid.NewGuid():N}.db");

    private static WebApplicationFactory<Program> _factory = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext _)
    {
        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
                builder.UseSetting("ConnectionStrings:Items", $"Data Source={DatabasePath}"));
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _factory.Dispose();
        SqliteConnection.ClearAllPools();
        File.Delete(DatabasePath);
    }

    [TestMethod]
    public async Task GivenValuesController_WhenGetIsCalled_ThenFirstItemArrivesBeforeTheLast()
    {
        await AssertStreamsTenItems("/api/values");
    }

    [TestMethod]
    public async Task GivenMinimalApiEndpoint_WhenItemsAreRequested_ThenFirstItemArrivesBeforeTheLast()
    {
        await AssertStreamsTenItems("/items");
    }

    [TestMethod]
    public async Task GivenItemsController_WhenGetItemsIsCalled_ThenEveryRowIsReturned()
    {
        using var client = _factory.CreateClient();

        var body = await client.GetStringAsync("/api/items");

        Assert.AreEqual(
            """[{"id":1,"name":"Keyboard"},{"id":2,"name":"Mouse"},{"id":3,"name":"Monitor"}]""",
            body);
    }

    private static async Task AssertStreamsTenItems(string url)
    {
        using var client = _factory.CreateClient();
        var stopwatch = Stopwatch.StartNew();

        using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        await using var stream = await response.Content.ReadAsStreamAsync();

        var received = new StringBuilder();
        var buffer = new byte[64];
        while (!received.ToString().StartsWith("[1"))
        {
            var read = await stream.ReadAsync(buffer);
            Assert.AreNotEqual(0, read, "The response ended before the first item arrived.");
            received.Append(Encoding.UTF8.GetString(buffer, 0, read));
        }

        var firstItemAfter = stopwatch.Elapsed;

        using var reader = new StreamReader(stream);
        received.Append(await reader.ReadToEndAsync());
        var lastItemAfter = stopwatch.Elapsed;

        Assert.AreEqual("[1,2,3,4,5,6,7,8,9,10]", received.ToString());
        Assert.IsLessThan(TimeSpan.FromSeconds(5), firstItemAfter);
        Assert.IsGreaterThanOrEqualTo(TimeSpan.FromSeconds(9), lastItemAfter);
    }
}
