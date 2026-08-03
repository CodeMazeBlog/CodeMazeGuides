using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AccessTokenFromHttpContext.Controllers;
[ApiController]
[Route("[controller]")]
public class AccessTokenController : ControllerBase
{
    [HttpGet]
    public async Task<string> GetAccessToken()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        return accessToken!;
    }

    [HttpGet]
    public string GetAccessTokenViaHeaders()
    {
        var authorizationHeader = HttpContext.Request.Headers["access_token"];

        string accessToken = string.Empty;

        if (authorizationHeader.ToString().StartsWith("Bearer")) 
        { 
            accessToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim(); 
        }

        return accessToken!;
    }
}
