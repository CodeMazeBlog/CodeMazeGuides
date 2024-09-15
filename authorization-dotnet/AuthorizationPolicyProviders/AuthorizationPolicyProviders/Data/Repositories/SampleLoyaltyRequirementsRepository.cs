using AuthorizationPolicyProviders.Authorization;
using AuthorizationPolicyProviders.Models;

namespace AuthorizationPolicyProviders.Data.Repositories;

public class SampleLoyaltyRequirementsRepository : ILoyaltyRequirementsRepository
{
    public Task<LoyaltyRequirements?> GetByActionNameAsync(string policyIdentifier) =>
        Task.FromResult<LoyaltyRequirements?>(policyIdentifier switch
        {
            AuthorizationConstants.PriorityCheckIn => new() { BaselineMembershipTier = MembershipTier.Silver, MinimumLoyaltyPoints = 100 },
            _ => null
        });
}
