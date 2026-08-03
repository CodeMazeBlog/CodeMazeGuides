using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Security.Claims;
using Duende.IdentityServer.Extensions;

namespace IdentityServer;

public sealed class CustomProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        if (context.Client.ClientId == "web")
        {
            context.IssuedClaims.Add(new Claim("tenant", "main"));
        }

        if (context.RequestedClaimTypes.Any())
        {
            context.AddRequestedClaims(new[] { new Claim("payments.discount", "20") });
        }

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        if (context.Subject.GetSubjectId() == "3")
        {
            context.IsActive = false;
        }

        return Task.CompletedTask;
    }
}
