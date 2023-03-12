namespace RefactoringObjectOrientationAbusers.TemporaryField.Incorrect
{
    public class BookstoreCustomer
    {
        public int DiscountTreshold { get; set; }
        public int BoughtBooksCount { get; set; }
        public ICollection<string> BoughtBooks { get; set; }

        public double GetDiscountRate()
        {
            BoughtBooksCount = BoughtBooks.Count;
            DiscountTreshold = GetDiscountThreshold();

            var discountBase = 0.05;
            return DiscountTreshold * discountBase;
        }

        private int GetDiscountThreshold()
        {
            var firstThreshold = 1;
            var secondThreshold = 2;
            return BoughtBooksCount < 10 ? firstThreshold : secondThreshold;
        }
    }
}
