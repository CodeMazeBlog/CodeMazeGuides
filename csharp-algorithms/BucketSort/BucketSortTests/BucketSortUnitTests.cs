using BucketSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BucketSortTests
{
    [TestClass]
    public class BucketSortUnitTests
    {
        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
            var sortFunction = new BucketSortMethods();

            var sortOptimized = sortFunction.SortArrayOptimized(array, string.Empty);
            var sortNormal = sortFunction.SortArray(array, string.Empty);

            CollectionAssert.AreEqual(expected, sortOptimized); 
            CollectionAssert.AreEqual(sortNormal, expected);
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
        {
            var sortFunction = new BucketSortMethods(); ;
            var array = BucketSortMethods.CreateRandomArray(200);

            var sortedArray = sortFunction.SortArrayOptimized(array, string.Empty);

            Assert.IsInstanceOfType(sortedArray, typeof(int[]));
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
        {
            var sortFunction = new BucketSortMethods();
            var array = BucketSortMethods.CreateRandomArray(200);

            var sortedArray = sortFunction.SortArrayOptimized(array, string.Empty);

            Assert.IsNotNull(sortedArray);
        }

        [TestMethod]
        public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
        {
            var array = new int[] { 73 };
            var expected = new int[] { 73 };
            var sortFunction = new BucketSortMethods();

            var sortedArray = sortFunction.SortArrayOptimized(array, string.Empty);

            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }
    }
}