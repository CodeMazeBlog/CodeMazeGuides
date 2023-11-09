using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace UsingODataIntegrationTests
{
    public class UsingODataIntegrationTests
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _application;

        public UsingODataIntegrationTests()
        {
            _application = new WebApplicationFactory<Program>();
            _httpClient = _application.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenQueringForAllCompanies_ThenThreeCompaniesAreReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 3);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "1");

            id = json.value[1].ID.ToString();
            Assert.AreEqual(id, "2");

            id = json.value[2].ID.ToString();
            Assert.AreEqual(id, "3");
        }

        [Test]
        public async Task WhenQueringForACompany_ThenTheCorrectCompanyIsReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies(2)");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.ID.ToString(), "2");
        }

        [Test]
        public async Task WhenSkippingOneCompany_ThenTheNextThreeCompaniesAreReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$skip=1");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 3);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "2");

            id = json.value[1].ID.ToString();
            Assert.AreEqual(id, "3");

            id = json.value[2].ID.ToString();
            Assert.AreEqual(id, "4");
        }

        [Test]
        public async Task WhenSkippingOneAndAskingForTwo_ThenTheNextTwoCompaniesAreReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$top=2&$skip=1");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 2);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "2");

            id = json.value[1].ID.ToString();
            Assert.AreEqual(id, "3");
        }

        [Test]
        public async Task WhenFilteringById_ThenCorrectCompanyIsReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$filter=ID eq 1");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 1);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "1");
        }

        [Test]
        public async Task WhenFilteringByCompanySize_ThenCorrectCompaniesAreReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$filter=Size gt 50");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 2);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "2");

            id = json.value[1].ID.ToString();
            Assert.AreEqual(id, "4");
        }

        [Test]
        public async Task WhenOrderingBySize_ThenOrderIsReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$orderby=Size Desc");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.value.Count, 3);

            dynamic id = json.value[0].ID.ToString();
            Assert.AreEqual(id, "4");

            id = json.value[1].ID.ToString();
            Assert.AreEqual(id, "2");

            id = json.value[2].ID.ToString();
            Assert.AreEqual(id, "1");
        }
    }
}