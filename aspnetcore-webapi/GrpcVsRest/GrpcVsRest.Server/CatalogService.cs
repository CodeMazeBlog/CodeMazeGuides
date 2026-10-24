using Grpc.Core;

namespace GrpcVsRest.Server;

public class CatalogService(ProductStore store) : Catalog.CatalogBase
{
    public override Task<Product> GetProduct(GetProductRequest request, ServerCallContext context)
    {
        var product = store.Find(request.Id)
            ?? throw new RpcException(new Status(StatusCode.NotFound, $"Product {request.Id} not found"));

        return Task.FromResult(ToMessage(product));
    }

    public override Task<ProductList> ListProducts(ListProductsRequest request, ServerCallContext context)
    {
        var list = new ProductList();
        list.Products.AddRange(store.All.Select(ToMessage));

        return Task.FromResult(list);
    }

    public override async Task WatchStock(WatchStockRequest request,
        IServerStreamWriter<StockUpdate> responseStream, ServerCallContext context)
    {
        var product = store.Find(request.Id)
            ?? throw new RpcException(new Status(StatusCode.NotFound, $"Product {request.Id} not found"));

        for (var i = 0; i < request.Updates; i++)
        {
            await responseStream.WriteAsync(new StockUpdate { Id = product.Id, Stock = product.Stock - i });
            await Task.Delay(100, context.CancellationToken);
        }
    }

    private static Product ToMessage(ProductDto product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Category = product.Category,
        Price = product.Price,
        Stock = product.Stock
    };
}
