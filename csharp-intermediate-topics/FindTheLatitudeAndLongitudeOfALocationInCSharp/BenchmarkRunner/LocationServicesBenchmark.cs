using BenchmarkDotNet.Attributes;
using Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BenchmarkDotNet.Order;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MaxIterationCount(40)]
    public class LocationServicesBenchmark
    {
        private GoogleLocationServiceWrapper? locationService;
        private LatLongWithNuGet? latLongWithNuGet;
        private LatLongWithHttpClient? latLongWithHttpClient;
        private string address = "Miami, Florida";
        private string? apiKey;

        [GlobalSetup]
        public void Setup()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
            var configuration = builder.Build();
            apiKey = configuration["YOUR_API_KEY"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("API key not found. Please make sure it's set in the user secrets.");
            }

            locationService = new GoogleLocationServiceWrapper(apiKey);
            latLongWithNuGet = new LatLongWithNuGet(locationService!);

            var services = new ServiceCollection();
            services.AddHttpClient();
            var serviceProvider = services.BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            latLongWithHttpClient = new LatLongWithHttpClient(httpClientFactory!, apiKey);
        }

        [Benchmark]
        public async Task<string> Benchmark_GetLatLongWithHttpClient()
        {
            return await latLongWithHttpClient!.GetLatLongWithHttpClient(address);
        }

        [Benchmark]
        public string Benchmark_GetLatLongWithNuGet()
        {
            return latLongWithNuGet!.GetLatLongWithNuGet(address);
        }
    }
}
