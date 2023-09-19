namespace Actions
{
    public class ShippingProcessor
    {
        public void ProcessShipping(decimal weight, decimal distance, Action<decimal> calculateCost)
        {
            calculateCost(weight * distance);
        }

    }
}