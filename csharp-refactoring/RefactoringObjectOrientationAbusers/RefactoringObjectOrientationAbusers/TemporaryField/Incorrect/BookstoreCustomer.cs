namespace RefactoringObjectOrientationAbusers.TemporaryField.Incorrect
{
    public class BookstoreCustomer
    {
        public int DiscountThreshold { get; set; }
        public int BoughtBooksCount { get; set; }
        public ICollection<string> BoughtBooks { get; set; }

        public double GetDiscountRate()
        {
            BoughtBooksCount = BoughtBooks.Count;
            DiscountThreshold = GetDiscountThreshold();

            var discountBase = 0.05;
            return DiscountThreshold * discountBase;
        }

        private int GetDiscountThreshold()
        {
            var firstThreshold = 1;
            var secondThreshold = 2;
            return BoughtBooksCount < 10 ? firstThreshold : secondThreshold;
        }
    }
}
