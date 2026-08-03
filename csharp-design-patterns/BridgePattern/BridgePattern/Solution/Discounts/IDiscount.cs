namespace BridgePattern.Solution.Discounts;

public interface IDiscount
{
    decimal GetDiscount(decimal price);
}