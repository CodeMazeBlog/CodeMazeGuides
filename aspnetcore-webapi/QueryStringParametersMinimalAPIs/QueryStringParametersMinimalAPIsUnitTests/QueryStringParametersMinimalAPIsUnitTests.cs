using Microsoft.AspNetCore.Mvc.Testing;

namespace QueryStringParametersMinimalAPIsUnitTests
{
    public class QueryStringParametersMinimalAPIsUnitTests
    {
        private HttpClient? httpClient;
        private WebApplicationFactory<Program>? _factory;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenUsingSimpleQueryString_ThenParametersAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search1?author=john doe&yearPublished=2022");

            Assert.That(response, Is.EqualTo("Author: john doe, Year published: 2022"));
        }

        [Test]
        public async Task WhenUsingDefaultParameters_ThenParametersAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search2");

            Assert.That(response, Is.EqualTo("Author: N/A, Year published: 0"));
        }

        [Test]
        public async Task WhenUsingBindAsync_ThenParametersAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search3?author=john doe&yearPublished=2022");

            Assert.That(response, Is.EqualTo("Author: john doe, Year published: 2022"));
        }

        [Test]
        public async Task WhenUsingBindAsyncWithEmptyQueryString_ThenDefaultValuesAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search3");

            Assert.That(response, Is.EqualTo("Author: , Year published: 0"));
        }

        [Test]
        public async Task WhenParsingSimpleQueryStringWithCommas_ThenParametersAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search4?ids=1,3,5");

            Assert.That(response, Is.EqualTo("IDs: 1 3 5 "));
        }

        [Test]
        public async Task WhenUsingTryParse_TheParametersAreParsedSuccessfully()
        {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/search5?ids=1,3,5");

            Assert.That(response, Is.EqualTo("IDs: 1 3 5 "));
        }
    }
}