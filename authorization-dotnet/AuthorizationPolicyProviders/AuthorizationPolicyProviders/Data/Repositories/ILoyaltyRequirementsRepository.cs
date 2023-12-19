using AuthorizationPolicyProviders.Models;

namespace AuthorizationPolicyProviders.Data.Repositories;

public interface ILoyaltyRequirementsRepository
{
    public Task<LoyaltyRequirements?> GetByActionNameAsync(string policyIdentifier);
}
