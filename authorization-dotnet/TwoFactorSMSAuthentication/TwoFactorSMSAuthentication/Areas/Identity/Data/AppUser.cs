using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwoFactorSMSAuthentication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName="nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
}

