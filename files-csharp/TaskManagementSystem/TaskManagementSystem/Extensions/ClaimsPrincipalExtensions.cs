using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static RequestUser GetUser(this ClaimsPrincipal user)
    {
        return new RequestUser
        {
            UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
            Role = user.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
            UserName = user.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty
        };
    }
}

public class RequestUser
{
    public string UserName { get; set;}
    public string UserId { get; set;}
    public string Role { get; set; }
}
