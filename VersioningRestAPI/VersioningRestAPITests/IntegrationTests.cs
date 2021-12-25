using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VersioningRestAPITests
{
    [TestClass]
    public class IntegrationTests
    {
        private HttpClient httpClient;
        [TestInitialize]
        public void Setup()
        {
            var catalogServiceUrl = "https://localhost:7114/";            
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(catalogServiceUrl);
        }

        [TestMethod]
        public async Task GivenDefaultCall_WhenCalledV1_ThenReturnStringStartingWithB()
        {
            var json = await httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.AreEqual(strings.Count, 2);
            StringAssert.StartsWith((string)strings[0],"B");
            StringAssert.StartsWith((string)strings[1], "B");
        }


        [TestMethod]
        public async Task GivenQueryString_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            var json = await httpClient.GetStringAsync("/api/StringList?api-version=2.0");
            var strings = JArray.Parse(json);
            Assert.AreEqual(strings.Count, 2);
            StringAssert.StartsWith((string)strings[0], "S");
            StringAssert.StartsWith((string)strings[1], "S");
        }


        [TestMethod]
        public async Task GivenHeader_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            httpClient.DefaultRequestHeaders.Add("X-Version", "2.0");
            var json = await httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.AreEqual(strings.Count, 2);
            StringAssert.StartsWith((string)strings[0], "S");
            StringAssert.StartsWith((string)strings[1], "S");
        }

        [TestMethod]
        public async Task GivenMediaType_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json; ver=2.0 ");
            var json = await httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.AreEqual(strings.Count, 2);
            StringAssert.StartsWith((string)strings[0], "S");
            StringAssert.StartsWith((string)strings[1], "S");
        }

        [TestMethod]
        public async Task GivenURLChange_WhenCalledV3_ThenReturnStringStartingWithC()
        {
            var json = await httpClient.GetStringAsync("/api/v3/StringList");
            var strings = JArray.Parse(json);
            Assert.AreEqual(strings.Count, 2);
            StringAssert.StartsWith((string)strings[0], "C");
            StringAssert.StartsWith((string)strings[1], "C");
        }
    }
}