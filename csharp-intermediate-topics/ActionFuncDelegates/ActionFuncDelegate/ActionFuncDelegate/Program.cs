using Actions;

namespace Actions_and_Funcs
{
    class Program
    {

        static void Main()
        {
            ShippingProcessor processor = new ShippingProcessor();

            Action<decimal> standardCostCalculator = (total) =>
            {
                decimal standardCost = total * 0.02m; // Assuming a flat rate of 2% of total cost
                Console.WriteLine($"Standard Shipping Cost: {standardCost:C}");
            };

            Action<decimal> expressCostCalculator = (total) =>
            {
                decimal expressCost = total * 0.05m; // Assuming a flat rate of 5% of total cost
                Console.WriteLine($"Express Shipping Cost: {expressCost:C}");
            };

            decimal weight = 10m; // in kilograms
            decimal distance = 100m; // in kilometers

            // Process shipping with standard cost calculation
            processor.ProcessShipping(weight, distance, standardCostCalculator);

            // Process shipping with express cost calculation
            processor.ProcessShipping(weight, distance, expressCostCalculator);
        }
    }


}















