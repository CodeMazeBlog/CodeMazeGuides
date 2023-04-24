using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RecordsAsModelClasses.Core.DTOs;
using RecordsAsModelClasses.Core.Entities;
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
        var httpResponseMessage = await _client.PostAsync("api/cars/create-car", new StringContent(""));
        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        var deserializedResponse = JsonConvert.DeserializeObject<Car>(response);
        var expectedResponse = new Car(1, "Toyota", "Crown", 1952);

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        Assert.Equal(expectedResponse, deserializedResponse);
    }

    [Fact]
    public async Task WhenUpdateCarEndpointIsCalled_ThenUpdateCar()
    {
        var carDto = new CarDto("Honda", "Accord", 2023);

        var httpResponseMessage = await _client.PutAsJsonAsync("api/cars/1", carDto);

        Assert.Equal(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
    }

    [Fact]
    public async Task WhenUpdateCarUsingRecordsEndpointIsCalled_ThenUpdateCar()
    {
        var car = new Car(1, "Honda", "Civic", 2023);

        var httpResponseMessage = await _client.PutAsJsonAsync($"api/cars/car/{car.Id}", car);

        Assert.Equal(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
    }

    [Fact]
    public async Task WhenVintageCarCreateEndpointIsCalled_ThenCreateVintageCar()
    {
        var vintageCarDto = new VintageCarDto("Chevrolet", "Corvette", 1972);

        var httpResponseMessage = await _client.PostAsJsonAsync("api/cars/create-vintage-car", vintageCarDto);
        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        var deserializedResponse = JsonConvert.DeserializeObject<VintageCarDto>(response);
        var expectedResponse = vintageCarDto;

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        Assert.Equal(expectedResponse, deserializedResponse);
    }

    [Fact]
    public async Task WhenVintageCarUpdateEndpointIsCalled_ThenUpdateVintageCar()
    {
        var vintageCarDto = new VintageCarDto("Chevrolet", "Corvette", 1972);

        var httpResponseMessage = await _client.PutAsJsonAsync("api/cars/vintage-car/1", vintageCarDto);

        Assert.Equal(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
    }
}