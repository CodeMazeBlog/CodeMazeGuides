using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using RateLimitingDemo.UsingCustomMiddleware.Decorators;
using RateLimitingDemo.UsingCustomMiddleware.Extensions;
using RateLimitingDemo.UsingCustomMiddleware.Middlewares;
using System.IO;
using System.Threading.Tasks;

namespace Tests
{
    public class RateLimitingMiddlewareTests
    {
        private DefaultHttpContext _defaultHttpContext;
        private IDistributedCache _cache;

        [SetUp]
        public void SetUp()
        {
            _defaultHttpContext = new DefaultHttpContext();          
            var opts = Options.Create<MemoryDistributedCacheOptions>(new MemoryDistributedCacheOptions());
            _cache = new MemoryDistributedCache(opts);
        }

        [Test]
        public async Task WhenRateLimitingMiddlewareInvokedWithoutDecorator_NextDelegateIsCalled()
        {
            const string expectedOutput = "Request handed over to next request delegate";
            _defaultHttpContext.Response.Body = new MemoryStream();
            _defaultHttpContext.Request.Path = "/products"; 
            var middlewareInstance = new RateLimitingMiddleware(next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync(expectedOutput);
                return Task.CompletedTask;
            }, _cache);

            await middlewareInstance.InvokeAsync(_defaultHttpContext);
 
            _defaultHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(_defaultHttpContext.Response.Body).ReadToEnd();
            Assert.AreEqual(expectedOutput, body);
        }

        [Test]
        public async Task WhenRateLimitingMiddlewareInvokedWithDecorator_NextDelegateIsCalled()
        {
            const string expectedOutput = "Request handed over to next request delegate";
            _defaultHttpContext.Response.Body = new MemoryStream();
            _defaultHttpContext.Request.Path = "/products";
            _defaultHttpContext.Connection.RemoteIpAddress = new System.Net.IPAddress(16885952);
            var endpoint = CreateEndpoint(new LimitRequests { MaxRequests = 2, TimeWindow = 5 });
            _defaultHttpContext.SetEndpoint(endpoint);
            var middlewareInstance = new RateLimitingMiddleware(next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync(expectedOutput);
                return Task.CompletedTask;
            }, _cache);

            await middlewareInstance.InvokeAsync(_defaultHttpContext);

            _defaultHttpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(_defaultHttpContext.Response.Body).ReadToEnd();
            Assert.AreEqual(expectedOutput, body);
        }

        [Test]
        public async Task WhenProductsEndpointInvokedOnlyOnce_StatusCodeOkIsReturned()
        {       
            _defaultHttpContext.Response.Body = new MemoryStream();
            _defaultHttpContext.Request.Path = "/products";
            _defaultHttpContext.Connection.RemoteIpAddress = new System.Net.IPAddress(16885952);
            var endpoint = CreateEndpoint(new LimitRequests { MaxRequests = 2, TimeWindow = 5 });
            _defaultHttpContext.SetEndpoint(endpoint);
            var middlewareInstance = new RateLimitingMiddleware(next: (innerHttpContext) =>
            {               
                return Task.CompletedTask;
            }, _cache);

            await middlewareInstance.InvokeAsync(_defaultHttpContext);
            
            Assert.AreEqual(_defaultHttpContext.Response.StatusCode, 200);         
        }

        [Test]
        public async Task WhenProductsEndpointInvokedForThirdTimeIn5Seconds_StatusCodeTooManyRequestsIsReturned()
        {
            _defaultHttpContext.Response.Body = new MemoryStream();
            _defaultHttpContext.Request.Path = "/products";
            _defaultHttpContext.Connection.RemoteIpAddress = new System.Net.IPAddress(16885952);
            var endpoint = CreateEndpoint(new LimitRequests { MaxRequests = 2, TimeWindow = 5 });
            _defaultHttpContext.SetEndpoint(endpoint);
            var clientStatistics = new ClientStatistics { LastSuccessfulResponseTime = System.DateTime.UtcNow.AddSeconds(-2), NumberOfRequestsCompletedSuccessfully = 2 };
            await _cache.SetCahceValueAsync<ClientStatistics>("/products_192.168.1.1", clientStatistics);
            var middlewareInstance = new RateLimitingMiddleware(next: (innerHttpContext) =>
            {
                return Task.CompletedTask;
            }, _cache);

            await middlewareInstance.InvokeAsync(_defaultHttpContext);
                        
            Assert.AreEqual(_defaultHttpContext.Response.StatusCode, 429);
        }

        [Test]
        public async Task WhenProductsEndpointInvokedForThirdTimeAfter5Seconds_StatusCodeOkIsReturned()
        {
            _defaultHttpContext.Response.Body = new MemoryStream();
            _defaultHttpContext.Request.Path = "/products";
            _defaultHttpContext.Connection.RemoteIpAddress = new System.Net.IPAddress(16885952);
            var endpoint = CreateEndpoint(new LimitRequests { MaxRequests = 2, TimeWindow = 5 });
            _defaultHttpContext.SetEndpoint(endpoint);
            var clientStatistics = new ClientStatistics { LastSuccessfulResponseTime = System.DateTime.UtcNow.AddSeconds(-8), NumberOfRequestsCompletedSuccessfully = 2 };
            await _cache.SetCahceValueAsync<ClientStatistics>("/products_192.168.1.1", clientStatistics);
            var middlewareInstance = new RateLimitingMiddleware(next: (innerHttpContext) =>
            {
                return Task.CompletedTask;
            }, _cache);

            await middlewareInstance.InvokeAsync(_defaultHttpContext);

            Assert.AreEqual(_defaultHttpContext.Response.StatusCode, 200);
        }

        private Endpoint CreateEndpoint( params object[] metadata) => new Endpoint(context => Task.CompletedTask, new EndpointMetadataCollection(metadata), string.Empty);
       
    }
}