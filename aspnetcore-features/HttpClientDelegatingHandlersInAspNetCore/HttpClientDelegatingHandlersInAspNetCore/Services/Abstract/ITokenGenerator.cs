namespace HttpClientDelegatingHandlersInAspNetCore.Services.Abstract;

public interface ITokenGenerator
{
    Task<string> GenerateTokenAsync();
}