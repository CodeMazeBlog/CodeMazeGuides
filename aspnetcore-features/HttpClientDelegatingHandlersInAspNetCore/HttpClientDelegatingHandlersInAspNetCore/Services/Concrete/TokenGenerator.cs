namespace HttpClientDelegatingHandlersInAspNetCore.Services.Concrete;

using Services.Abstract;

public class TokenGenerator : ITokenGenerator
{
    public Task<string> GenerateTokenAsync() => Task.FromResult(Guid.NewGuid().ToString());
}