using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Text.Json;
using HttpClientUser;
using System.Net.Http.Headers;
using System;

namespace MockingHttpClient
{
    [TestClass]
    public class MockingHttpClientTests
    {
        private Mock<HttpMessageHandler> msgHandler;

        [TestInitialize]
        public void Initialize()
        {
            msgHandler = new Mock<HttpMessageHandler>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string baseAddress = "https://jokes-api.herokuapp.com";
            string jokeEndpoint = $"/api/joke/500";
            string joke = JsonSerializer.Serialize("haha joke");

            var requestMessage = new HttpRequestMessage()
            {
                Content = new StringContent(joke),
                Method = HttpMethod.Get,
                //Headers = new HttpRequestHeaders(HttpMethod.Get, baseAddress + jokeEndpoint),
                RequestUri = new Uri(baseAddress + jokeEndpoint),
            };

            msgHandler.Protected()
                //.Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.Equals(baseAddress+jokeEndpoint)), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(joke) }).Verifiable();

            Program.handler = msgHandler.Object;
            Program.Main(new string[] { });

            // Assert section
        }
    }
}