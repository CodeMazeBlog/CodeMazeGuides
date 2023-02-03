using ActionPredikateandFuncExample;

namespace Test
{
    [TestClass]
    public class SimpleSortUnitTests
    {
        private readonly SimpleSort _simpleSort = new();

        [TestMethod]
        public void GivenEmptyArray_WhenUsingSort_ThenResultIsEmptyArray()
        {
            int[] unsortedNumbers = { };
            int[] sortedNumbers = { };
            _simpleSort.SortNumbers(unsortedNumbers);

            CollectionAssert.AreEqual(sortedNumbers, unsortedNumbers);
        }

        [TestMethod]
        public void GivenArrayWithOneElement_WhenUsingSort_ThenResultIsEqual()
        {
            int[] unsortedNumbers = { 1 };
            int[] sortedNumbers = { 1 };
            _simpleSort.SortNumbers(unsortedNumbers);

            CollectionAssert.AreEqual(sortedNumbers, unsortedNumbers);
        }

        [TestMethod]
        public void GivenUnsortedIntegerArray_WhenUsingSort_ThenTheResultIsSortedArray()
        {
            int[] unsortedNumbers = { 4, 2, 9, 6, 23, 12, 34, 0, 1 };
            int[] sortedNumbers = { 0, 1, 2, 4, 6, 9, 12, 23, 34 };
            _simpleSort.SortNumbers(unsortedNumbers);

            CollectionAssert.AreEqual(sortedNumbers, unsortedNumbers);
        }
    }
}