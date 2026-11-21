using System.Net;
using System.Net.Sockets;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcVsRest.Server;

namespace GrpcVsRest.Benchmarks;

// One reused client per way of calling the catalog.
// Pass a ByteCounter to count every byte each client writes to and reads from its sockets.
public sealed class CatalogClients : IDisposable
{
    public CatalogClients(Func<string, ByteCounter?>? counterFor = null)
    {
        counterFor ??= _ => null;

        RestHttp1 = new HttpClient(Handler(counterFor("REST, HTTP/1.1")))
        {
            BaseAddress = new Uri(CatalogHost.Http1Address)
        };

        RestHttp1Gzip = new HttpClient(Handler(counterFor("REST, HTTP/1.1, gzip"), DecompressionMethods.GZip))
        {
            BaseAddress = new Uri(CatalogHost.Http1Address)
        };

        RestHttp2 = new HttpClient(Handler(counterFor("REST, HTTP/2")))
        {
            BaseAddress = new Uri(CatalogHost.Http2Address),
            DefaultRequestVersion = HttpVersion.Version20,
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
        };

        Transcoded = new HttpClient(Handler(counterFor("Transcoded JSON, HTTP/1.1")))
        {
            BaseAddress = new Uri(CatalogHost.Http1Address)
        };

        _grpcChannel = GrpcChannel.ForAddress(CatalogHost.Http2Address,
            new GrpcChannelOptions { HttpHandler = Handler(counterFor("gRPC, HTTP/2")) });
        Grpc = new Catalog.CatalogClient(_grpcChannel);

        _grpcWebChannel = GrpcChannel.ForAddress(CatalogHost.Http1Address,
            new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, Handler(counterFor("gRPC-Web, HTTP/1.1"))),
                HttpVersion = HttpVersion.Version11
            });
        GrpcWeb = new Catalog.CatalogClient(_grpcWebChannel);
    }

    public HttpClient RestHttp1 { get; }
    public HttpClient RestHttp1Gzip { get; }
    public HttpClient RestHttp2 { get; }
    public HttpClient Transcoded { get; }
    public Catalog.CatalogClient Grpc { get; }
    public Catalog.CatalogClient GrpcWeb { get; }

    private readonly GrpcChannel _grpcChannel;
    private readonly GrpcChannel _grpcWebChannel;

    public void Dispose()
    {
        RestHttp1.Dispose();
        RestHttp1Gzip.Dispose();
        RestHttp2.Dispose();
        Transcoded.Dispose();
        _grpcChannel.Dispose();
        _grpcWebChannel.Dispose();
    }

    private static SocketsHttpHandler Handler(ByteCounter? counter,
        DecompressionMethods decompression = DecompressionMethods.None)
    {
        // EnableMultipleHttp2Connections matches what GrpcChannel sets on the handler it creates itself.
        var handler = new SocketsHttpHandler
        {
            AutomaticDecompression = decompression,
            EnableMultipleHttp2Connections = true
        };

        if (counter is not null)
        {
            handler.ConnectCallback = async (context, cancellationToken) =>
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp) { NoDelay = true };
                await socket.ConnectAsync(context.DnsEndPoint, cancellationToken);
                counter.AddConnection();

                return new CountingStream(new NetworkStream(socket, ownsSocket: true), counter);
            };
        }

        return handler;
    }
}
