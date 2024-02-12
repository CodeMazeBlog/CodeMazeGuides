namespace RateLimitingDotNET8;

public class MyRateLimiterOptions
{
    public int PermitLimit { get; set; } = default!;

    public double Window { get; set; } = default!;

    public int QueueLimit { get; set; } = default!;
}

public class TokenBucketOptions : MyRateLimiterOptions
{
    public int TokenLimit { get; set; } = default!;
    public int TokensPerPeriod { get; set; } = default!;
    public double ReplenishmentPeriod { get; set; } = default!;
    public bool AutoReplenishment { get; set; } = default!;
}

public class SlidingOptions : MyRateLimiterOptions
{
    public int SegmentsPerWindow { get; set; } = default!;
}