namespace GenerateUniqueIDsWithNewId.Tests;

public class OrdersEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenGetOrdersEndpointIsInvoked_ThenAllOrdersAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/orders");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetOrderEndpointIsInvoked_ThenOrderIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var order = new OrderForCreationDto
        {
            CustomerName = "Marcel Waters",
            Products = ["Piano"],
            TotalAmount = 599.99M
        };

        var response = await client.PostAsJsonAsync("/orders", order);
        var createdOrder = JsonSerializer.Deserialize<OrderDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.GetAsync($"/orders/{createdOrder!.Id}");
        var returnedOrder = JsonSerializer.Deserialize<OrderDto>(
            await result.Content.ReadAsStringAsync(), _options);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedOrder.Should().NotBeNull();
        returnedOrder!.CustomerName.Should().Be(order.CustomerName);
        returnedOrder.Products.Should().BeEquivalentTo(order.Products);
        returnedOrder.TotalAmount.Should().Be(order.TotalAmount);
    }

    [Fact]
    public async Task WhenAddOrderEndpointIsInvoked_ThenOrderIsAdded()
    {
        // Arrange
        var client = factory.CreateClient();
        var order = new OrderForCreationDto
        {
            CustomerName = "Marcel Waters",
            Products = ["Piano"],
            TotalAmount = 599.99M
        };

        // Act
        var response = await client.PostAsJsonAsync("/orders", order);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task WhenUpdateOrderEndpointIsInvoked_ThenOrderIsUpdated()
    {
        // Arrange
        var client = factory.CreateClient();
        var order = new OrderForCreationDto
        {
            CustomerName = "Marcel Waters",
            Products = ["Piano"],
            TotalAmount = 599.99M
        };
        var createdOrderResponse = await client.PostAsJsonAsync("/orders", order);
        var createdOrder = JsonSerializer.Deserialize<OrderDto>(
            await createdOrderResponse.Content.ReadAsStringAsync(),
            _options);
        var orderForUpdate = new OrderForUpdateDto
        {
            CustomerName = "Marcel Waters",
            Products = ["Guitar"],
            TotalAmount = 199.99M
        };

        // Act
        await client.PutAsJsonAsync($"/orders/{createdOrder!.Id}", orderForUpdate);

        // Assert
        var updatedOrderResponse = await client.GetAsync($"/orders/{createdOrder!.Id}");
        var updatedOrder = JsonSerializer.Deserialize<OrderDto>(
            await updatedOrderResponse.Content.ReadAsStringAsync(), _options);

        updatedOrderResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        updatedOrder!.Should().NotBeNull();
        updatedOrder!.CustomerName.Should().Be(orderForUpdate.CustomerName);
        updatedOrder.Products.Should().BeEquivalentTo(orderForUpdate.Products);
        updatedOrder.TotalAmount.Should().Be(orderForUpdate.TotalAmount);
    }

    [Fact]
    public async Task WhenDeleteCatEndpointIsInvoked_ThenCatIsDeleted()
    {
        // Arrange
        var client = factory.CreateClient();
        var order = new OrderForCreationDto
        {
            CustomerName = "Marcel Waters",
            Products = ["Guitar"],
            TotalAmount = 199.99M
        };
        var response = await client.PostAsJsonAsync("/orders", order);
        var orderDto = JsonSerializer.Deserialize<OrderDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.DeleteAsync($"/orders/{orderDto!.Id}");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
