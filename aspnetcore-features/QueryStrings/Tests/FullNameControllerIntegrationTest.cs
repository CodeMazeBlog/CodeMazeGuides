using System.Net;

namespace Tests;

public class FullNameControllerIntegrationTest
{
    [Fact]
    public async Task WhenPassingQueryStringsAsScalerValues_ThenStatusCodeShouldBe200()
    {
        // ARRANGE
        await using var app = new Api();
        using var client = app.CreateClient();
        // ACT
        using var response = await client.GetAsync("/v1?firstName=John&lastName=Doe");
        // ASSERT
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("{\"fullName\":\"John Doe\"}", await response.Content.ReadAsStringAsync());

    }

    [Fact]
    public async Task WhenPassingQueryStringsAsArrayValues_ThenStatusCodeShouldBe200()
    {
        // ARRANGE
        await using var app = new Api();
        using var client = app.CreateClient();
        // ACT
        using var response = await client.GetAsync("/v2?ids=1&ids=2&ids=3");
        // ASSERT
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("{\"productIds\":[1,2,3]}", await response.Content.ReadAsStringAsync());

    }

    [Fact]
    public async Task WhenPassingQueryStringsAsObjectValues_ThenStatusCodeShouldBe200()
    {
        // ARRANGE
        await using var app = new Api();
        using var client = app.CreateClient();
        // ACT
        using var response = await client.GetAsync("/v3?FirstName=John&LastName=Doe");
        // ASSERT
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("{\"fullName\":\"John Doe\"}", await response.Content.ReadAsStringAsync());

    }
    
}