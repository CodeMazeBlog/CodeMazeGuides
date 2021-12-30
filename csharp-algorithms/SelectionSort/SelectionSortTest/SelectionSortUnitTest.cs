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
           
            int[] numArray = new int[10] { 57, 1, 98, 65, 88, 24, 45, 13, 79, 34 };
            int arrayLength = numArray.Length;

            int[] expectedArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };

            int[] actualArray = Program.SortArray(numArray, arrayLength);

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
            int[] numArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };
            int arrayLength = numArray.Length;

            int[] expectedArray = new int[10] { 1, 13, 24, 34, 45, 57, 65, 79, 88, 98 };

            int[] actualArray = Program.SortArray(numArray, arrayLength);

            bool expected = true;
            bool actual = Enumerable.SequenceEqual(expectedArray, actualArray);

            Assert.AreEqual(expected, actual);
        }
    }
}