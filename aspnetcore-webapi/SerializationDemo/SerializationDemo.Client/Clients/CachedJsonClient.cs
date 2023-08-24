using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SerializationDemo.Client.Serialization;
using SerializationDemo.Client.Serialization.Json;
using SerializationDemo.Common.Models;
using System.Net.Http.Headers;

namespace SerializationDemo.Client.Clients
{
    internal class CachedJsonClient : ClientBase, IClient
    {        
        private readonly IByteSerializer _serializer = new JsonByteSerializer();
        private readonly HttpClient _client = new HttpClient();
        private readonly IDistributedCache _distributedCache;
        private const string AllEmployeesKey = "AllEmployees";

        public CachedJsonClient()
        {            
            var collection = new ServiceCollection();
            collection.AddDistributedMemoryCache();
            IServiceProvider serviceProvider = collection.BuildServiceProvider();

            _distributedCache = serviceProvider.GetService<IDistributedCache>();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            // Find cached item
            byte[] objectFromCache = await _distributedCache.GetAsync(AllEmployeesKey);

            if (objectFromCache != null)
            {                
                var employees = _serializer.Deserialize<List<Employee>>(objectFromCache);
                return employees;
            }

            return await RefreshCache();
        }

        private async Task<HttpContent> GetResponseFromApi()
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await _client.SendAsync(request);
            
            return response.Content;           
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var url = $"{BaseUrl}/api/employees";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new ByteArrayContent(_serializer.Serialize(employee));
            request.Content.Headers.Add("Content-Type", "application/json");
            
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
              await RefreshCache();
            }

            return employee;
        }

        private async Task<List<Employee>> RefreshCache()
        {
            // If not found, then recalculate response
            var content = await GetResponseFromApi();

            var cacheEntryOptions = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(10))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            // Cache it
            var resultAsByteArray = _serializer.Serialize(await content.ReadAsStringAsync());
            await _distributedCache.SetAsync(AllEmployeesKey, resultAsByteArray, cacheEntryOptions);

            return _serializer.Deserialize<List<Employee>>(resultAsByteArray);
        }
    }
}