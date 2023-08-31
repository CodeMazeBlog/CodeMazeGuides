using BenchmarkDotNet.Attributes;

namespace SwashbuckleVsNSwag.Benchmark
{
    [MemoryDiagnoser(false)]
    public class SwashbuckleVsNSwagBenchmark
    {
        public readonly int _size = 100;

        private readonly RestClient _restClient = new RestClient();

        [Benchmark(Description = "Swashbuckle_PostResponse")]
        public async Task SwashbucklePostResponse()
        {
            for (var i = 0; i < _size; i++)
            {
                await _restClient.PostCustomerAsync("https://localhost:7060/");
            }
        }

        [Benchmark(Description = "NSwag_PostResponse")]
        public async Task NSwagPostResponse()
        {
            for (var i = 0; i < _size; i++)
            {
                await _restClient.PostCustomerAsync("https://localhost:7089/");
            }
        }
        
        [Benchmark(Description = "Swashbuckle_GetResponse")]
        public async Task SwashbuckleGetResponse()
        {
            for (var i = 0; i < _size; i++)
            {
                await _restClient.GetCustomerAsync("https://localhost:7060/");
            }
        }

        [Benchmark(Description = "NSwag_GetResponse")]
        public async Task NSwagGetResponse()
        {
            for (var i = 0; i < _size; i++)
            {
                 _restClient.GetCustomerAsync("https://localhost:7089/");
            }
        }
    }
}