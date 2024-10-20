namespace OptimisticVsPessimisticLocking.IntegrationTests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

public class WorkItemControllerUnitTests
{
    private const int SeededWorkItemId = 1;
    private const int SeededWorkItemWithAutomaticVersioningId = 2;
    private const int SeededWorkItemWithManualVersioningId = 3;
    private const int NonExistingWorkitemId = 999;

    private readonly HttpClient _client;

    public WorkItemControllerUnitTests()
    {
        var factory = new WebApplicationFactory<Program>();

        _client = factory.CreateClient();
    }

    // Pessimistic Locking Tests

    [Fact]
    public async Task GivenExistingWorkItem_WhenAssigningWithPessimisticLock_ThenReturnOk()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(SeededWorkItemId, "John Doe");

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-pessimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenNonExistingWorkItem_WhenAssigningWithPessimisticLock_ThenReturnNotFound()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(NonExistingWorkitemId, "John Doe");

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-pessimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GivenExistingWorkItemWithAutomaticVersioning_WhenNoConflictAndAssigning_ThenReturnOk()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(SeededWorkItemWithAutomaticVersioningId, "Jane Doe", false);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-auto-optimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenExistingWorkItemWithAutomaticVersioning_WhenForceConflictInOptimisticLock_ThenReturnConflict()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(SeededWorkItemWithAutomaticVersioningId, "Jane Doe", true);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-auto-optimistic", assignWorkItemRequest);

        // Assert 
        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task GivenNonExistingWorkItemWithAutomaticVersioning_WhenAssigningWithOptimisticLock_ThenReturnNotFound()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(NonExistingWorkitemId, "Jane Doe", false);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-auto-optimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }


    [Fact]
    public async Task GivenExistingWorkItemWithManualVersioning_WhenNoConflictAndAssigning_ThenReturnOk()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(SeededWorkItemWithManualVersioningId, "Jane Doe", false);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-manual-optimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenExistingWorkItemManualVersioning_WhenForceConflictInOptimisticLock_ThenReturnConflict()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(SeededWorkItemWithManualVersioningId, "Jane Doe", true);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-manual-optimistic", assignWorkItemRequest);

        // Assert 
        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task GivenNonExistingWorkItemManualVersioning_WhenAssigningWithOptimisticLock_ThenReturnNotFound()
    {
        // Arrange
        var assignWorkItemRequest = new AssignWorkItemRequest(NonExistingWorkitemId, "Jane Doe", false);

        // Act
        var response = await _client.PostAsJsonAsync("/workItem/assign-manual-optimistic", assignWorkItemRequest);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}