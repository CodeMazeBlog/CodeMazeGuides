using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using RedisCachingInCSharp.Services;

namespace Tests
{
    public class RedisTest
    {
        private readonly RedisCacheService _redisCacheService;
        private readonly IDistributedCache _cache;

        public RedisTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var cacheOptions = new RedisCacheOptions
            {
                Configuration = configuration.GetConnectionString("RedisConn"),
                InstanceName = "RedisTests_"
            };

            _cache = new RedisCache(cacheOptions);

            _redisCacheService = new RedisCacheService(_cache);
        }

        [Fact]
        public void GivenRedisDatabase_WhenRetrieveDataUsingKey_ThenReturnData()
        {
            var key = "Apples";
            var expectedValue = "How'd you like them?";

            _redisCacheService.SetCachedData(key, expectedValue, TimeSpan.FromSeconds(10));

            var actualValue = _redisCacheService.GetCachedData<string>(key);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}