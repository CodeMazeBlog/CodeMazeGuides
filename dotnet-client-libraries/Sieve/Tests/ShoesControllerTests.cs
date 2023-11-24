using Microsoft.AspNetCore.Mvc.Testing;
using SievePackage;
using System.Net.Http.Json;

namespace Tests
{
    public class ShoesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private const string baseUrl = "/api/shoes";

        public ShoesControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenGetShoesEndpoint_WhenNoSortingOrFilteringApplied_ThenReturnsAllShoes()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(baseUrl);
            var content = await response.Content.ReadFromJsonAsync<List<Shoe>>();

            // Assert
            Assert.NotNull(content);
            Assert.Equal(3, content.Count);
        }

        [Fact]
        public async Task GivenGetShoesEndpoint_WhenSortingApplied_ThenReturnsAllShoesSorted()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{baseUrl}?sorts=Rating");
            var content = await response.Content.ReadFromJsonAsync<List<Shoe>>();

            // Assert
            Assert.NotNull(content);
            Assert.True(content.Last().Rating > content.First().Rating);
        }

        [Fact]
        public async Task GivenGetShoesEndpoint_WhenFilteringApplied_ThenReturnsFilteredListOfShoes()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{baseUrl}?filters=Brand@=Nike");
            var content = await response.Content.ReadFromJsonAsync<List<Shoe>>();

            // Assert
            Assert.NotNull(content);
            Assert.DoesNotContain(content, s => s.Brand == "Saucony");
        }

        [Fact]
        public async Task GivenGetShoesEndpoint_WhenPaginationApplied_ThenReturnsPaginatedListOfShoes()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{baseUrl}?pageSize=1");
            var content = await response.Content.ReadFromJsonAsync<List<Shoe>>();

            // Assert
            Assert.NotNull(content);
            Assert.True(content.Count == 1);
        }
    }
}