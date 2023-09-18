namespace Funcs
{
        public class ShippingProcessor
        {
            public void ProcessShipping(decimal weight, decimal distance, Func<decimal, decimal> calculateCost)
            {
                decimal totalCost = calculateCost(weight * distance);
                Console.WriteLine($"Shipping Cost: {totalCost:C}");
            }
        }

}