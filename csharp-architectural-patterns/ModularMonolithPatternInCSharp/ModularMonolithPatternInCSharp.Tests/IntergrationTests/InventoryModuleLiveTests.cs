using Inventory.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;


namespace ModularMonolithPatternInCSharp.Tests.IntergrationTests;

internal class InventoryModuleLiveTests : TestBase
{
    [Test]
    public async Task WhenICallTheGetItemEndpoint_ThenItShouldReturnTheRequestedItem()
    {
        // Arrange
        var expected = new ItemDto() { Id = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"), Name = "Monitor", Quantity = 10, Price = 119.99 };

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

    [Test]
    public async Task WhenICallTheGetAllItemsEndpoint_ThenItShouldReturnAllItems()
    {
        // Arrange
        List<ItemDto> expected =
        [
            new() { Id = Guid.Parse("111f9883-4b53-41eb-bcc3-8f4e6f29edf6"), Name = "Monitor", Quantity = 10, Price = 119.99 },
            new() { Id = Guid.Parse("bdabc506-3cac-47bf-b30b-a175e53cedfe"), Name = "Laptop", Quantity = 5, Price = 499.99 },
            new() { Id = Guid.Parse("e9386ab6-6a40-4fdf-876b-8efa7a3d30f0"), Name = "Keyboard", Quantity = 12, Price = 11.99 },
            new() { Id = Guid.Parse("14e92630-424a-4fd3-8657-4e56da9baf6b"), Name = "Mouse", Quantity = 15, Price = 7.99 }
        ];

        // Act
        var response = await _httpClient.GetAsync("/api/Item");


        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var actual = await response.Content.ReadFromJsonAsync<List<ItemDto>>();
        Assert.That(actual, Is.Not.Null);

        foreach (var actaulItem in actual)
        {
            var expectedItemIndex = actual.IndexOf(actaulItem);
            var expectedItem = expected[expectedItemIndex];
            Assert.Multiple(() =>
            {
                Assert.That(actaulItem, Is.Not.Null);
                Assert.That(expectedItem.Id, Is.EqualTo(actaulItem!.Id));
                Assert.That(expectedItem.Name, Is.EqualTo(actaulItem.Name));
                Assert.That(expectedItem.Quantity, Is.EqualTo(actaulItem.Quantity));
                Assert.That(expectedItem.Price, Is.EqualTo(actaulItem.Price));
                Assert.That(expectedItem.IsOutOfStock, Is.EqualTo(actaulItem.IsOutOfStock));
            });
        }
    }
}
