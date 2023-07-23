using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RecordsAsModelClasses.Core.DTOs;
using Xunit;

namespace Tests;

public class RecordsAsModelClassesUnitTest
{
    private readonly HttpClient _client;

    public RecordsAsModelClassesUnitTest()
    {
        var application = new WebApplicationFactory<Program>();
        _client = application.CreateClient();
    }

    [Fact]
    public async Task WhenCreateCarEndpointIsCalled_ThenCreateCar()
    {
        var carDto = new UpsertCarDto("Toyota", "Crown", 1960);
        var httpResponseMessage = await _client.PostAsJsonAsync("api/v1/cars", carDto);
        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        var deserializedResponse = JsonConvert.DeserializeObject<CarDto>(response);
        var expectedResponse = new CarDto(1, "Toyota", "Crown", 1960);

        Assert.Equal(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        Assert.Equal(expectedResponse, deserializedResponse);
    }

    [Fact]
    public async Task WhenUpdateCarEndpointIsCalled_ThenUpdateCar()
    {
        var carDto = new UpsertCarDto("Honda", "Accord", 2023);

        var httpResponseMessage = await _client.PutAsJsonAsync("api/v1/cars/1", carDto);

        Assert.Equal(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
    }

    [Fact]
    public async Task WhenGetCarUsingRecordsEndpointIsCalled_ThenReturnCreatedAction()
    {
        var httpResponseMessage = await _client.GetAsync($"api/v1/cars/{1}");

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
    }

    [Fact]
    public async Task WhenCreateClassCarEndpointIsCalled_ThenCreateClassCar()
    {
        var carDto = new UpsertCarDto("Chevrolet", "Corvette", 1972);

        var httpResponseMessage = await _client.PostAsJsonAsync("api/v2/cars", carDto);
        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        var deserializedResponse = JsonConvert.DeserializeObject<CarDto>(response);
        var expectedResponse = new CarDto(1, "Chevrolet", "Corvette", 1972);

        Assert.Equal(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        Assert.Equal(expectedResponse, deserializedResponse);
    }

    [Fact]
    public async Task WhenUpdateClassCarEndpointIsCalled_ThenUpdateClassCar()
    {
        var carDto = new UpsertCarDto("Chevrolet", "Corvette", 1972);

        var httpResponseMessage = await _client.PutAsJsonAsync("api/v2/cars/1", carDto);

        Assert.Equal(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
    }

    [Fact]
    public async Task WhenIdPassedToGetCarEndpoint_ThenReturnCreatedAction()
    {
        var httpResponseMessage = await _client.GetAsync($"api/v2/cars/{1}");

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
    }
}