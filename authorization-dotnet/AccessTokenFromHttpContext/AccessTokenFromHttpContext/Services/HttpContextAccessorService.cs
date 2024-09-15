using Microsoft.AspNetCore.Authentication;

namespace AccessTokenFromHttpContext.Services;

public class HttpContextAccessorService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextAccessorService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> GetAccessToken()
    {
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

        return accessToken;
    }
}
