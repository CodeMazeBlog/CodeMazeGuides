using System.ComponentModel.DataAnnotations;

namespace AuthorizationPolicyProviders.HttpModels;

public class SignInRequest
{
    [Required]
    public int LoyaltyPoints { get; set; } = 0;
    
    public string MembershipTier { get; set; } = string.Empty;
}
