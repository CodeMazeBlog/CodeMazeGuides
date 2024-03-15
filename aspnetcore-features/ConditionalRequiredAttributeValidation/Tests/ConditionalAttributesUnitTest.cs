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
    [InlineData("api/v1/work-items/create")]
    public async Task WhenWorkItemIsAssignedToAnAssignee_ThenReturn200Ok(string url)
    {
        var workItem = new WorkItem
        {
            Id = 1,
            Title = "Work item 1",
            IsAssigned = true,
            Assignee = "John Doe"
        };

        var response = await _client.PostAsJsonAsync(url, workItem);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/work-items/create")]
    public async Task WhenWorkItemIsUnAssignedDuringCreation_ThenReturn200Ok(string url)
    {
        var workItem = new WorkItem
        {
            Id = 2,
            Title = "Work item 2",
            IsAssigned = false,
            Assignee = string.Empty
        };

        var response = await _client.PostAsJsonAsync(url, workItem);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/v1/work-items/create")]
    public async Task WhenAnAssignedWorkItemHasNoAssignee_ThenReturnBadRequest(string url)
    {
        var workItem = new WorkItem
        {
            Id = 3,
            Title = "Work item 3",
            IsAssigned = true,
            Assignee = string.Empty
        };

        var response = await _client.PostAsJsonAsync(url, workItem);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}