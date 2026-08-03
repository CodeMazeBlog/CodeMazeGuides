using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RateLimitingDemo.Common.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ApiIntegrationTests
    {
        [TestMethod]
        public void WhenAppIsStarted_IpRateLimitOptionsAreLoadedSuccessfully()
        {
            using var factory = new WebApplicationFactory<Program>();
            
            var options = factory.Services.GetRequiredService<IOptions<IpRateLimitOptions>>();
            var generalRule = options.Value.GeneralRules[0];

            Assert.AreEqual(1, options.Value.GeneralRules.Count);
            Assert.AreEqual("GET:/products", generalRule.Endpoint);
            Assert.AreEqual("5s", generalRule.Period);
            Assert.AreEqual(2, generalRule.Limit);
        }

        [TestMethod]
        public async Task WhenOnlyOneRequest_Status200IsReturnedWithListOfProducts()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            
            var response = await httpClient.GetAsync($"/products");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            
            Assert.AreEqual(5, products?.ToList().Count);
        }

        [TestMethod]
        public async Task WhenExceedRateLimit_ExpectException()
        {
            using var factory = new WebApplicationFactory<Program>();
            var httpClient = factory.CreateClient();
            var requests = new List<string> { "1", "2", "3" };
            
            var allTasks = requests.Select(n => Task.Run(async () =>
            {
                var result = await httpClient.GetStringAsync($"/products");
               
            })).ToList();
            async Task ConcurrentApiRequests() => await Task.WhenAll(allTasks);
            
            var e = await Assert.ThrowsExceptionAsync<HttpRequestException>(ConcurrentApiRequests);
            Assert.AreEqual("Response status code does not indicate success: 429 (Too Many Requests).", e.Message);
        }       

    }
}
