using GrpcVsRest.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;

namespace GrpcVsRest.Benchmarks;

// Starts the same catalog server in this process, on loopback, with the ports the
// server's appsettings.json uses: 5100 for HTTP/1.1 and 5101 for cleartext HTTP/2.
public static class CatalogHost
{
    public const string Http1Address = "http://localhost:5100";
    public const string Http2Address = "http://localhost:5101";

    public static async Task<WebApplication> StartAsync(
        Action<KestrelServerOptions>? extraEndpoints = null, bool logWarnings = false)
    {
        var builder = WebApplication.CreateBuilder();
        // The server's appsettings.json is copied next to this exe; its Kestrel endpoints would bind 5100 a second time.
        builder.Configuration.Sources.Clear();

        builder.Logging.ClearProviders();
        if (logWarnings)
        {
            builder.Logging.AddConsole().SetMinimumLevel(LogLevel.Warning);
        }

        builder.WebHost.ConfigureKestrel(kestrel =>
        {
            kestrel.ListenLocalhost(5100, listen => listen.Protocols = HttpProtocols.Http1);
            kestrel.ListenLocalhost(5101, listen => listen.Protocols = HttpProtocols.Http2);
            extraEndpoints?.Invoke(kestrel);
        });

        builder.Services.AddCatalog();

        var app = builder.Build();
        app.UseCatalog();
        await app.StartAsync();

        return app;
    }
}
