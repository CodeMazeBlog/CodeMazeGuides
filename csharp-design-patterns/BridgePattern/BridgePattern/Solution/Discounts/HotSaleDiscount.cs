namespace BridgePattern.Solution.Discounts;

public class HotSaleDiscount : IDiscount
{
    public decimal GetDiscount(decimal price) => price > 50 ? 20 : 0;    
}