using HeapSort;

namespace HeapSortTests;

[TestClass]
public class HeapSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArticleExample_WhenSorted_ThenNegativeValueComesFirst()
    {
        var array = new int[] { 12, 2, 24, 51, 8, -5 };
        var expected = new int[] { -5, 2, 8, 12, 24, 51 };
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenEmptyArray_WhenSorted_ThenReturnEmptyArray()
    {
        var array = Array.Empty<int>();
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.AreEqual(0, sortedArray.Length);
    }

    [TestMethod]
    public void GivenSortedArray_WhenSorted_ThenArrayStaysSorted()
    {
        var array = HeapSortMethods.CreateSortedArray(1_000);
        var expected = HeapSortMethods.CreateSortedArray(1_000);
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenIdenticalValues_WhenSorted_ThenValuesAreUnchanged()
    {
        var array = HeapSortMethods.CreateIdenticalArray(1_000, 1, 100);
        var expected = (int[])array.Clone();
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenRandomArrayWithDuplicates_WhenSorted_ThenMatchesArraySort()
    {
        var array = HeapSortMethods.CreateRandomArray(5_000, 0, 500);
        var expected = (int[])array.Clone();
        Array.Sort(expected);
        var sortFunction = new HeapSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }
}
