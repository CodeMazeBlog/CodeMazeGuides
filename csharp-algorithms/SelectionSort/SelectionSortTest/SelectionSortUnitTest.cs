using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectionSort;

namespace SelectionSortTest
{
    [TestClass]
    public class SelectionSortUnitTest
    {
        [TestMethod]
        public void GivenUnsortedArray_ThenReturnSortedArray()
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
            var sortFunction = new Selection();
            sortFunction.NumArray = array;

            var sortedArray = sortFunction.SortArray();

            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }

        [TestMethod]
        public void GivenUnsortedArray_CheckInstanceType()
        {
            var sortFunction = new Selection();
            sortFunction.NumArray = Selection.AddRandomElements(200);

            var sortedArray = sortFunction.SortArray();

            Assert.IsInstanceOfType(sortedArray, typeof(int[]));
        }

        [TestMethod]
        public void GivenUnsortedArray_CheckSortedNotNull()
        {
            var sortFunction = new Selection();
            sortFunction.NumArray = Selection.AddRandomElements(200);

            var sortedArray = sortFunction.SortArray();

            Assert.IsNotNull(sortedArray);
        }
    }
}