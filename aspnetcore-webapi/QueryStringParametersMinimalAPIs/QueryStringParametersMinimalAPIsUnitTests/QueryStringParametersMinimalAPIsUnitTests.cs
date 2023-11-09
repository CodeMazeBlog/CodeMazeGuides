using Microsoft.AspNetCore.Mvc.Testing;

namespace QueryStringParametersMinimalAPIsUnitTests
{
    public class QueryStringParametersMinimalAPIsUnitTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _application;

        public QueryStringParametersMinimalAPIsUnitTests()
        {
            _application = new WebApplicationFactory<Program>();
            _client = _application.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenUsingSimpleQueryString_ThenParametersAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search1?author=john doe&yearPublished=2022");

            Assert.That(response, Is.EqualTo("Author: john doe, Year published: 2022"));
        }

        [Test]
        public async Task WhenUsingDefaultParameters_ThenParametersAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search2");

            Assert.That(response, Is.EqualTo("Author: N/A, Year published: 0"));
        }

        [Test]
        public async Task WhenUsingBindAsync_ThenParametersAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search3?author=john doe&yearPublished=2022");

            Assert.That(response, Is.EqualTo("Author: john doe, Year published: 2022"));
        }

        [Test]
        public async Task WhenUsingBindAsyncWithEmptyQueryString_ThenDefaultValuesAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search3");

            Assert.That(response, Is.EqualTo("Author: , Year published: 0"));
        }

        [Test]
        public async Task WhenParsingSimpleQueryStringWithCommas_ThenParametersAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search4?ids=1,3,5");

            Assert.That(response, Is.EqualTo("IDs: 1 3 5 "));
        }

        [Test]
        public async Task WhenUsingTryParse_TheParametersAreParsedSuccessfully()
        {
            var response = await _client.GetStringAsync("/search5?ids=1,3,5");

            Assert.That(response, Is.EqualTo("IDs: 1 3 5 "));
        }
    }
}