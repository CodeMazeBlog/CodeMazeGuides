namespace RateLimitingDotNET8;

public static class Policies
{
    public const string Fixed = "fixed";
    public const string Sliding = "sliding";
    public const string Token = "token";
    public const string Concurrency = "concurrency";
    public const string Authorization = "authorization";
    public const string Chained = "chained";
}
