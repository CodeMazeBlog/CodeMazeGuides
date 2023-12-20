using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Security.Claims;

namespace IdentityServer;

internal sealed class CustomProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        if (context.RequestedClaimTypes.Any())
        {
            context.AddRequestedClaims(new[] { new Claim("payments.discount", "20") });
        }

        if (context.Client.ClientId == "web")
        {
            context.IssuedClaims.Add(new Claim("tenant", "main"));
        }

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
