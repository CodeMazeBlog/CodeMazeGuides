namespace DotNetURLShortener.Contracts;

public interface IUrlShortenerService
{
    public string GetShortCode(string longUrl);
    public string? GetLongUrl(string shortCode);
}