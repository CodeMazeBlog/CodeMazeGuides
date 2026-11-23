namespace RequiredPropertiesInCSharp;

public record Product
{
    public required string Sku { get; init; }
}
