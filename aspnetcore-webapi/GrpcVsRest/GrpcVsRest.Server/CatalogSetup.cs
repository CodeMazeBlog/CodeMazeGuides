namespace GrpcVsRest.Server;

public static class CatalogSetup
{
    public static IServiceCollection AddCatalog(this IServiceCollection services)
    {
        services.AddSingleton<ProductStore>();
        services.AddGrpc().AddJsonTranscoding();
        services.AddResponseCompression();

        return services;
    }

    public static WebApplication UseCatalog(this WebApplication app)
    {
        app.UseResponseCompression();
        app.UseGrpcWeb();

        app.MapGet("/api/products/{id:int}", (int id, ProductStore store) =>
            store.Find(id) is { } product ? Results.Ok(product) : Results.NotFound());

        app.MapGet("/api/products", (ProductStore store) => store.All);

        app.MapGrpcService<CatalogService>().EnableGrpcWeb();

        return app;
    }
}
