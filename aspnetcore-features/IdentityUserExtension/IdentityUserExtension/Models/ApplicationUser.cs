using Microsoft.AspNetCore.Identity;

namespace IdentityUserExtension.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string DisplayName { get; set; }
    public DateTime LastLoginDateTime { get; set; }
    public List<Post> Posts { get; set; }
}