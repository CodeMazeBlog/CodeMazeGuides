namespace Tests;

public class Job1IntegrationTests : IClassFixture<ApiApplicationFactory>
{
    private readonly string _baseUri = "http://localhost:5000/api/jobs/";

    private readonly HttpClient _client;

    public Job1IntegrationTests(ApiApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GivenJobsController_WhenUsingDisableConcurrentExecutionAndInMemory_ThenJobsAreNotBeingSkipped()
    {
        // Arrange
        _client.BaseAddress = new Uri(_baseUri);
        HttpResponseMessage response;
        var processingCount = 1;

        // Act
        response = await _client.PostAsync("create-job-1", null);
        response.EnsureSuccessStatusCode();

        response = await _client.PostAsync("create-job-1", null);
        response.EnsureSuccessStatusCode();

        // Assert
        response = await _client.GetAsync("statistics");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        await Task.Delay(TimeSpan.FromSeconds(10));

        var statistics = JsonSerializer.Deserialize<StatisticsDto>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(statistics);
        Assert.NotEqual(processingCount, statistics.Processing);
    }
}