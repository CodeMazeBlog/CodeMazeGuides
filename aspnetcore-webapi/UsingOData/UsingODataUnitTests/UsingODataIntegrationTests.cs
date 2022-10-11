using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;

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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies(2)");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            Assert.AreEqual(json.ID.ToString(), "2");
        }

        [Test]
        public async Task WhenSkippingOneCompany_ThenTheNextThreeCompaniesAreReturned()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$skip=1");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$top=2&$skip=1");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$filter=ID eq 1");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$filter=Size gt 50");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7004/odata/Companies?$orderby=Size Desc");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
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