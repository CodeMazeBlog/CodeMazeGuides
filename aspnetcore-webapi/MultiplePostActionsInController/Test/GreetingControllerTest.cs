using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Test
{
    [TestClass]
    public class GreetingControllerTest
    {
        private readonly HttpClient _client;
        private const string _name = "Joe";

        public GreetingControllerTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public void WhenPostToGreetingController_ThenInternalServerError()
        {
            var responce = _client.PostAsJsonAsync($"/Greeting"
                 , _name).Result;

            Assert.AreEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToGreetingController_WithSayGoodMorningAction_ThenNotFound()
        {
            var responce = _client.PostAsJsonAsync("/Greeting/SayGoodMorning"
                 , _name).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToGreetingController_WithSayGoodEveningAction_ThenNotFound()
        {
            var responce = _client.PostAsJsonAsync("/Greeting/SayGoodEvening"
                 , _name).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToGreetingController_WithSayGoodAfternoonAction_ThenOK()
        {
            var responce = _client.PostAsJsonAsync("/Greeting/SayGoodAfternoon"
                 , _name).Result;

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }

        [TestMethod]
        public void WhenPostToGreetingController_WithSayGoodNightAction_ThenOK()
        {
            var responce = _client.PostAsJsonAsync("/Greeting/SayGoodNight"
                 , _name).Result;

            Assert.AreEqual(HttpStatusCode.OK, responce.StatusCode);
        }
    }
}