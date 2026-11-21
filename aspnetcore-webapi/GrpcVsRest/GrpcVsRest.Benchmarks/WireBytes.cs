using System.Net.Http.Json;
using GrpcVsRest.Server;

namespace GrpcVsRest.Benchmarks;

// Measures bytes on the wire per call, after a warm-up, over reused connections,
// and counts the connections each client opens for 100 concurrent calls.
public static class WireBytes
{
    private const int Calls = 100;

    public static async Task PrintAsync()
    {
        await using var app = await CatalogHost.StartAsync();

        var counters = new Dictionary<string, ByteCounter>();
        using var clients = new CatalogClients(name => counters[name] = new ByteCounter());

        await PrintPerCallAsync("One product (GetProduct), average per call", SingleProductCalls(clients), counters);
        await PrintPerCallAsync("100 products (ListProducts), average per call", ProductListCalls(clients), counters);

        // Fresh clients, so every connection they open is counted.
        var parallelCounters = new Dictionary<string, ByteCounter>();
        using var parallelClients = new CatalogClients(name => parallelCounters[name] = new ByteCounter());

        Console.WriteLine();
        Console.WriteLine("100 concurrent GetProduct calls on fresh clients, connections opened:");
        foreach (var (name, call) in SingleProductCalls(parallelClients))
        {
            await Task.WhenAll(Enumerable.Range(0, Calls).Select(_ => call()));
            Console.WriteLine($"  {name,-28}{parallelCounters[name].Connections,4}");
        }
    }

    private static Dictionary<string, Func<Task>> SingleProductCalls(CatalogClients clients) => new()
    {
        ["REST, HTTP/1.1"] = () => clients.RestHttp1.GetFromJsonAsync<ProductDto>("/api/products/42"),
        ["REST, HTTP/1.1, gzip"] = () => clients.RestHttp1Gzip.GetFromJsonAsync<ProductDto>("/api/products/42"),
        ["REST, HTTP/2"] = () => clients.RestHttp2.GetFromJsonAsync<ProductDto>("/api/products/42"),
        ["Transcoded JSON, HTTP/1.1"] = () => clients.Transcoded.GetFromJsonAsync<ProductDto>("/v1/products/42"),
        ["gRPC, HTTP/2"] = async () => await clients.Grpc.GetProductAsync(new GetProductRequest { Id = 42 }),
        ["gRPC-Web, HTTP/1.1"] = async () => await clients.GrpcWeb.GetProductAsync(new GetProductRequest { Id = 42 })
    };

    private static Dictionary<string, Func<Task>> ProductListCalls(CatalogClients clients) => new()
    {
        ["REST, HTTP/1.1"] = () => clients.RestHttp1.GetFromJsonAsync<List<ProductDto>>("/api/products"),
        ["REST, HTTP/1.1, gzip"] = () => clients.RestHttp1Gzip.GetFromJsonAsync<List<ProductDto>>("/api/products"),
        ["REST, HTTP/2"] = () => clients.RestHttp2.GetFromJsonAsync<List<ProductDto>>("/api/products"),
        ["Transcoded JSON, HTTP/1.1"] = () => clients.Transcoded.GetFromJsonAsync<TranscodedList>("/v1/products"),
        ["gRPC, HTTP/2"] = async () => await clients.Grpc.ListProductsAsync(new ListProductsRequest()),
        ["gRPC-Web, HTTP/1.1"] = async () => await clients.GrpcWeb.ListProductsAsync(new ListProductsRequest())
    };

    private static async Task PrintPerCallAsync(string title, Dictionary<string, Func<Task>> calls,
        Dictionary<string, ByteCounter> counters)
    {
        Console.WriteLine();
        Console.WriteLine($"{title}:");
        Console.WriteLine($"  {"Client",-28}{"Sent",8}{"Received",10}{"Total",8}");

        foreach (var (name, call) in calls)
        {
            for (var i = 0; i < 10; i++)
            {
                await call();
            }

            counters[name].Reset();

            for (var i = 0; i < Calls; i++)
            {
                await call();
            }

            var sent = counters[name].Sent / Calls;
            var received = counters[name].Received / Calls;
            Console.WriteLine($"  {name,-28}{sent,8:N0}{received,10:N0}{sent + received,8:N0}");
        }
    }
}

public record TranscodedList(List<ProductDto> Products);
