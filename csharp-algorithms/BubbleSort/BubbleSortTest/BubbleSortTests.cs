using BubbleSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BubbleSortTest
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void GivenUnsortedArray_ThenReturnSortedArray()
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
            var sortFunction = new Bubble();

            var sortedArray = sortFunction.SortArray(array);
            
            Assert.IsNotNull(sortedArray);
            CollectionAssert.AreEqual(sortedArray, expected);
        }

        [TestMethod]
        public void GivenUnsortedArray_ThenReturnSortTime()
        {
            var sortFunction = new Bubble();
            var best = new int[2000];
            var average = new int[20000];
            var worst = new int[100000];

            var bestDuration = sortFunction.GetSortingTime(best);
            var averageDuration = sortFunction.GetSortingTime(average);
            var worstDuration = sortFunction.GetSortingTime(worst);

            Assert.IsTrue(averageDuration > bestDuration);
            Assert.IsTrue(worstDuration > bestDuration);
            Assert.IsTrue  (worstDuration > averageDuration);
        }

        [TestMethod]
        public void GivenUnsortedArray_CheckInstanceType()
        {
            var sortFunction = new Bubble();
            var array = new int[2000];

            var sortedArray = sortFunction.SortArray(array);

            Assert.IsInstanceOfType(sortedArray, typeof(int[]));
        }

        [TestMethod]
        public void GivenUnsortedArray_CheckSortedNotNull()
        {
            var sortFunction = new Bubble();
            var array = new int[2000];

            var sortedArray = sortFunction.SortArray(array);

            Assert.IsNotNull(sortedArray);
        }
    }
}