using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using HttpClientUser;
using RichardSzalay.MockHttp;
using System;

namespace MockingHttpClient
{
    [TestClass]
    public class MockingHttpClientTests
    {
        private Mock<HttpMessageHandler>? _msgHandler;
        private MockHttpMessageHandler? _szalayMsgHandler;
        private string _baseAddress = "https://reqres.in/";
        private string _apiEndpoint = "api/users/2";
        private string _response = "this is a mocked response";

        [TestInitialize]
        public void Initialize()
        {
            _msgHandler = new Mock<HttpMessageHandler>();
            _szalayMsgHandler = new MockHttpMessageHandler();
        }

        [TestMethod]
        public async Task GivenMockedHandler_WhenRunningMain_ThenHandlerResponds()
        {
            var mockedProtected = _msgHandler.Protected();

            var setupApiRequest = mockedProtected.Setup<Task<HttpResponseMessage>>(
                "SendAsync", 
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>()
                );

            var apiMockedResponse = 
                setupApiRequest.ReturnsAsync(new HttpResponseMessage() 
                { 
                    StatusCode = HttpStatusCode.OK, 
                    Content = new StringContent(_response) 
                });

            apiMockedResponse.Verifiable();

            Program.Handler = _msgHandler!.Object;
            await Program.Main(new string[] { });

            _msgHandler.VerifyAll();
            Assert.AreEqual(_response, Program.Response);
        }

        [TestMethod]
        public void GivenHandlerMockedIncorrectly_WhenRunningMain_ThenHandlerThrowsException()
        {
            _apiEndpoint = $"/api/499";

            var mockedProtected = _msgHandler.Protected();

            var setupApiRequest = mockedProtected.Setup<Task<HttpResponseMessage>>(
                "SendAsync", 
                ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.Equals(_baseAddress + _apiEndpoint)), 
                ItExpr.IsAny<CancellationToken>());

            var apiMockedResponse = setupApiRequest.ReturnsAsync(new HttpResponseMessage() 
            { 
                StatusCode = HttpStatusCode.OK, 
                Content = new StringContent(_response) 
            });

            Program.Handler = _msgHandler!.Object;

            Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await Program.Main(new string[] { }));
        }

        [TestMethod]
        public async Task GivenMockedHandlerWithWildcard_WhenRunningMain_ThenHandlerResponds()
        {
            _szalayMsgHandler = new MockHttpMessageHandler();
            _szalayMsgHandler.When("https://reqres.in/*").Respond("text/plain", _response);

            Program.Handler = _szalayMsgHandler;
            await Program.Main(new string[] { });

            Assert.AreEqual(_response, Program.Response);
        }
    }
}