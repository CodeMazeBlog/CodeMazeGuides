using CountingSort;

namespace CountingSortTests
{
    [TestClass]
    public class CountingSortUnitTests
    {
        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
            var sortFunction = new CountingSortMethods();

            var sortedArray = sortFunction.CountingSort(array, string.Empty);

            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
        {
            var sortFunction = new CountingSortMethods();
            var array = CountingSortMethods.CreateRandomArray(200, 0, 200);

            var sortedArray = sortFunction.CountingSort(array, string.Empty);

            Assert.IsInstanceOfType(sortedArray, typeof(int[]));
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
        {
            var sortFunction = new CountingSortMethods();
            var array = CountingSortMethods.CreateRandomArray(200, 0, 200);

            var sortedArray = sortFunction.CountingSort(array, string.Empty);

            Assert.IsNotNull(sortedArray);
        }

        [TestMethod]
        public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
        {
            var array = new int[] { 73 };
            var expected = new int[] { 73 };
            var sortFunction = new CountingSortMethods();

            var sortedArray = sortFunction.CountingSort(array, string.Empty);

            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }
    }
}