using BenchmarkDotNet.Attributes;
using Services;
using Microsoft.Extensions.Configuration;
using BenchmarkDotNet.Order;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Declared)]
    [MaxIterationCount(40)]
    public class LocationServicesBenchmark
    {
        private GoogleLocationServiceWrapper? locationService;
        private LatLongWithNuGet? latLongWithNuGet;
        private LatLongWithHttpClient? latLongWithHttpClient;
        private string address = "Fort Myers, Florida";
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
            latLongWithHttpClient = new LatLongWithHttpClient(new HttpClient { BaseAddress = new Uri("https://maps.googleapis.com/") }, apiKey);
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
