namespace Tests;

public class Job1IntegrationTests
{
    private readonly string _baseUri = "http://localhost:5000/api/jobs/";

    [Fact]
    public async Task GivenJobsController_WhenCreatingManyOccurrencesOfAGivenJob_ThenTheyAreProcessedConcurrently()
    {
        // Arrange
        await using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();
        client.BaseAddress = new Uri(_baseUri);
        HttpResponseMessage response;
        var processingCount = 2;

        // Act
        response = await client.PostAsync("create-job-1", null);
        response.EnsureSuccessStatusCode();

        response = await client.PostAsync("create-job-1", null);
        response.EnsureSuccessStatusCode();

        // Assert
        response = await client.GetAsync("statistics");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        var statistics = JsonSerializer.Deserialize<StatisticsDto>(
            content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(statistics);
        Assert.Equal(processingCount, statistics.Processing);
    }
}