namespace csharp_refactoring.LongMethod.Incorrect
{
    public class CalculationService
    {
        public double CalculateDiscount(int quantity, int itemPrice)
        {
            double orderValue = quantity * itemPrice;

            if (orderValue > 250)
            {
                return orderValue * 0.95;
            }
            else
            {
                return orderValue;
            }
        }
    }
}
