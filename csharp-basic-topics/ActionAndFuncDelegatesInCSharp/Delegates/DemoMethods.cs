namespace Delegates
{
    public class DemoMethods
    {
        public decimal CalculateFinalTotal(decimal originalPrice, decimal percentDiscount)
        {
            var markdown = Math.Round(originalPrice * (percentDiscount / 100m), 2, MidpointRounding.ToEven);
            return originalPrice - markdown;
        }

        public void DisplayTotalBeforDiscount(List<Product> products)
        {
            var originalPrice = products.Sum(product => product.Price);
            Console.WriteLine($"The total price before the discount {originalPrice:C2}");
        }

        public decimal CalculateClientOrdersTotal(AwesomeCalculator delegateCalculator, List<Product> products)
        {
            var originalPrice = products.Sum(product => product.Price);

            // Invoke delegate
            return delegateCalculator(originalPrice, 50);
        }

        public decimal CalculateClientOrdersTotal2(Func<decimal, decimal, decimal> calculateDiscountedPrice,
            List<Product> products)
        {
            var originalPrice = products.Sum(product => product.Price);
            return calculateDiscountedPrice(originalPrice, 50);
        }
    }
}
