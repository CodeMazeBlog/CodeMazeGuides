using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.Models;
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
            Application = new Client
            {
                ClientId = "test"
            }
        };

        _profileService.GetProfileDataAsync(context, CancellationToken.None);

        Assert.Empty(context.IssuedClaims);
    }

    [Fact]
    public void WhenClientIdIsWeb_ThenIssuedClaimsListContainsTenantClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Application = new Client
            {
                ClientId = "web"
            }
        };

        _profileService.GetProfileDataAsync(context, CancellationToken.None);

        Assert.Contains(context.IssuedClaims, claim => claim is { Type: "tenant", Value: "main" });
    }

    [Fact]
    public void WhenRequestedClaimTypesListIsEmpty_ThenIssuedClaimsListDoesntContainDiscountClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Application = new Client
            {
                ClientId = "test"
            }
        };

        _profileService.GetProfileDataAsync(context, CancellationToken.None);

        Assert.DoesNotContain(context.IssuedClaims, claim => claim.Type == "payments.discount");
    }

    [Fact]
    public void WhenClientRequestsCustomClaims_ThenIssuedClaimsListContainsRequestedClaim()
    {
        var context = new ProfileDataRequestContext
        {
            Application = new Client
            {
                ClientId = "test"
            },
            RequestedClaimTypes = new [] {"payments.discount"}
        };

        _profileService.GetProfileDataAsync(context, CancellationToken.None);

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

        _profileService.IsActiveAsync(context, CancellationToken.None);

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

        _profileService.IsActiveAsync(context, CancellationToken.None);

        Assert.True(context.IsActive);
    }

    [Fact]
    public void WhenApiResourceIsConfigured_ThenItDeclaresRoleAsAUserClaim()
    {
        var paymentsApi = Config.ApiResources.Single(resource => resource.Name == "paymentsapi");

        Assert.Contains(JwtClaimTypes.Role, paymentsApi.UserClaims);
    }
}
