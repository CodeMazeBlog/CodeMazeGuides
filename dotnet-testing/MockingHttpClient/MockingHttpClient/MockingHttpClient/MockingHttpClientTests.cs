using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Text.Json;
using HttpClientUser;
using RichardSzalay.MockHttp;
using System;

namespace MockingHttpClient
{
    [TestClass]
    public class MockingHttpClientTests
    {
        private Mock<HttpMessageHandler> msgHandler;
        private MockHttpMessageHandler szalayMsgHandler;
        private string baseAddress = "https://jokes-api.herokuapp.com";
        private string jokeEndpoint = $"/api/joke/500";
        private string joke = "this is a mocked joke";

        [TestInitialize]
        public void Initialize()
        {
            msgHandler = new Mock<HttpMessageHandler>();
            szalayMsgHandler = new MockHttpMessageHandler();

        }

        [TestMethod]
        public void GivenMockedHandler_WhenRunningMain_ThenHandlerResponds()
        {
            msgHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(joke) })
                .Verifiable();

            Program.handler = msgHandler.Object;
            Program.Main(new string[] { });

            msgHandler.VerifyAll();
            Assert.AreEqual(joke, Program.jokeResponse);
        }

        [TestMethod]
        public void GivenHandlerMockedIncorrectly_WhenRunningMain_ThenHandlerThrowsException()
        {
            jokeEndpoint = $"/api/joke/499";

            msgHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.Equals(baseAddress + jokeEndpoint)), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(joke) });

            Program.handler = msgHandler.Object;

            Assert.ThrowsException<AggregateException>(() => Program.Main(new string[] { }));
        }

        [TestMethod]
        public void GivenMockedHandlerWithWildcard_WhenRunningMain_ThenHandlerResponds()
        {
            szalayMsgHandler = new MockHttpMessageHandler();
            szalayMsgHandler.When("https://jokes-api.herokuapp.com/api/joke/*").Respond("text/plain", joke);

            Program.handler = szalayMsgHandler;
            Program.Main(new string[] { });

            Assert.AreEqual(joke, Program.jokeResponse);
        }
    }
}