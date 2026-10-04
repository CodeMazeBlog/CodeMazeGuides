using System.ComponentModel.DataAnnotations;
using Banking.Services;

namespace Banking.Api;

public sealed record WithdrawRequest([property: Range(typeof(decimal), "1", "1000")] decimal Amount);

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        var accounts = app.MapGroup("/api/accounts");

        accounts.MapGet("/{accountId:int}", async (
            int accountId,
            IAccountService service,
            CancellationToken cancellationToken) =>
        {
            var result = await service.GetByIdAsync(accountId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });

        accounts.MapPost("/{accountId:int}/withdrawals", async (
            int accountId,
            WithdrawRequest request,
            IAccountService service,
            CancellationToken cancellationToken) =>
        {
            var result = await service.WithdrawAsync(accountId, request.Amount, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
    }
}
