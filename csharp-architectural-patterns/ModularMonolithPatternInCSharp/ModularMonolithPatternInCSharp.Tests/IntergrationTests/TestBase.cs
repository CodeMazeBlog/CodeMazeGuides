using Inventory.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Moq.Protected;
using Order.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ModularMonolithPatternInCSharp.Tests.IntergrationTests;

internal class TestBase
{
    protected readonly WebApplicationFactory<Program> _webApplicationFactory;
    protected readonly HttpClient _httpClient;

    public TestBase()
    {
        _webApplicationFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll<IInventoryRestClient>();

                    var item = new ItemDto
                    {
                        Id = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"),
                        Name = "Monitor",
                        Price = 119.99,
                        Quantity = 10
                    };

                    var inventoryRestClientMock = new Mock<IInventoryRestClient>();
                    inventoryRestClientMock.Setup(i => i.GetItem(It.IsAny<Guid>()))
                    .ReturnsAsync(item);
                    services.AddSingleton(inventoryRestClientMock.Object);

                });
            });
        _httpClient = _webApplicationFactory.CreateClient();
    }


    [OneTimeTearDown]
    public void TearDown()
    {
        _webApplicationFactory.Dispose();
        _httpClient.Dispose();
    }
}
