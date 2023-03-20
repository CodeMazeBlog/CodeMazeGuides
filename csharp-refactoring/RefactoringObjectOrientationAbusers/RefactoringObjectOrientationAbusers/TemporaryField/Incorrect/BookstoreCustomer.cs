namespace RefactoringObjectOrientationAbusers.TemporaryField.Incorrect
{
    public class BookstoreCustomer
    {
        private int discountThreshold;
        private int boughtBooksCount;
        public ICollection<string> BoughtBooks { get; set; }

        public double GetDiscountRate()
        {
            boughtBooksCount = BoughtBooks.Count;
            discountThreshold = GetDiscountThreshold();
            var discountBase = 0.05;

            return discountThreshold * discountBase;
        }

        private int GetDiscountThreshold()
        {
            var firstThreshold = 1;
            var secondThreshold = 2;

            return boughtBooksCount < 10 ? firstThreshold : secondThreshold;
        }
    }
}
