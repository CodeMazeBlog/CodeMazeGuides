using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GlobalDefaultJsonSerializationoptionsUnitTests;

[TestClass]
public class GlobalJsonOptionsIntegrationTests
{
    private const string RequestBody = """
        {
          "Id": 1,
          "Name": null,
          "Price": 0,
          "Quantity": "5",
          "ReleaseDate": "2024-04-14T10:49:31.813Z",
          "Manufacturer": { "Name": "Apple", "Location": "California" }
        }
        """;

    private static HttpContent JsonContent() =>
        new StringContent(RequestBody, Encoding.UTF8, "application/json");

    private static WebApplicationFactory<Program> CreateFactory(bool useNewtonsoftJson) =>
        new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
                builder.UseSetting("UseNewtonsoftJson", useNewtonsoftJson.ToString()));

    private static async Task<JsonObject> PostAsync(HttpClient client, string route)
    {
        var response = await client.PostAsync(route, JsonContent());
        var body = await response.Content.ReadAsStringAsync();

        Assert.IsTrue(response.IsSuccessStatusCode, body);

        return JsonNode.Parse(body)!.AsObject();
    }

    [TestMethod]
    public async Task GivenSystemTextJsonOptions_WhenControllerActionResponds_ThenItAppliesTheConfiguredOptions()
    {
        using var factory = CreateFactory(useNewtonsoftJson: false);
        using var client = factory.CreateClient();

        var payload = await PostAsync(client, "/api/Product");

        // Camel casing, nulls dropped, and a number read from a string.
        CollectionAssert.AreEquivalent(
            new[] { "id", "price", "quantity", "releaseDate", "manufacturer" },
            payload.Select(property => property.Key).ToArray());
        Assert.AreEqual(5, (int)payload["quantity"]!);
        Assert.AreEqual("Apple", (string?)payload["manufacturer"]!["name"]);

        // The Newtonsoft date format is not registered on this run.
        Assert.AreNotEqual("14-04-2024", (string?)payload["releaseDate"]);
    }

    [TestMethod]
    public async Task GivenNewtonsoftJsonIsRegistered_WhenControllerActionResponds_ThenJsonNetWritesTheResponse()
    {
        using var factory = CreateFactory(useNewtonsoftJson: true);
        using var client = factory.CreateClient();

        var payload = await PostAsync(client, "/api/Product/save");

        // AddNewtonsoftJson() replaced the MVC formatters: Json.NET's date format
        // and DefaultValueHandling.Ignore are both visible in the response.
        CollectionAssert.AreEquivalent(
            new[] { "id", "quantity", "releaseDate", "manufacturer" },
            payload.Select(property => property.Key).ToArray());
        Assert.AreEqual("14-04-2024", (string?)payload["releaseDate"]);
    }

    [TestMethod]
    public async Task GivenNewtonsoftJsonIsRegistered_WhenMinimalApiEndpointResponds_ThenHttpJsonOptionsStillApply()
    {
        using var factory = CreateFactory(useNewtonsoftJson: true);
        using var client = factory.CreateClient();

        var payload = await PostAsync(client, "/api/Product/create");

        // MVC options and Http JSON options do not cascade: the minimal API
        // endpoint keeps serializing with System.Text.Json.
        CollectionAssert.AreEquivalent(
            new[] { "id", "price", "quantity", "releaseDate", "manufacturer" },
            payload.Select(property => property.Key).ToArray());
        Assert.AreNotEqual("14-04-2024", (string?)payload["releaseDate"]);
    }
}
