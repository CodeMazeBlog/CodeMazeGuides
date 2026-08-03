namespace BridgePattern.Solution.Discounts;

public class NoDiscount : IDiscount
{
    public decimal GetDiscount(decimal price) => 0;
}