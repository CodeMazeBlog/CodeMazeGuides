using Microsoft.Extensions.Caching.Distributed;
using Moq;
using RedisCachingInCSharp.Services;
using System.Text.Json;

namespace Tests
{
    public class RedisTest
    {
        [Fact]
        public void GivenRedisCacheService_WhenGetCachedData_ThenReturnCachedValue()
        {
            var cacheData = new Dictionary<string, byte[]>();
            var cacheMock = new Mock<IDistributedCache>();
            var redisCacheService = new RedisCacheService(cacheMock.Object);
            var expectedValue = "How you like them?";
            var key = "Apples";

            cacheMock.Setup(x => x.Get(It.IsAny<string>()))
                .Returns((string key) => cacheData.ContainsKey(key) ? cacheData[key] : null);

            cacheData[key] = System.Text.Encoding.UTF8.GetBytes($"\"{expectedValue}\"");

            var result = redisCacheService.GetCachedData<string>(key);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void GivenRedisCacheService_WhenSetCachedData_ThenCacheValue()
        {
            var cacheData = new Dictionary<string, byte[]>();
            var cacheMock = new Mock<IDistributedCache>();
            var redisCacheService = new RedisCacheService(cacheMock.Object);
            var expectedValue = "How you like them?";
            var key = "Apples";
            var cacheDuration = TimeSpan.FromMinutes(10);

            cacheMock.Setup(x => x.Set(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>()))
                .Callback((string key, byte[] value, DistributedCacheEntryOptions options) =>
                {
                    cacheData[key] = value;
                });

            redisCacheService.SetCachedData(key, expectedValue, cacheDuration);

            Assert.True(cacheData.ContainsKey(key));
            Assert.Equal(expectedValue, JsonSerializer.Deserialize<string>(cacheData[key]));
        }
    }
}