namespace Tests;

public class Job2IntegrationTests : IClassFixture<ApiApplicationFactory>
{
    private readonly string _baseUri = "http://localhost:5000/api/jobs/";

    private readonly HttpClient _client;

    public Job2IntegrationTests(ApiApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GivenJobsController_WhenCreatingManyOccurrencesOfAGivenJobButUsingSkipConcurrentExecutionAttribute_ThenTheExtraJobsAreBeingSkipped()
    {
        // Arrange
        _client.BaseAddress = new Uri(_baseUri);
        HttpResponseMessage response;
        var processingCount = 1;

        // Act
        response = await _client.PostAsync("create-job-2", null);
        response.EnsureSuccessStatusCode();

        response = await _client.PostAsync("create-job-2", null);
        response.EnsureSuccessStatusCode();

        // Assert
        response = await _client.GetAsync("statistics");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        var statistics = JsonSerializer.Deserialize<StatisticsDto>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(statistics);
        Assert.Equal(processingCount, statistics.Processing);
    }
}