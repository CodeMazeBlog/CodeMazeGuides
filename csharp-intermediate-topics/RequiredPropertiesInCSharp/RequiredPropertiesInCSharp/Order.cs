using System.Diagnostics.CodeAnalysis;

namespace RequiredPropertiesInCSharp;

public class Order
{
    public required string Customer { get; set; }
    public required int Quantity { get; set; }

    [SetsRequiredMembers]
    public Order()
    {
    }
}
