namespace RefactoringCodeBloaters.LongMethod.Incorrect
{
    public class CalculationService
    {
        public double CalculatePriceAfterDiscount(int quantity, int itemPrice)
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
