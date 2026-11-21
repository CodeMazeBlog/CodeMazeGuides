using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using GrpcVsRest.Server;
using Microsoft.AspNetCore.Builder;

namespace GrpcVsRest.Benchmarks;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class CallBenchmarks
{
    private WebApplication _app = null!;
    private CatalogClients _clients = null!;

    [GlobalSetup]
    public async Task Setup()
    {
        _app = await CatalogHost.StartAsync();
        _clients = new CatalogClients();
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        _clients.Dispose();
        await _app.DisposeAsync();
    }

    // One product
    [Benchmark(Baseline = true), BenchmarkCategory("1 product")]
    public Task<ProductDto?> RestHttp1() => _clients.RestHttp1.GetFromJsonAsync<ProductDto>("/api/products/42");

    [Benchmark, BenchmarkCategory("1 product")]
    public Task<ProductDto?> RestHttp2() => _clients.RestHttp2.GetFromJsonAsync<ProductDto>("/api/products/42");

    [Benchmark, BenchmarkCategory("1 product")]
    public Task<ProductDto?> TranscodedJson() => _clients.Transcoded.GetFromJsonAsync<ProductDto>("/v1/products/42");

    [Benchmark, BenchmarkCategory("1 product")]
    public async Task<Product> Grpc() => await _clients.Grpc.GetProductAsync(new GetProductRequest { Id = 42 });

    [Benchmark, BenchmarkCategory("1 product")]
    public async Task<Product> GrpcWeb() => await _clients.GrpcWeb.GetProductAsync(new GetProductRequest { Id = 42 });

    // 100 products
    [Benchmark(Baseline = true), BenchmarkCategory("100 products")]
    public Task<List<ProductDto>?> ListRestHttp1() =>
        _clients.RestHttp1.GetFromJsonAsync<List<ProductDto>>("/api/products");

    [Benchmark, BenchmarkCategory("100 products")]
    public Task<List<ProductDto>?> ListRestHttp1Gzip() =>
        _clients.RestHttp1Gzip.GetFromJsonAsync<List<ProductDto>>("/api/products");

    [Benchmark, BenchmarkCategory("100 products")]
    public Task<List<ProductDto>?> ListRestHttp2() =>
        _clients.RestHttp2.GetFromJsonAsync<List<ProductDto>>("/api/products");

    [Benchmark, BenchmarkCategory("100 products")]
    public Task<TranscodedList?> ListTranscodedJson() =>
        _clients.Transcoded.GetFromJsonAsync<TranscodedList>("/v1/products");

    [Benchmark, BenchmarkCategory("100 products")]
    public async Task<ProductList> ListGrpc() => await _clients.Grpc.ListProductsAsync(new ListProductsRequest());

    [Benchmark, BenchmarkCategory("100 products")]
    public async Task<ProductList> ListGrpcWeb() => await _clients.GrpcWeb.ListProductsAsync(new ListProductsRequest());

    // 100 concurrent calls for one product each
    [Benchmark(Baseline = true), BenchmarkCategory("100 parallel calls")]
    public Task ParallelRestHttp1() => Parallel100(() => RestHttp1());

    [Benchmark, BenchmarkCategory("100 parallel calls")]
    public Task ParallelRestHttp2() => Parallel100(() => RestHttp2());

    [Benchmark, BenchmarkCategory("100 parallel calls")]
    public Task ParallelTranscodedJson() => Parallel100(() => TranscodedJson());

    [Benchmark, BenchmarkCategory("100 parallel calls")]
    public Task ParallelGrpc() => Parallel100(() => Grpc());

    [Benchmark, BenchmarkCategory("100 parallel calls")]
    public Task ParallelGrpcWeb() => Parallel100(() => GrpcWeb());

    private static Task Parallel100(Func<Task> call) =>
        Task.WhenAll(Enumerable.Range(0, 100).Select(_ => call()));
}
