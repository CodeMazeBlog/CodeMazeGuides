using MergeSort;

namespace MergeSortTest;

[TestClass]
public class MergeUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new Merge();

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_CheckInstanceType()
    {
        var sortFunction = new Merge();
        var array = Merge.GenerateRandomNumber(200);

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        Assert.IsInstanceOfType(sortedArray, typeof(int[]));
    }

    [TestMethod]
    public void GivenUnsortedArray_CheckSortedNotNull()
    {
        var sortFunction = new Merge();
        var array = Merge.GenerateRandomNumber(200);

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenRandomArray_WhenSorted_ThenMatchesArraySort()
    {
        var sortFunction = new Merge();
        var array = Merge.GenerateRandomNumber(1_000);
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    [DataRow(new int[] { })]
    [DataRow(new int[] { 42 })]
    [DataRow(new int[] { 5, 3, 5, 1, 3, 5 })]
    [DataRow(new int[] { 1, 2, 3, 4, 5, 6 })]
    [DataRow(new int[] { 6, 5, 4, 3, 2, 1 })]
    public void GivenEdgeCaseArray_WhenSorted_ThenMatchesArraySort(int[] array)
    {
        var sortFunction = new Merge();
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = sortFunction.SortArray(array, 0, array.Length - 1);

        CollectionAssert.AreEqual(expected, sortedArray);
    }
}
