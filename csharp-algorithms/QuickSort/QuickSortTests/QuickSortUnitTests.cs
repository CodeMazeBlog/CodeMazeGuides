using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;
using System;

namespace QuickSortTests
{
    [TestClass]
    public class QuickSortUnitTests
    {
        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1, 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 1,20, 20, 49, 49, 57, 57, 73, 73, 99, 99, 133, 133 };
      
            var sortFunction = new QuickSortMethods();

            var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1, string.Empty);

            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenCheckInstanceType()
        {
            var sortFunction = new QuickSortMethods();
            var array = QuickSortMethods.CreateRandomArray(200);

            var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1, string.Empty);

            Assert.IsInstanceOfType(sortedArray, typeof(int[]));
        }

        [TestMethod]
        public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
        {
            var sortFunction = new QuickSortMethods();
            var array = QuickSortMethods.CreateRandomArray(5);

            var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1, string.Empty);

            Assert.IsNotNull(sortedArray);
        }
    }
}