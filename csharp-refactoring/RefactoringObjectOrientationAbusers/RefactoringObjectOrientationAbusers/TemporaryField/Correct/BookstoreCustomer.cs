namespace RefactoringObjectOrientationAbusers.TemporaryField.Correct
{
    public class BookstoreCustomer
    {
        public ICollection<string> BoughtBooks { get; set; }

        public double GetDiscountRate()
        {
            var boughtBooksCount = BoughtBooks.Count;
            var discountTreshold = GetDiscountThreshold(boughtBooksCount);

            var discountBase = 0.05;
            return discountTreshold * discountBase;
        }

        private int GetDiscountThreshold(double boughtBooksCount)
        {
            var firstThreshold = 1;
            var secondThreshold = 2;
            return boughtBooksCount < 10 ? firstThreshold : secondThreshold;
        }
    }
}
