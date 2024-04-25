namespace HttpClientDelegatingHandlersInAspNetCore.Services.Concrete;

using Services.Abstract;

public class TokenGenerator : ITokenGenerator
{
    public string GenerateToken() => Guid.NewGuid().ToString();
}