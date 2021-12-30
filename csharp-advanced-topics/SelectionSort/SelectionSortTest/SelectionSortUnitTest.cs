using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SelectionSortTest
{
    [TestClass]
    public class SelectionSortUnitTest
    {
        [TestMethod]
        public void GivenUnsortedArray_ThenreturnSortedArray()
        {
            //define an unsorted array
            int[] numArray = new int[10] { 57, 1, 98, 65, 88, 24, 45, 13, 79, 34 };
            int arrayLength = numArray.Length;

            //the expected sorted array
            int[] expectedArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };

            //call the selection sort algorithm on the unsorted array
            int[] actualArray = Program.SortArray(numArray, arrayLength);

            //we expect both arrays to be equal when their elements are compared
            bool expected = true;
            bool actual = Enumerable.SequenceEqual(expectedArray, actualArray);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenEmptyArray_ThenReturnCorrectLength()
        {
            int[] numArray = new int[0];
            int arrayLength = numArray.Length;
            int expected = 0;
            int actual = Program.SortArray(numArray, arrayLength).Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenSortedArray_ReturnSortedArray()
        {
            //define an unsorted array
            int[] numArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };
            int arrayLength = numArray.Length;

            //the expected sorted array
            int[] expectedArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };

            //call the selection sort algorithm on the unsorted array
            int[] actualArray = Program.SortArray(numArray, arrayLength);

            //we expect both arrays to be equal when their elements are compared
            bool expected = true;
            bool actual = Enumerable.SequenceEqual(expectedArray, actualArray);

            Assert.AreEqual(expected, actual);
        }
    }
}