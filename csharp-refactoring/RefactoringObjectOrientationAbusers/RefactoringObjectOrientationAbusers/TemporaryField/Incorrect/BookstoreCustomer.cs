namespace RefactoringObjectOrientationAbusers.TemporaryField.Incorrect
{
    public class BookstoreCustomer
    {
        private int _discountThreshold;
        private int _boughtBooksCount;
        public ICollection<string> BoughtBooks { get; set; }

        public double GetDiscountRate()
        {
            _boughtBooksCount = BoughtBooks.Count;
            _discountThreshold = GetDiscountThreshold();
            var discountBase = 0.05;

            return _discountThreshold * discountBase;
        }

        private int GetDiscountThreshold()
        {
            var firstThreshold = 1;
            var secondThreshold = 2;

            return _boughtBooksCount < 10 ? firstThreshold : secondThreshold;
        }
    }
}
