using BackgroundServiceExecuteAsyncAndStartAsync.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Tests.StartUps;

namespace Tests;

[TestClass]
public class IntegrationTests
{
    [TestMethod]
    public async Task GivenAStockPriceAppWithBackgroundService_WhenApiIsCalled_ThenDataIsPresent()
    {
        //Arrange
        using var testServer =
            new TestServer(
                new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<StockPricesStartUp>());

        using var client = testServer.CreateClient();

        // Act
        await Task.Delay(50);// allow some time for the initial call
        var response = await client.GetAsync("/api/stockprice");

        //Assert
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Content);

        response.EnsureSuccessStatusCode();
        string actualContent = await response.Content.ReadAsStringAsync();
        
        StockPrice[]? stocks = JsonSerializer.Deserialize<StockPrice[]>(actualContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
        Assert.IsTrue(stocks!.Length > 0);
    }
}