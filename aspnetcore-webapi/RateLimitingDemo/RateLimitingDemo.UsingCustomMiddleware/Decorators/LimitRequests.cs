namespace RateLimitingDemo.UsingCustomMiddleware.Decorators;

[AttributeUsage(AttributeTargets.Method)]
public class LimitRequests : Attribute
{
    public int TimeWindow { get; set; }
    public int MaxRequests { get; set; }
}

