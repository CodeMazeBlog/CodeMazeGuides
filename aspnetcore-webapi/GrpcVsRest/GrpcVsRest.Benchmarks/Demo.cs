using System.Net;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcVsRest.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GrpcVsRest.Benchmarks;

// Calls the same product every way the server offers it and prints what comes back.
public static class Demo
{
    public static async Task RunAsync()
    {
        // Port 5102 allows HTTP/1.1 and HTTP/2 without TLS, only to show what Kestrel does with it.
        await using var app = await CatalogHost.StartAsync(
            kestrel => kestrel.ListenLocalhost(5102, listen => listen.Protocols = HttpProtocols.Http1AndHttp2),
            logWarnings: true);

        using var rest = new HttpClient { BaseAddress = new Uri("http://localhost:5100") };
        Console.WriteLine("REST:       " + await rest.GetStringAsync("/api/products/7"));
        Console.WriteLine("Transcoded: " + await rest.GetStringAsync("/v1/products/7"));

        using var channel = GrpcChannel.ForAddress("http://localhost:5101");
        var catalog = new Catalog.CatalogClient(channel);
        var product = await catalog.GetProductAsync(new GetProductRequest { Id = 7 },
            deadline: DateTime.UtcNow.AddSeconds(5));
        Console.WriteLine("gRPC:       " + product);

        using var webChannel = GrpcChannel.ForAddress("http://localhost:5100", new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()),
            HttpVersion = HttpVersion.Version11
        });
        var webCatalog = new Catalog.CatalogClient(webChannel);
        Console.WriteLine("gRPC-Web:   " + await webCatalog.GetProductAsync(new GetProductRequest { Id = 7 }));

        Console.WriteLine();
        Console.WriteLine("Server streaming over gRPC:");
        using (var call = catalog.WatchStock(new WatchStockRequest { Id = 7, Updates = 3 }))
        {
            await foreach (var update in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"  {DateTime.Now:HH:mm:ss.fff} {update}");
            }
        }

        Console.WriteLine("Server streaming over gRPC-Web (HTTP/1.1):");
        using (var call = webCatalog.WatchStock(new WatchStockRequest { Id = 7, Updates = 3 }))
        {
            await foreach (var update in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"  {DateTime.Now:HH:mm:ss.fff} {update}");
            }
        }

        Console.WriteLine("Server streaming through transcoding (raw body):");
        Console.Write(await rest.GetStringAsync("/v1/products/7/stock?updates=3"));

        Console.WriteLine();
        Console.WriteLine("Not found, three ways:");
        var restMissing = await rest.GetAsync("/api/products/999");
        Console.WriteLine($"  REST:       {(int)restMissing.StatusCode} {restMissing.StatusCode}");
        var transcodedMissing = await rest.GetAsync("/v1/products/999");
        Console.WriteLine($"  Transcoded: {(int)transcodedMissing.StatusCode} {transcodedMissing.StatusCode} " +
            await transcodedMissing.Content.ReadAsStringAsync());
        try
        {
            await catalog.GetProductAsync(new GetProductRequest { Id = 999 });
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"  gRPC:       {ex.StatusCode} \"{ex.Status.Detail}\"");
        }

        Console.WriteLine();
        Console.WriteLine("Cleartext HTTP/2 probes:");
        await ProbeAsync("HttpClient defaults -> HTTP/2-only endpoint",
            new HttpClient(), "http://localhost:5101");
        await ProbeAsync("Version 2.0, RequestVersionOrLower -> HTTP/2-only endpoint",
            new HttpClient { DefaultRequestVersion = HttpVersion.Version20 }, "http://localhost:5101");
        await ProbeAsync("Version 2.0, RequestVersionExact -> HTTP/2-only endpoint",
            new HttpClient
            {
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
            }, "http://localhost:5101");
        await ProbeAsync("Version 2.0, RequestVersionExact -> HTTP/1.1 and HTTP/2 endpoint",
            new HttpClient
            {
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
            }, "http://localhost:5102");

        await GrpcProbeAsync("gRPC client -> HTTP/1.1-only endpoint", "http://localhost:5100");
        await GrpcProbeAsync("gRPC client -> HTTP/1.1 and HTTP/2 endpoint", "http://localhost:5102");
        await GrpcProbeAsync("gRPC client -> HTTP/2-only endpoint", "http://localhost:5101");
    }

    private static async Task ProbeAsync(string name, HttpClient client, string address)
    {
        using (client)
        {
            try
            {
                using var response = await client.GetAsync($"{address}/api/products/7");
                Console.WriteLine($"  {name}: {(int)response.StatusCode}, HTTP/{response.Version}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"  {name}: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }

    private static async Task GrpcProbeAsync(string name, string address)
    {
        using var channel = GrpcChannel.ForAddress(address);
        try
        {
            var product = await new Catalog.CatalogClient(channel)
                .GetProductAsync(new GetProductRequest { Id = 7 }, deadline: DateTime.UtcNow.AddSeconds(5));
            Console.WriteLine($"  {name}: OK, {product.Name}");
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"  {name}: {ex.StatusCode}, {ex.Status.DebugException?.Message}");
        }
    }
}
