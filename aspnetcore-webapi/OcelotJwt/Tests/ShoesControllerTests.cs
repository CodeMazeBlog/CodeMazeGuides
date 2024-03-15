using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ShoeApi.Models;
using System.Net;

namespace Tests;

public class ShoesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public ShoesControllerTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task WhenGettingShoes_ThenReturnShoeList()
    {
        // Arrange
        var client = _webApplicationFactory.CreateClient();

        // Act
        var result = await client.GetAsync("api/shoes");
        var content = await result.Content.ReadAsStringAsync();
        var shoes = JsonConvert.DeserializeObject<List<Shoe>>(content);

        //Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(shoes);
        Assert.True(shoes.Count > 0);
    }

    [Fact]
    public async Task GivenAValidShoeId_WhenDeletingShoe_ThenReturnNoContent()
    {
        // Arrange
        var client = _webApplicationFactory.CreateClient();

        // Act
        var result = await client.DeleteAsync("api/shoes/1");

        //Assert
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}