using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Api;

public sealed record OrderRequest([property: Range(1, 20)] int Quantity);

public static class PizzaEndpoints
{
    public static void MapPizzaEndpoints(this IEndpointRouteBuilder app)
    {
        var pizzas = app.MapGroup("/api/pizzas");

        pizzas.MapGet("/{name}", (string name) =>
        {
            var result = Kitchen.Check(name);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });

        pizzas.MapPost("/{name}/orders", (string name, OrderRequest request) =>
        {
            var result = Kitchen.Order(name, request.Quantity);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
    }
}
