namespace RefactoringCodeBloaters.LongMethod.Correct
{
    public class CalculationService
    {
        public double CalculatePriceAfterDiscount(int quantity, int itemPrice)
        {
            if (GetOrderValue(quantity, itemPrice) < 250)
            {
                return GetOrderValue(quantity, itemPrice);
            }
            else
            {
                return GetOrderValue(quantity, itemPrice) * 0.95;
            }
        }

        private static int GetOrderValue(int quantity, int itemPrice)
        {
            return quantity * itemPrice;
        }
    }
}
