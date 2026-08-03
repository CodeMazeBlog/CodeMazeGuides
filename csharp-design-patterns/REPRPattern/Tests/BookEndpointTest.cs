using FastEndpoints;
using REPRPattern;

namespace Tests;

public class BookEndpointTest
{
    [Fact]
    public async Task WhenBookEndpointIsAccessed_ThenReturnsExpectedResult()
    {
        var endpoint = Factory.Create<BookEndpoint>();
        var request = new BookEndpointRequest("Why You Act The Way You Do", "Tim Lahaye");

        await endpoint.HandleAsync(request, default);
        var response = endpoint.Response;

        Assert.NotNull(response);
        Assert.Equal("Why You Act The Way You Do was written by Tim Lahaye", response.Description);
    }
}