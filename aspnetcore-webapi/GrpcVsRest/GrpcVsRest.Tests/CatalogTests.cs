using System.Net;
using System.Net.Http.Json;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcVsRest.Server;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GrpcVsRest.Tests;

public class CatalogTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly CancellationToken _cancellationToken = TestContext.Current.CancellationToken;

    [Fact]
    public async Task GivenSameId_WhenCalledThreeWays_ThenAllReturnTheSameProduct()
    {
        var http = factory.CreateClient();
        var rest = await http.GetFromJsonAsync<ProductDto>("/api/products/7", _cancellationToken);
        var transcoded = await http.GetFromJsonAsync<ProductDto>("/v1/products/7", _cancellationToken);

        using var channel = GrpcChannel.ForAddress(factory.Server.BaseAddress,
            new GrpcChannelOptions { HttpHandler = factory.Server.CreateHandler() });
        var grpc = await new Catalog.CatalogClient(channel)
            .GetProductAsync(new GetProductRequest { Id = 7 }, cancellationToken: _cancellationToken);

        Assert.NotNull(rest);
        Assert.Equal(rest, transcoded);
        Assert.Equal(rest, new ProductDto(grpc.Id, grpc.Name, grpc.Category, grpc.Price, grpc.Stock));
    }

    [Fact]
    public async Task GivenUnknownId_WhenCalled_ThenRestReturns404AndGrpcReturnsNotFound()
    {
        var http = factory.CreateClient();
        var rest = await http.GetAsync("/api/products/999", _cancellationToken);
        var transcoded = await http.GetAsync("/v1/products/999", _cancellationToken);

        using var channel = GrpcChannel.ForAddress(factory.Server.BaseAddress,
            new GrpcChannelOptions { HttpHandler = factory.Server.CreateHandler() });
        var grpc = await Assert.ThrowsAsync<RpcException>(() => new Catalog.CatalogClient(channel)
            .GetProductAsync(new GetProductRequest { Id = 999 }, cancellationToken: _cancellationToken)
            .ResponseAsync);

        Assert.Equal(HttpStatusCode.NotFound, rest.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, transcoded.StatusCode);
        Assert.Equal(StatusCode.NotFound, grpc.StatusCode);
    }
}
