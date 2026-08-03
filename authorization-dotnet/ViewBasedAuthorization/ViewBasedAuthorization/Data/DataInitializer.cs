using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ViewBasedAuthorization.Data;

public static class DataInitializer
{
    public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        SeedRoles(roleManager, ["User", "Editor", "Admin"]);
        SeedUsers(userManager);
    }

    private static void SeedRoles(RoleManager<IdentityRole> roleManager, List<string> roleNames)
    {
        foreach (var roleName in roleNames)
        {
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }

    private static void SeedUsers(UserManager<IdentityUser> userManager)
    {
        SeedUser(userManager,
            "admin@docmanager.com",
            "Admin123!",
            "Admin",
            new Claim("Permission", "CanEdit"));

        SeedUser(userManager,
            "editor@docmanager.com",
            "Editor123!",
            "Editor",
            new Claim("Permission", "CanEdit"));

        SeedUser(userManager, "user@docmanager.com", "User123!", "User");
    }

    private static void SeedUser(UserManager<IdentityUser> userManager, string email, string password,
        string roleName, params Claim[] claims)
    {
        var user = userManager.FindByEmailAsync(email).Result;

        if (user is null)
        {
            user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
            userManager.CreateAsync(user, password);
        }

        if (!userManager.IsInRoleAsync(user, roleName).Result)
        {
            userManager.AddToRoleAsync(user, roleName);
        }

        foreach (var claim in claims)
        {
            if (!userManager.GetClaimsAsync(user)
                .Result
                .Any(c => c.Type == claim.Type && c.Value == claim.Value))
            {
                userManager.AddClaimAsync(user, claim);
            }
        }
    }
}
