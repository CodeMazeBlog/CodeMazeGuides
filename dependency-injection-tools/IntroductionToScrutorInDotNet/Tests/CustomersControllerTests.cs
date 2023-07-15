using System.Net;
using System.Net.Http.Json;
using IntroductionToScrutorInDotNet.Customers.Entities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class CustomersControllerTests
{
    private readonly HttpClient _httpClient;

    public CustomersControllerTests()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenUser_WhenAddingCustomer_ThenCustomerIsReturned()
    {
        var response = await _httpClient.PostAsJsonAsync("/Customers", new
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        });

        var createdCustomer = await response.Content.ReadFromJsonAsync<Customer>();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(createdCustomer);
        Assert.NotEqual(default, createdCustomer.CustomerId);
        Assert.Equal("John Doe", createdCustomer.FullName);
    }
}