using System.Security.Claims;
using Duende.IdentityServer.Models;
using IdentityModel;
using IdentityServer;

namespace Tests;

public class CustomsProfileServiceUnitTests
{
    private readonly CustomProfileService _profileService = new();

    [Fact]
    public void WhenClientIdIsNotWeb_ThenIssuedClaimsListIsEmpty()
    {
        var context = new ProfileDataRequestContext
        {
            Client = new Client
            {
                ClientId = "test"
            }
        };

        _profileService.GetProfileDataAsync(context);

        Assert.Empty(context.IssuedClaims);
    }

    [Fact]
    public void WhenClientIdIsWeb_ThenIssuedClaimsListContainsTenantClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Client = new Client
            {
                ClientId = "web"
            }
        };

        _profileService.GetProfileDataAsync(context);

        Assert.Contains(context.IssuedClaims, claim => claim is { Type: "tenant", Value: "main" });
    }

    [Fact]
    public void WhenRequestedClaimTypesListIsEmpty_ThenIssuedClaimsListDoesntContainDiscountClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Client = new Client
            {
                ClientId = "test"
            }
        };

        _profileService.GetProfileDataAsync(context);

        Assert.DoesNotContain(context.IssuedClaims, claim => claim.Type == "payments.discount");
    }

    [Fact]
    public void WhenClientRequestsCustomClaims_ThenIssuedClaimsListContainsRequestedClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Client = new Client
            {
                ClientId = "test"
            },
            RequestedClaimTypes = new [] {"payments.discount"}
        };

        _profileService.GetProfileDataAsync(context);

        Assert.Contains(context.IssuedClaims, claim => claim is { Type: "payments.discount", Value: "20" });
    }

    [Fact]
    public void WhenSubjectIdIs3_ThenIsActiveContextProvidesFalse()
    {
        var claims = new List<Claim> { new(JwtClaimTypes.Subject, "3") };
        var claimsIdentity = new ClaimsIdentity(claims);
        var context = new IsActiveContext(
            new ClaimsPrincipal(claimsIdentity),
            new Client { ClientId = "test" },
            caller: "AuthorizeEndpoint");

        _profileService.IsActiveAsync(context);

        Assert.False(context.IsActive);
    }

    [Fact]
    public void WhenSubjectIdIsNot3_ThenIsActiveContextProvidesTrue()
    {
        var claims = new List<Claim> { new(JwtClaimTypes.Subject, "1") };
        var claimsIdentity = new ClaimsIdentity(claims);
        var context = new IsActiveContext(
            new ClaimsPrincipal(claimsIdentity),
            new Client { ClientId = "test" },
            caller: "AuthorizeEndpoint");

        _profileService.IsActiveAsync(context);

        Assert.True(context.IsActive);
    }
}
