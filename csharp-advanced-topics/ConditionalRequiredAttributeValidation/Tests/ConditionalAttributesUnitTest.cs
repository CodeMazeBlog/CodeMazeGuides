using System.Net;
using System.Net.Http.Json;
using ConditionalRequiredAttributeValidation.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class ConditionalAttributesUnitTest
{
    private readonly HttpClient _client;

    public ConditionalAttributesUnitTest()
    {
        var application = new WebApplicationFactory<Program>();
        _client = application.CreateClient();
    }

    [Theory]
    [InlineData("api/v1/orders/place-order")]
    public async Task WhenAccurateOrderDataIsPassed_ThenReturn2ooOk(string url)
    {
        var order = new Order
        {
            IsExpressShipping = true,
            ShippingAddress = "1234 Street",
            CustomerName = "John Doe",
            DeliveryDate = new DateTime(2024, 1, 28),
            ProductId = 5,
            ProductDescription = "Test Product"
        };

        var response = await _client.PostAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/orders/place-order")]
    public async Task WhenInvalidShippingAddressIsPassed_ThenReturnBadRequest(string url)
    {
        var order = new Order
        {
            IsExpressShipping = true,
            ShippingAddress = "",
            CustomerName = "John Doe",
            DeliveryDate = new DateTime(2024, 1, 28),
            ProductId = 5,
            ProductDescription = "Test Product"
        };

        var response = await _client.PostAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/orders/place-order")]
    public async Task WhenExpressShippingIsFalse_ThenConditionallyValidateShippingAddress(string url)
    {
        var order = new Order
        {
            IsExpressShipping = false,
            ShippingAddress = "",
            CustomerName = "Test Customer",
            DeliveryDate = null,
            ProductId = 5,
            ProductDescription = "Test Product"
        };

        var response = await _client.PostAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/orders/place-order")]
    public async Task WhenEmptyCustomerNameIsPassed_ThenReturnBadRequest(string url)
    {
        var order = new Order
        {
            IsExpressShipping = true,
            ShippingAddress = "1234 Test Street",
            CustomerName = "",
            DeliveryDate = new DateTime(2024, 1, 28),
            ProductId = 5,
            ProductDescription = "Test Product"
        };

        var response = await _client.PostAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/orders/place-order")]
    public async Task WhenDeliveryDateIsNull_ThenReturnBadRequest(string url)
    {
        var order = new Order
        {
            IsExpressShipping = true,
            ShippingAddress = "1234 Test Street",
            CustomerName = "",
            DeliveryDate = null,
            ProductId = 5,
            ProductDescription = "Test Product"
        };

        var response = await _client.PostAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}