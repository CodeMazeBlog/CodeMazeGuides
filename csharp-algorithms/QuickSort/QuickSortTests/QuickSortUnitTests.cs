using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;

namespace QuickSortTests;

[TestClass]
public class QuickSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1, 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 1, 20, 20, 49, 49, 57, 57, 73, 73, 99, 99, 133, 133 };

        var sortFunction = new QuickSortMethods();

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArticleArray_WhenSorted_ThenAllNineElementsAreInOrder()
    {
        int[] array = { 52, 96, 67, 71, 42, 38, 39, 40, 14 };
        var expected = new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 };

        var sortedArray = new QuickSortMethods().SortArray(array, 0, array.Length - 1);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenRandomArray_WhenSortedWithEitherPivot_ThenMatchesArraySort()
    {
        var sortFunction = new QuickSortMethods();
        var source = QuickSortMethods.CreateRandomArray(2000);
        var expected = (int[])source.Clone();
        Array.Sort(expected);

        var firstPivot = sortFunction.SortArray((int[])source.Clone(), 0, source.Length - 1);
        var middlePivot = sortFunction.SortArrayWithMiddlePivot((int[])source.Clone(), 0, source.Length - 1);

        CollectionAssert.AreEqual(expected, firstPivot);
        CollectionAssert.AreEqual(expected, middlePivot);
    }

    [TestMethod]
    public void GivenSortedArray_WhenSortedWithMiddlePivot_ThenStaysSorted()
    {
        var array = QuickSortMethods.CreateSortedArray(100_000);
        var expected = QuickSortMethods.CreateSortedArray(100_000);

        var sortedArray = new QuickSortMethods().SortArrayWithMiddlePivot(array, 0, array.Length - 1);

        CollectionAssert.AreEqual(expected, sortedArray);
    }
}
