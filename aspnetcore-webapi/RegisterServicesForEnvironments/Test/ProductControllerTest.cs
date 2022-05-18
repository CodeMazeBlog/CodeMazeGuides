using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using RegisterServicesForEnvironments.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ProductControllerTest
    {
        private readonly HttpClient _client;

        public ProductControllerTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public async Task WhenCallProductControllerGetAllAction_Then3ProductRecordsAsResult()
        {
            var responce = await _client.GetAsync($"/Product/GetAll");
            var products = JsonConvert.DeserializeObject<List<Product>>(await responce.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
            Assert.AreEqual(3, products.Count);
        }
    }
}