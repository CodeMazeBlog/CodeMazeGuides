namespace RateLimitingDotNET8;

public class RateLimiterOptions
{
    public int QueueLimit { get; set; } = default!;
}

public class FixedOptions : RateLimiterOptions
{
    public const string Fixed = "FixedOptions";
    public int PermitLimit { get; set; } = default!;
    public double Window { get; set; } = default!;
}

public class SlidingWindowOptions : RateLimiterOptions
{
    public const string Sliding = "SlidingWindowOptions";

    public int PermitLimit { get; set; } = default!;
    public double Window { get; set; } = default!;
    public int SegmentsPerWindow { get; set; } = default!;
}

public class TokenBucketOptions : RateLimiterOptions
{
    public const string Token = "TokenBucketOptions";

    public int TokenLimit { get; set; } = default!;
    public int TokensPerPeriod { get; set; } = default!;
    public double ReplenishmentPeriod { get; set; } = default!;
    public bool AutoReplenishment { get; set; } = default!;
}

public class ConcurrencyOptions : RateLimiterOptions
{
    public const string Concurrency = "ConcurrencyOptions";

    public int PermitLimit { get; set; } = default!;
}

public class AuthorizedOptions : FixedOptions
{
    public const string Authorized = "AuthorizedOptions";
}

public class UnauthorizedOptions : FixedOptions
{
    public const string Unauthorized = "UnauthorizedOptions";
}

public class ChainedFirstOptions : FixedOptions
{
    public const string ChainedFirst = "ChainedFirstOptions"; 
}

public class ChainedSecondOptions : FixedOptions
{
    public const string ChainedSecond = "ChainedSecondOptions";
} 