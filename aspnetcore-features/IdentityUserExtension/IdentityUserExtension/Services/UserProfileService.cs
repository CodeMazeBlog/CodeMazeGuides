using System.Security.Claims;
using IdentityUserExtension.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityUserExtension.Services;

public class UserProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RecordSignIn(ClaimsPrincipal principal)
    {
        var user = await _userManager.GetUserAsync(principal);
        if (user is null)
        {
            return IdentityResult.Failed();
        }

        user.LastLoginDateTime = DateTime.UtcNow;

        return await _userManager.UpdateAsync(user);
    }
}
