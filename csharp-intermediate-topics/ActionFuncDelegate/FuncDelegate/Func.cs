var processor = new ShippingProcessor();

Func<decimal, decimal> standardCostCalculator = total => total * 0.02m;

Func<decimal, decimal> expressCostCalculator = total => total * 0.05m;

    decimal distance = 10; // in kilometers
    decimal weight = 100; // in kilograms
    // Process shipping with standard cost calculation
    processor.ProcessShipping(weight, distance, standardCostCalculator);
    // Process shipping with express cost calculation
    processor.ProcessShipping(weight, distance, expressCostCalculator);
public class ShippingProcessor
{
    public void ProcessShipping(decimal weight, decimal distance, Func<decimal, decimal> calculateCost)
    {
        decimal totalCost = calculateCost(weight * distance);
        Console.WriteLine($"Shipping Cost: {totalCost:C}");
    }
}
