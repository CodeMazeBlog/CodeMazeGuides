using Funcs;

class Program
{

    static void Main()
    {
        ShippingProcessor processor = new ShippingProcessor();

        Func<decimal, decimal> standardCostCalculator = (total) =>
        {
            return total * 0.02m; // Assuming a flat rate of 2% of total cost
        };

        Func<decimal, decimal> expressCostCalculator = (total) =>
        {
            return total * 0.05m; // Assuming a flat rate of 5% of total cost
        };


        decimal distance = 10; // in kilometers
        decimal weight = 100; // in kilograms

        // Process shipping with standard cost calculation
        processor.ProcessShipping(weight, distance, standardCostCalculator);

        // Process shipping with express cost calculation
        processor.ProcessShipping(weight, distance, expressCostCalculator);
    }
}