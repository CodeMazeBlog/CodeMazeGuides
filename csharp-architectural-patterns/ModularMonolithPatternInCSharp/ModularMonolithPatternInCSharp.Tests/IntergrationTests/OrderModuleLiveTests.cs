using Inventory.Models;
using Order.Models;
using Order.ViewModels;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ModularMonolithPatternInCSharp.Tests.IntergrationTests;

internal class OrderModuleLiveTests : TestBase
{
    [Test, Order(1)]
    public async Task WhenICallTheAddOrderEndpoint_ThenItShouldReturnA200OkStatusCode()
    {
        // Arrange
        var orderViewModel = new OrderViewModel
        {
            Items =
            [
                new OrderItemViewModel() { ItemId = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"), Quantity = 2 }
            ]
        };
        var content = new StringContent(JsonSerializer.Serialize(orderViewModel), Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PostAsync($"/api/Order", content);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test, Order(2)]
    public async Task GivenThatICreatedAnOrder_WhenIGetAllItems_ThenIShouldSeeTheNewOrder()
    {
        // Arrange
        var expected = new List<OrderDto>
        {
            new()
            {
                Total = 239.98,
                Items =
                [
                    new()
                    {
                        ItemId = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"),
                        ItemName = "Monitor",
                        PricePerUnit = 119.99,
                        Quantity = 2,
                        Total = 239.98
                    }
                ]
            }
        };

        // Act
        var response = await _httpClient.GetAsync("/api/Order");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
        });

        var actual = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Has.Count.EqualTo(expected.Count));
        });

        var expectedFirstOrder = expected[0];
        var actualFirstOrder = actual[0];

        Assert.Multiple(() =>
        {
            Assert.That(actualFirstOrder.Total, Is.EqualTo(expectedFirstOrder.Total));
            Assert.That(actualFirstOrder.Items, Has.Count.EqualTo(expectedFirstOrder.Items.Count));
        });

        var expectedFirstOrderItem = expectedFirstOrder.Items[0];
        var actualFirstOrderItem = actualFirstOrder.Items[0];

        Assert.Multiple(() =>
        {
            Assert.That(actualFirstOrderItem.ItemId, Is.EqualTo(expectedFirstOrderItem.ItemId));
            Assert.That(actualFirstOrderItem.ItemName, Is.EqualTo(expectedFirstOrderItem.ItemName));
            Assert.That(actualFirstOrderItem.Quantity, Is.EqualTo(expectedFirstOrderItem.Quantity));
            Assert.That(actualFirstOrderItem.PricePerUnit, Is.EqualTo(expectedFirstOrderItem.PricePerUnit));
            Assert.That(actualFirstOrderItem.Total, Is.EqualTo(expectedFirstOrderItem.Total));
        });
    }

    [Test, Order(3)]
    public async Task GivenThatICreatedAnOrder_WhenIGetTheSelectedItem_ThenTheAmountShouldBeUpdated()
    {
        // Arrange
        var expected = new ItemDto() { Id = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"), Name = "Monitor", Quantity = 8, Price = 119.99 };

        // Act
        var response = await _httpClient.GetAsync($"/api/Item/{expected.Id}");

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var actual = await response.Content.ReadFromJsonAsync<ItemDto>();

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(expected.Id, Is.EqualTo(actual!.Id));
            Assert.That(expected.Name, Is.EqualTo(actual.Name));
            Assert.That(expected.Quantity, Is.EqualTo(actual.Quantity));
            Assert.That(expected.Price, Is.EqualTo(actual.Price));
            Assert.That(expected.IsOutOfStock, Is.EqualTo(actual.IsOutOfStock));
        });
    }
}
